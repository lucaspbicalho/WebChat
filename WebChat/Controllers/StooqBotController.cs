using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class StooqBotController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> GetStooq(string stock_code)
        {
            string textResult;
            using (var client = new HttpClient())
            {
                string Url = "https://stooq.com/q/l/?s=" + stock_code;
                Url += "&f=sd2t2ohlcv&h&e=csv";
                var uri = new Uri(Url);

                var response = await client.GetAsync(uri);

                textResult = await response.Content.ReadAsStringAsync();
            }
            textResult = textResult.Remove(textResult.LastIndexOf(','));
            textResult = textResult.Substring(textResult.LastIndexOf(',') + 1);
            return Json(stock_code + " quote is $" + textResult + " per share", JsonRequestBehavior.AllowGet);
        }
    }
}