using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LokwaInnovation.DBContext;
using LokwaInnovation.Models;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;

namespace LokwaInnovation.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private Timer timer1;
        JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            CheckAdditionalContent = false
        };
        public ClientsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Contacts
        [Authorize]
        public IActionResult Dashboard()
        {
            var rolse = User.Identity.Name;
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            //LETS GET CLIENTS NAME
            var contacts = _context.Log_in
                .First(m => m.User_ID.ToString() == user_id);
            ViewBag.name = contacts.Full_name;
            HttpContext.Session.SetString("FullNames", contacts.Full_name);
            HttpContext.Session.SetString("PhoneNumber", contacts.Phone_number);
            HttpContext.Session.SetString("Roles", contacts.Roles.ToString());

            return View();
        }
        [Authorize]
        public async Task Execute(int timeoutInMilliseconds)
        {
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;

            await Task.Delay(timeoutInMilliseconds);

            var posts = _context.Mpesa_Status.Where(w => w.User_id==User.ToString()).ToList();
            int docCount = posts.Count();
            if (docCount > 0)
            {
                TempData["response"] = "Paid successfully!";
                Redirect("~/Clients/dashboard");


            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> makeRequest(String Phone, String Ammount)
        {
            var user_id = User.Claims.FirstOrDefault(c => c.Type == "User_id").Value;
            Random _random = new Random();

        // Generates a random number within a range.      
        
            int randomRef= _random.Next(1000000, 9999999);


            //Mpesa_Status insertTransStatus = new Mpesa_Status()
            //{
            //    User_id = user_id.ToString(),
            //    TransactionDate = DateTime.Now.ToString("MM/DD/YYYY"),
            //    ID = randomRef


            //};
            //_context.Add(insertTransStatus);
            string newPhone = Phone.Substring(1);
            string newPhoneWith254 = "254" + newPhone;
            string url = "http://fuelaholdings-002-site28.itempurl.com/SIMULATE.PHP?phone=" + newPhoneWith254 + "&ammount=" + Ammount + "&user_id=" + user_id+ "&transID=" + randomRef;
            using (HttpClient client = new HttpClient())
            {
              
                await client.GetStringAsync(url.ToString());
                await Execute(1000);
                //return Content(url);
                var result = await client.GetAsync(url);
                string res = await result.Content.ReadAsStringAsync();
                if (res.Contains("errorCode") == true)
                {
                    if (res.Contains("Invalid") == true)
                    {
                        TempData["response"] = "Invalid phone number! please use phone number registered with M-PESA!";
                    }
                    else
                    {
                        TempData["response"] = " The mpesa request was not successful!";
                    }
                    //    dynamic stuff = JObject.Parse(res);
                    //string name = stuff.ResultDesc;
                }
                else
                {
                    TempData["response"] = "The request has been sent to your phone please confirm the request to  complete the payment.";

                }
                await Task.Delay(7000);
                var posts = _context.Mpesa_Status.Where(w => w.User_id == user_id.ToString()).ToList();
                var address = _context.Mpesa_Status.FirstOrDefault(a => a.User_id == user_id.ToString()&& a.Transaction_status==false);
                int docCount = posts.Count();
                if (docCount > 0)
                {
                    float ammount_paid = float.Parse(address.Ammount.ToString());
                    if (ammount_paid <= 0)
                    {
                        var renderUseless = _context.Mpesa_Status.SingleOrDefault(b => b.User_id == user_id.ToString() && b.Transaction_status == false);
                        renderUseless.Transaction_status = true;
                        _context.Add(renderUseless);
                        _context.Entry(renderUseless).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        var checkBal = _context.Access_Tokens.FirstOrDefault(a => a.User_id == user_id.ToString());

                    }
                    TempData["response"] = address.ResultDesc;
                    Redirect("~/Clients/dashboard");

                }
                return Redirect("~/Clients/dashboard");

            }
        }


    }
    public class RootObject
    {
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public string CustomerMessage { get; set; }
        public string ResultCode { get; set; }
        public string ResultDesc { get; set; }
    }

}