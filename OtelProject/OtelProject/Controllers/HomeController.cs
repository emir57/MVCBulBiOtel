#pragma warning disable CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
using Microsoft.AspNetCore.Http;
#pragma warning restore CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
#pragma warning disable CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
using Microsoft.AspNetCore.Http.Internal;
#pragma warning restore CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
#pragma warning disable CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
using Microsoft.AspNetCore.Mvc;
#pragma warning restore CS0234 // The type or namespace name 'AspNetCore' does not exist in the namespace 'Microsoft' (are you missing an assembly reference?)
using OtelProject.Models.Context;
using OtelProject.Models.Tables;
using System;
using System.Collections.Generic;
#pragma warning disable CS0234 // The type or namespace name 'Entity' does not exist in the namespace 'System.Data' (are you missing an assembly reference?)
using System.Data.Entity;
#pragma warning restore CS0234 // The type or namespace name 'Entity' does not exist in the namespace 'System.Data' (are you missing an assembly reference?)
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OtelProject.Controllers
{
#pragma warning disable CS0246 // The type or namespace name 'AllowAnonymous' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'AllowAnonymousAttribute' could not be found (are you missing a using directive or an assembly reference?)
    [AllowAnonymous]
#pragma warning restore CS0246 // The type or namespace name 'AllowAnonymousAttribute' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning restore CS0246 // The type or namespace name 'AllowAnonymous' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'Controller' could not be found (are you missing a using directive or an assembly reference?)
    public class HomeController : Controller
#pragma warning restore CS0246 // The type or namespace name 'Controller' could not be found (are you missing a using directive or an assembly reference?)
    {
        BulBiOtelContext context = new BulBiOtelContext();
        OtelCountry otelCountry = new OtelCountry();
#pragma warning disable CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        public async Task<ActionResult> Index(string searchString, int pricemin=1, int pricemax=0, byte countries = 0)
#pragma warning restore CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        {
            decimal pmin = Convert.ToDecimal(pricemin);
            decimal pmax = Convert.ToDecimal(pricemax);
            //Country and price range
            if(!(countries == 0) && (pmax > pmin))
            {
                otelCountry.o = await context.Otels.Where(a => a.OtelPrice >= pmin && a.OtelPrice <= pmax && a.OtelCountry == countries).ToListAsync();
            }

            //OtelName and Country
            else if (!(countries == 0) && !(string.IsNullOrEmpty(searchString)))
            {
                otelCountry.o = await context.Otels.Where(a => a.OtelName.ToLower().Contains(searchString.ToLower()) && a.OtelCountry == countries).ToListAsync();
            }
                                //Onlys
            //Only price range
            else if ((pmax > pmin) && (countries==0) && (string.IsNullOrEmpty(searchString)))
            {
                otelCountry.o = await context.Otels.Where(a => a.OtelPrice >= pmin && a.OtelPrice <= pmax).ToListAsync();
            }

            //Only Country
            else if (!(countries == 0) && (string.IsNullOrEmpty(searchString)) && (pmax < pmin))
            {
                otelCountry.o = await context.Otels.Where(a => a.OtelCountry == countries).ToListAsync();
            }
            
            //Only OtelName
            else if(!(string.IsNullOrEmpty(searchString)) && (countries==0) && (pmax < pmin))
            {
                otelCountry.o = await context.Otels.Where(a => a.OtelName.ToLower().Contains(searchString.ToLower())).ToListAsync();
            }
            
            else
            {
                otelCountry.o = await context.Otels.ToListAsync();
            }
            //if ((pmax > pmin) && !(countries == 0) && !(string.IsNullOrEmpty(searchString)))
            //{
            //    otelCountry.o = context.Otels.Where(a => a.OtelPrice >= pmin && a.OtelPrice <= pmax && a.OtelName.ToLower().Contains(searchString.ToLower()) && a.OtelCountry == countries).ToList();
            //}
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
#pragma warning disable CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        public ActionResult About()
#pragma warning restore CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        {
            ViewBag.Message =" yılında hizmete giren ve size uygun otelleri kolaylıkla bulmanıza yardımcı olmak amaçlı kurulmuş bir Websitesidir.";

            return View();
        }
#pragma warning disable CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        public ActionResult Contact()
#pragma warning restore CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
#pragma warning disable CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        public ActionResult Error()
#pragma warning restore CS0246 // The type or namespace name 'ActionResult' could not be found (are you missing a using directive or an assembly reference?)
        {
            return View();
        }
    }
}