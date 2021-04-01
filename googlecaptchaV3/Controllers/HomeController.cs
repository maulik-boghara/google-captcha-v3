using GoogleCaptchaV3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace googlecaptchaV3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            GoogleCaptcha googleCaptcha = ValidateCaptcha(model.CaptchaToken);

            return Json(new { googleCaptcha }, JsonRequestBehavior.AllowGet);
        }

        public static GoogleCaptcha ValidateCaptcha(string token)
        {
            var secretKey = ConfigurationManager.AppSettings["GoogleCaptchaSecretKey"]; //secret key
            var url = $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}"; // url

            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync(url).Result;
            if (res.StatusCode != HttpStatusCode.OK)
                return null;

            //response
            string response = res.Content.ReadAsStringAsync().Result;

            if (string.IsNullOrWhiteSpace(response)) return null;

            GoogleCaptcha googleCaptcha = JsonConvert.DeserializeObject<GoogleCaptcha>(response);

            return googleCaptcha;
            
        }
    }
}