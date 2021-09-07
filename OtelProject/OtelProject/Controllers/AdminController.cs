﻿using OtelProject.Models.Context;
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
        //Log Record
        public void LogRecord(DateTime dateTime,string processing,string description)
        {
            //Current username
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string userName = ticket.Name;

            context.LogRecords.Add(new LogRecord {
                LogAdminUserName = userName,
                ProcessingDateTime = dateTime,
                OperationType = processing,
                Description = description
            });
            context.SaveChangesAsync();
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
                    //Logs login
                    DateTime now = DateTime.Now;
                    LogRecord(now,_processing,_description);
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
        [Authorize(Roles=("Admin"))]
        public ActionResult AdminPanel()
        {
            return View();
        }
        
        public ActionResult AdminLogOut()
        {
            _processing = "Çıkış Yapıldı";
            //Logs logout
            DateTime now = DateTime.Now;
            LogRecord(now, _processing, _description);
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");
            
        }

        //****************************Otels
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelAdd()
        {
            var countries = await context.Countries.ToListAsync();
            return View(countries);

        }
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> OtelAdd(string name,string location,decimal price,string description,byte stars,double rating,int countries,HttpPostedFileBase picture)
        {
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
                totalName = "../wwwroot/otelPicture/default.jpg";
            }
            

            context.Otels.Add(new Otel {
                OtelName = name,
                OtelLocation = location,
                OtelPrice = price,
                OtelDescription = description,
                OtelStars = stars,
                OtelRating = rating,
                OtelCountry = countries,
                OtelPicture = totalName
            });
            await context.SaveChangesAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Otel Kayıt Eklendi";
            _description = name;
            LogRecord(now,_processing,_description);

            return RedirectToAction("OtelAdd");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelList()
        {
            var list = await context.Otels.ToListAsync();

            //Log
            DateTime now = DateTime.Now;
            _processing = "Otel Listeleme İşlemi Yapıldı";
            LogRecord(now, _processing, _description);

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
            //Log
            DateTime now = DateTime.Now;
            _processing = "Otel Silme İşlemi Yapıldı.";
            LogRecord(now, _processing, _description);

            return RedirectToAction("OtelList");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelEdit(int? id)
        {
            var otel = await context.Otels.SingleOrDefaultAsync(a => a.OtelsId == id);
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
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> OtelEdit(int id, HttpPostedFileBase picture, Otel otel)
        {
            var entity = context.Otels.SingleOrDefault(a => a.OtelsId == id);
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
                totalName = entity.OtelPicture;
            }

            entity.OtelName = otel.OtelName;
            entity.OtelLocation = otel.OtelLocation;
            entity.OtelPrice = otel.OtelPrice;
            entity.OtelDescription = otel.OtelDescription;
            entity.OtelStars = otel.OtelStars;
            entity.OtelRating = otel.OtelRating;
            entity.OtelCountry = otel.OtelCountry;
            entity.OtelPicture = totalName;
            await context.SaveChangesAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Otel Düzenleme İşlemi Yapıldı";
            _description = otel.OtelName;
            LogRecord(now, _processing, _description);

            return RedirectToAction("OtelList");
        }

        //****************************Country

        [Authorize(Roles = ("Admin"))]
        public ActionResult CountryAdd()
        {
            return View();   
        }
        [Authorize(Roles = ("Admin"))]
        [HttpPost]
        public async Task<ActionResult> CountryAdd(string countryName )
        {
            context.Countries.Add(new Country
            {
                CountryName = countryName
            });
            await context.SaveChangesAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Şehir Ekleme İşlemi Yapıldı";
            _description = countryName;
            LogRecord(now, _processing, _description);

            return RedirectToAction("CountryAdd");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CountryDelete(int id)
        {

            var entity = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == id);
            _description = entity.CountryName;
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Şehir Silme İşlemi Yapıldı";
            LogRecord(now, _processing, _description);

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
        public async Task<ActionResult> CountryEdit(int id,Country country )
        {
            var entity = await context.Countries.SingleOrDefaultAsync(a => a.CountryId == id);
            entity.CountryName = country.CountryName;
            await context.SaveChangesAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Şehir Düzenleme İşlemi Yapıldı.";
            _description = entity.CountryName;
            LogRecord(now, _processing, _description);
            return RedirectToAction("CountryList");
        }
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> CountryList()
        {

            var list = await context.Countries.ToListAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Şehir Listeleme İşlemi Yapıldı";
            LogRecord(now, _processing, _description);
            return View(list);
        }

        //*********************Log

        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> LogRecords()
        {
            var list = await context.LogRecords.ToListAsync();
            //Log
            DateTime now = DateTime.Now;
            _processing = "Log Kayıtları Listelendi";
            LogRecord(now, _processing, _description);
            return View(list);
        }
        //Otel users
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelUsersList(string query)
        {
            var list = await context.OtelUsers.ToListAsync();
            //3 - OK    /   0 - Wait       / 1 - No
            if (query != null)
            {
                if (query == "Bekleyen Kayıtları Listele")
                {
                    var list0 = await context .OtelUsers.Where(a => a.OtelStatus == 0).ToListAsync();
                    //Log
                    DateTime now = DateTime.Now;
                    _processing = "Durumu Beklenen Otel Kullanıcıları Listelendi";
                    LogRecord(now, _processing, _description);

                    return View(list0);
                }else if(query == "1")
                {
                    var list1 = await context.OtelUsers.Where(a => a.OtelStatus == 1).ToListAsync();
                    return View(list1);
                }
                else if (query == "3")
                {
                    var list3 = await context.OtelUsers.Where(a => a.OtelStatus == 3).ToListAsync();
                    return View(list3);
                }else if (query == "Tüm Kayıtları Göster")
                {
                    //Log
                    DateTime now = DateTime.Now;
                    _processing = "Tüm Otel Kullanıcıları Listelendi";
                    LogRecord(now, _processing, _description);
                }
            }
            return View(list);


        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelAccept(int userid)
        {
            //Otel Permission 3 - OK    /   0 - Wait       / 1 - No
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == userid);
            user.OtelStatus = 3;
            user.Permission = "User";
            await context.SaveChangesAsync();

            //Log
            DateTime now = DateTime.Now;
            _processing = $"{user.OtelUserName} adlı otel kullanıcısının durmu Onaylandı.";
            LogRecord(now, _processing, _description);

            return RedirectToAction("OtelUsersList");
        }
        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async Task<ActionResult> OtelDeny(int userid)
        {
            //Otel Permission 3 - OK    /   0 - Wait       / 1 - No
            var user = await context.OtelUsers.SingleOrDefaultAsync(a => a.OtelUserId == userid);
            user.OtelStatus = 1;
            await context.SaveChangesAsync();

            //Log
            DateTime now = DateTime.Now;
            _processing = $"{user.OtelUserName} adlı otel kullanıcısının durmu Reddedildi.";
            LogRecord(now, _processing, _description);

            return RedirectToAction("OtelUsersList");
        }

        [HttpPost]
        [Authorize(Roles = ("Admin"))]
        public async  Task<ActionResult> OtelDenyDelete()
        {
            //Otel Permission 3 - OK    /   0 - Wait       / 1 - No
            var user = await context.OtelUsers.Where(a => a.OtelStatus == 1).ToListAsync();
            context.Entry(user).State = EntityState.Deleted;
            await context.SaveChangesAsync();

            //Log
            DateTime now = DateTime.Now;
            _processing = "Reddedilen tüm otel kulllanıcıları silindi.";
            LogRecord(now, _processing, _description);

            return RedirectToAction("OtelUsersList");
        }

    }
}