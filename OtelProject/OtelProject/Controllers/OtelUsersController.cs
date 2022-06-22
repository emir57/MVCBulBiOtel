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
using System.Web.Security;

namespace OtelProject.Controllers
{
    public class OtelUsersController : Controller
    {
        int getId()
        {
            string cookiename = FormsAuthentication.FormsCookieName;
            HttpCookie authcookie = HttpContext.Request.Cookies[cookiename];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authcookie.Value);
            string name = ticket.Name;
            var entity = context.OtelUsers.SingleOrDefault(a => a.OtelUserName == name);
            if (entity != null)
                return entity.OtelUserId;
            return 0;
        }
        BulBiOtelContext context = new BulBiOtelContext();
        [AllowAnonymous]
        public ActionResult OtelLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> OtelLogin(string username, string password)
        {
            var entity = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserName == username);
            if (entity != null)
            {
                if (password == entity.OtelPassword)
                {
                    FormsAuthentication.SetAuthCookie(username, false);

                    //Otel Permission 3 - OK    /   0 - Wait       / 1 - No
                    //OtelId ? 0 create otel - 1 edit otel
                    if (entity.OtelStatus == 3)
                    {
                        if (entity.OtelId == 0)
                        {
                            return RedirectToAction("OtelUserPanel");
                        }
                        return RedirectToAction("OtelUserEdit");
                    }
                    return RedirectToAction("PermissionCheck");
                }
            }
            ViewBag.Message = "Kullanıcı adı veya parola yanlış.";
            return View();
        }
        [AllowAnonymous]
        public ActionResult OtelRegister()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> OtelRegister(string username, string password, string otelName, string mail)
        {
            var check = context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserName == username);
            if (check != null)
            {
                context.OtelUsers.Add(new OtelUser
                {
                    OtelUserName = username,
                    OtelPassword = password,
                    OtelName = otelName,
                    OtelMail = mail
                });
                await context.SaveChangesAsync();
                return RedirectToAction("OtelLogin");
            }
            else
            {
                ViewBag.message = "Kullanıcı adı kullanılıyor.";
                return View();
            }

        }

        [Authorize]
        public async Task<ActionResult> OtelDelete(int id)
        {
            int currentUserId = getId();
            var entity = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == id);
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            var currentUser = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == currentUserId);
            currentUser.OtelId = 0;
            await context.SaveChangesAsync();

            return RedirectToAction("OtelUserPanel");
        }
        [AllowAnonymous]
        public ActionResult PermissionCheck()
        {
            string cookiename = FormsAuthentication.FormsCookieName;
            HttpCookie authcookie = HttpContext.Request.Cookies[cookiename];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authcookie.Value);
            string name = ticket.Name;
            var entity = context.OtelUsers.SingleOrDefault(a => a.OtelUserName == name);
            //3 - OK    /   0 - Wait       / 1 - No
            if (entity.OtelStatus == 1)
            {
                ViewBag.check = "Hesabınız Onaylanmadı.";
            }
            else if (entity.OtelStatus == 0)
            {
                ViewBag.check = "Hesabınız Onaylanmayı Bekliyor";
            }
            return View();
        }
        [Authorize]
        public async Task<ActionResult> OtelUserPanel()
        {
            var countries = await context.Countries.ToListAsync();
            return View(countries);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> OtelUserPanel(string name, string location, decimal price, string description, byte stars, double rating, int countries, HttpPostedFileBase picture)
        {
            int id = getId();
            var check = await context.Otels.SingleOrDefaultAsync(a => a.OtelName == name);
            if (check == null)
            {
                //picture save
                string totalName;
                if (picture != null)
                {
                    string extension = Path.GetExtension(picture.FileName);
                    string fileName = Guid.NewGuid() + extension;
                    string path = Server.MapPath("~/wwwroot/otelPicture/");
                    picture.SaveAs(Path.Combine(path, fileName));
                    totalName = "../wwwroot/otelPicture/" + fileName;
                }
                else
                {
                    totalName = "../wwwroot/otelPicture/default.jpg";
                }
                //add otel
                var otel = new Otel
                {
                    OtelName = name,
                    OtelLocation = location,
                    OtelPrice = price,
                    OtelDescription = description,
                    OtelStars = stars,
                    OtelRating = rating,
                    OtelCountry = countries,
                    OtelPicture = totalName
                };
                context.Otels.Add(otel);
                await context.SaveChangesAsync();
                //find id
                var otelId = await context.Otels.SingleOrDefaultAsync(a => a.OtelName == name && a.OtelLocation == location && a.OtelPrice == price && a.OtelDescription == description);
                //get current user

                var currentUser = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);

                currentUser.OtelId = otelId.OtelsId;
                await context.SaveChangesAsync();
            }
            else
            {
                var list = await context.Countries.ToListAsync();
                ViewBag.message = "Aynı ada sahip otel zaten var!";
                return View(list);
            }
            return RedirectToAction("OtelUserEdit");
        }
        [Authorize]
        public async Task<ActionResult> OtelUserEdit(int? id)
        {
            id = getId();
            var result = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);
            var otel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == result.OtelId);
            var country = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == otel.OtelCountry);
            ViewData["OtelsId"] = otel.OtelsId;
            ViewData["OtelName"] = otel.OtelName;
            ViewData["OtelLocation"] = otel.OtelLocation;
            ViewData["OtelPrice"] = otel.OtelPrice;
            ViewData["OtelDescription"] = otel.OtelDescription;
            ViewData["OtelStars"] = otel.OtelStars;
            ViewData["OtelRating"] = otel.OtelRating;
            ViewData["OtelCountry"] = otel.OtelCountry;
            ViewData["CountryName"] = country.CountryName;


            var countries = await context.Countries.ToListAsync();
            return View(countries);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> OtelUserEdit(int? id, HttpPostedFileBase picture, Otel otel)
        {
            id = getId();
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);
            var getOtel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == user.OtelId);
            string totalName = "";
            if (picture != null)
            {
                //image jpg png?
                string imageExtention = Path.GetExtension(picture.FileName);
                //identity special name
                string fileName = Guid.NewGuid() + imageExtention;
                //file save path
                string filePath = Server.MapPath("~/wwwroot/otelPicture/");
                //save - upload
                picture.SaveAs(Path.Combine(filePath, fileName));
                //total fileName (database)
                totalName = "../wwwroot/otelPicture/" + fileName;
            }
            else
            {
                totalName = getOtel.OtelPicture;
            }

            getOtel.OtelName = otel.OtelName;
            getOtel.OtelLocation = otel.OtelLocation;
            getOtel.OtelPrice = otel.OtelPrice;
            getOtel.OtelDescription = otel.OtelDescription;
            getOtel.OtelStars = otel.OtelStars;
            getOtel.OtelRating = otel.OtelRating;
            getOtel.OtelCountry = otel.OtelCountry;
            getOtel.OtelPicture = totalName;
            await context.SaveChangesAsync();
            return RedirectToAction("OtelUserEdit");
        }
        [Authorize]
        public ActionResult OtelLogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("OtelLogin");
        }
    }
}