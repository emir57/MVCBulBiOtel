using FluentEntity_ConsoleApp.FEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using OtelProject.Enums;
using OtelProject.Models;
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
            var otelUser = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserName == username);
            if (otelUser != null)
            {
                if (password == otelUser.OtelPassword)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    if (otelUser.OtelStatus == (int)OtelStatus.Ok)
                    {
                        if (otelUser.OtelId == (int)OtelStatus.Wait)
                        {
                            return RedirectToAction(nameof(OtelUserPanel));
                        }
                        return RedirectToAction(nameof(OtelUserEdit));
                    }
                    return RedirectToAction(nameof(PermissionCheck));
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
            var check = context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserName.ToLower() == username.ToLower());
            if (check != null)
            {
                OtelUser otelUser = new FluentEntity<OtelUser>()
                    .AddParameter(o => o.OtelUserName, username)
                    .AddParameter(o => o.OtelPassword, password)
                    .AddParameter(o => o.OtelName, otelName)
                    .AddParameter(o => o.OtelMail, mail)
                    .GetEntity();
                context.OtelUsers.Add(otelUser);
                await context.SaveChangesAsync();
                return RedirectToAction("OtelLogin");
            }
            ViewBag.message = "Kullanıcı adı kullanılıyor.";
            return View();
        }

        [Authorize]
        public async Task<ActionResult> OtelDelete(int id)
        {
            int currentUserId = getId();
            var entity = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == id);
            context.Entry(entity).State = EntityState.Deleted;

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
                ViewBag.check = "Hesabınız Onaylanmadı.";
            else if (entity.OtelStatus == 0)
                ViewBag.check = "Hesabınız Onaylanmayı Bekliyor";

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
            var check = await context.Otels.SingleOrDefaultAsync(a => a.OtelName.ToLower() == name.ToLower());
            if (check == null)
            {
                string databaseImageUrl = "../wwwroot/otelPicture/default.jpg";
                if (picture != null)
                {
                    string extension = Path.GetExtension(picture.FileName);
                    string fileName = Guid.NewGuid() + extension;
                    string path = Server.MapPath("~/wwwroot/otelPicture/");
                    picture.SaveAs(Path.Combine(path, fileName));
                    databaseImageUrl = "../wwwroot/otelPicture/" + fileName;
                }
                Otel otel = new FluentEntity<Otel>()
                    .AddParameter(o => o.OtelName, name)
                    .AddParameter(o => o.OtelLocation, location)
                    .AddParameter(o => o.OtelPrice, price)
                    .AddParameter(o => o.OtelDescription, description)
                    .AddParameter(o => o.OtelStars, stars)
                    .AddParameter(o => o.OtelRating, rating)
                    .AddParameter(o => o.OtelCountry, countries)
                    .AddParameter(o => o.OtelPicture, databaseImageUrl)
                    .GetEntity();
                context.Otels.Add(otel);
                await context.SaveChangesAsync();

                var currentUser = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);
                currentUser.OtelId = otel.OtelsId;

                await context.SaveChangesAsync();

                return RedirectToAction("OtelUserEdit");
            }
            var countriesList = await context.Countries.ToListAsync();
            ViewBag.message = "Aynı ada sahip otel zaten var!";
            return View(countriesList);
        }
        [Authorize]
        public async Task<ActionResult> OtelUserEdit(int? id)
        {
            id = getId();
            var result = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);
            var otel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == result.OtelId);
            var country = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == otel.OtelCountry);
            OtelUserEditViewModel model = new OtelUserEditViewModel()
            {
                Countries = await context.Countries.ToListAsync(),
                Otel = otel
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> OtelUserEdit(Otel otel, int? id, HttpPostedFileBase picture)
        {
            id = getId();
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == id);
            var getOtel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == user.OtelId);
            string databaseImageUrl = getOtel.OtelPicture;
            if (picture != null)
            {
                string imageExtention = Path.GetExtension(picture.FileName);
                string fileName = Guid.NewGuid() + imageExtention;
                string filePath = Server.MapPath("~/wwwroot/otelPicture/");
                picture.SaveAs(Path.Combine(filePath, fileName));
                databaseImageUrl = "../wwwroot/otelPicture/" + fileName;
            }
            getOtel = new FluentEntity<Otel>(getOtel)
                .AddParameter(o => o.OtelName, otel.OtelName)
                .AddParameter(o => o.OtelLocation, otel.OtelLocation)
                .AddParameter(o => o.OtelPrice, otel.OtelPrice)
                .AddParameter(o => o.OtelDescription, otel.OtelDescription)
                .AddParameter(o => o.OtelStars, otel.OtelStars)
                .AddParameter(o => o.OtelRating, otel.OtelRating)
                .AddParameter(o => o.OtelCountry, otel.OtelCountry)
                .AddParameter(o => o.OtelPicture, databaseImageUrl)
                .GetEntity();
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