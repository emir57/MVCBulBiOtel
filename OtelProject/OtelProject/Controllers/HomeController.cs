using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using OtelProject.Models.Context;
using OtelProject.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OtelProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        BulBiOtelContext context = new BulBiOtelContext();
        OtelCountry otelCountry = new OtelCountry();
        public async Task<ActionResult> Index(string searchString, int pricemin=1, int pricemax=0, byte countries = 0)
        {
            ViewBag.count = context.Otels.Count();
            otelCountry.c = await context.Countries.ToListAsync();
            return View(otelCountry);

        }
        //File Upload(TRY)
        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase formFile)
        //{
        //    if(formFile.ContentLength > 0)
        //    {
        //        //file .jpg - .png ?
        //        string imageExtension = Path.GetExtension(formFile.FileName);
        //        //identity name
        //        string filename = Guid.NewGuid() + imageExtension;
        //        //file save path
        //        string filePath = Server.MapPath("~/wwwroot/otelPicture/");
        //        //save - upload
        //        formFile.SaveAs(Path.Combine(filePath,filename));
        //        //total file name (for database)
        //        string totalName = "~/wwwroot/otelPicture/" + filename;
        //    }
        //    return RedirectToAction("Index");
        //}
        [ChildActionOnly]
        public async Task<PartialViewResult> GetOtels()
        {
            var otels = await context.Otels.ToListAsync();
            return PartialView("_GetOtels",otels);
        }
        [ChildActionOnly]
        public async Task<PartialViewResult> GetOtelsByCountry(int countryid)
        {
            var otels = await context.Otels.Where(a => a.OtelCountry == countryid).ToListAsync();
            return PartialView("_GetOtels", otels);
        }
        [ChildActionOnly]
        public async Task<PartialViewResult> GetOtelsByName(string searchKey)
        {
            var otels = await context.Otels
                .Where(a =>
                a.OtelName.ToLower().Contains(searchKey.ToLower()) ||
                a.OtelDescription.ToLower().Contains(searchKey.ToLower()) ||
                a.OtelLocation.ToLower().Contains(searchKey.ToLower()) ||
                a.OtelCountry.ToString() == searchKey
                )
                .ToListAsync();
            return PartialView("_GetOtels", otels);
        }
        [ChildActionOnly]
        public async Task<PartialViewResult> GetOtelsByPrice(int minprice,int maxprice)
        {
            var otels = await context.Otels.Where(a => a.OtelPrice>=minprice && a.OtelPrice<=maxprice).ToListAsync();
            return PartialView("_GetOtels", otels);
        }
        public ActionResult About()
        {
            ViewBag.Message =" yılında hizmete giren ve size uygun otelleri kolaylıkla bulmanıza yardımcı olmak amaçlı kurulmuş bir Websitesidir.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}