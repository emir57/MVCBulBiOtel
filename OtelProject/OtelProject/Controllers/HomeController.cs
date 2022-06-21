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