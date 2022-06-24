using FluentEntity_ConsoleApp.FEntity;
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
    public class AdminController : Controller
    {
        string _processing;
        string _description;
        public async Task LogRecord(string operationType, string description)
        {
            DateTime today = DateTime.Now;

            //Current username
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userName = ticket.Name;

            LogRecord logRecord = new FluentEntity<LogRecord>()
                .AddParameter(l => l.LogAdminUserName, userName)
                .AddParameter(l => l.ProcessingDateTime, today)
                .AddParameter(l => l.OperationType, operationType)
                .AddParameter(l => l.Description, description)
                .GetEntity();
            context.LogRecords.Add(logRecord);
            await context.SaveChangesAsync();
        }

        public string getRole()
        {
            //Current username
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userName = ticket.Name;
            var user = context.Admins.SingleOrDefault(a => a.AdminUserName == userName);
            return user.Permission;
        }

        BulBiOtelContext context = new BulBiOtelContext();
        OtelCountry viewmodel = new OtelCountry();
        [AllowAnonymous]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AdminLogin(string username, string password)
        {
            _processing = "Giriş Yapıldı";
            //ViewBag.style = "display:none;";
            var entity = await context.Admins.SingleOrDefaultAsync(x => x.AdminUserName == username);
            if (entity != null)
            {
                if (entity.AdminPassword == password)
                {
                    FormsAuthentication.SetAuthCookie(entity.AdminUserName, false);

                    await LogRecord(_processing, _description);
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    ViewBag.style = "display:block;";
                    ViewBag.Message = "Hatalı Şifre veya Parola";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Hatalı Şifre veya Parola";
                return View();
            }

        }
        [Authorize(Roles = ("Admin"))]
        public ActionResult AdminPanel()
        {
            return View();
        }
        public async Task<ActionResult> AdminLogOut()
        {
            _processing = "Çıkış Yapıldı";

            await LogRecord(_processing, _description);
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");
        }

        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelAdd()
        {
            var countries = await context.Countries.ToListAsync();
            return View(countries);

        }
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> OtelAdd(string name, string location, decimal price, string description, byte stars, double rating, int countries, HttpPostedFileBase picture)
        {
            string databaseImageUrl = "../wwwroot/otelPicture/default.jpg";
            if (picture != null)
            {
                string imageExtention = Path.GetExtension(picture.FileName);
                string fileName = Guid.NewGuid() + imageExtention;
                string filePath = Server.MapPath("~/wwwroot/otelPicture/");
                picture.SaveAs(Path.Combine(filePath, fileName));
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
            await context.SaveChangesAsync();

            await LogRecord("Otel Kayıt Eklendi", name);

            return RedirectToAction("OtelAdd");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelList()
        {
            var list = await context.Otels.ToListAsync();

            await LogRecord("Otel Listeleme İşlemi Yapıldı", _description);

            return View(list);
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelDelete(int id)
        {
            var entity = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == id);
            var oteluser = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelId == id);
            oteluser.OtelId = 0;
            await context.SaveChangesAsync();

            _description = entity.OtelName;
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            await LogRecord("Otel Silme İşlemi Yapıldı.", _description);

            return RedirectToAction("OtelList");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(OtelList));
            }

            AdminOtelEditViewModel model = new AdminOtelEditViewModel()
            {
                Otel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == id),
                Countries = await context.Countries.ToListAsync()
            };
            return View(model);
        }
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> OtelEdit(int id, HttpPostedFileBase picture, Otel otel)
        {
            var entity = context.Otels.SingleOrDefault(a => a.OtelsId == id);
            string databaseImageUrl = entity.OtelPicture;
            if (picture != null)
            {
                string imageExtention = Path.GetExtension(picture.FileName);
                string fileName = Guid.NewGuid() + imageExtention;
                string filePath = Server.MapPath("~/wwwroot/otelPicture/");
                picture.SaveAs(Path.Combine(filePath, fileName));
                databaseImageUrl = "../wwwroot/otelPicture/" + fileName;
            }

            entity = new FluentEntity<Otel>(entity)
                .AddParameter(e => e.OtelName, otel.OtelName)
                .AddParameter(e => e.OtelLocation, otel.OtelLocation)
                .AddParameter(e => e.OtelPrice, otel.OtelPrice)
                .AddParameter(e => e.OtelDescription, otel.OtelDescription)
                .AddParameter(e => e.OtelStars, otel.OtelStars)
                .AddParameter(e => e.OtelRating, otel.OtelRating)
                .AddParameter(e => e.OtelCountry, otel.OtelCountry)
                .AddParameter(e => e.OtelPicture, databaseImageUrl)
                .GetEntity();
            await context.SaveChangesAsync();

            _processing = "Otel Düzenleme İşlemi Yapıldı";
            _description = otel.OtelName;
            await LogRecord(_processing, _description);

            return RedirectToAction("OtelList");
        }


        [Authorize(Roles = ("Admin"))]
        public ActionResult CountryAdd()
        {
            return View();
        }

        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> CountryAdd(string countryName)
        {
            Country country = new Country
            {
                CountryName = countryName
            };
            context.Countries.Add(country);
            await context.SaveChangesAsync();

            _processing = "Şehir Ekleme İşlemi Yapıldı";
            _description = countryName;
            await LogRecord(_processing, _description);

            return RedirectToAction("CountryAdd");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CountryDelete(int id)
        {

            var entity = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == id);
            _description = entity.CountryName;
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            _processing = "Şehir Silme İşlemi Yapıldı";
            await LogRecord(_processing, _description);

            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CountryEdit(int? id)
        {
            var result = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == id);
            return View(result);
        }
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> CountryEdit(int id, Country country)
        {
            var entity = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == id);
            entity.CountryName = country.CountryName;
            await context.SaveChangesAsync();

            _processing = "Şehir Düzenleme İşlemi Yapıldı.";
            _description = entity.CountryName;
            await LogRecord(_processing, _description);

            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CountryList()
        {
            var list = await context.Countries.ToListAsync();

            await LogRecord("Şehir Listeleme İşlemi Yapıldı", _description);
            return View(list);
        }

        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> LogRecords()
        {
            var list = await context.LogRecords.ToListAsync();

            await LogRecord("Log Kayıtları Listelendi", _description);
            return View(list);
        }
        //Otel users
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelUsersList(string query)
        {
            var list = await context.OtelUsers.ToListAsync();
            if (query == null)
                return View(list);
            if (query == "Bekleyen Kayıtları Listele")
            {
                list = await context.OtelUsers.Where(a => a.OtelStatus == (int)OtelStatus.Wait).ToListAsync();

                _processing = "Durumu Beklenen Otel Kullanıcıları Listelendi";
                await LogRecord(_processing, _description);
            }
            if (query == ((int)OtelStatus.No).ToString())
                list = await context.OtelUsers.Where(a => a.OtelStatus == (int)OtelStatus.No).ToListAsync();
            if (query == ((int)OtelStatus.Ok).ToString())
                list = await context.OtelUsers.Where(a => a.OtelStatus == (int)OtelStatus.Ok).ToListAsync();
            if (query == "Tüm Kayıtları Göster")
                await LogRecord("Tüm Otel Kullanıcıları Listelendi", _description);
            return View(list);
        }
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelAccept(int userid)
        {
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == userid);
            user.OtelStatus = (int)OtelStatus.Ok;
            user.Permission = "User";
            await context.SaveChangesAsync();

            _processing = $"{user.OtelUserName} adlı otel kullanıcısının durmu Onaylandı.";
            await LogRecord(_processing, _description);

            return RedirectToAction("OtelUsersList");
        }
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelDeny(int userid)
        {
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == userid);
            user.OtelStatus = (int)OtelStatus.No;
            await context.SaveChangesAsync();

            _processing = $"{user.OtelUserName} adlı otel kullanıcısının durmu Reddedildi.";
            await LogRecord(_processing, _description);

            return RedirectToAction("OtelUsersList");
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelDenyDelete()
        {
            List<OtelUser> otelUsers = await context.OtelUsers.Where(a => a.OtelStatus == (int)OtelStatus.No).ToListAsync();
            foreach (OtelUser otelUser in otelUsers)
            {
                context.Entry(otelUser).State = EntityState.Deleted;
            }
            await context.SaveChangesAsync();

            _processing = "Reddedilen tüm otel kulllanıcıları silindi.";
            await LogRecord(_processing, _description);

            return RedirectToAction("OtelUsersList");
        }

    }
}