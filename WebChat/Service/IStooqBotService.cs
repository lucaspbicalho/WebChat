using Microsoft.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebChat.Service
{
    public class StooqBotService
    {
        public StooqBotService()
        {

        }
        [HttpGet]
        public JsonResult GetStooq(string stock_code)
        {
            //using (var client = new HttpClient())
            //{
            //    var uri = new Uri("http://www.google.com/");

            //    var response = await client.GetAsync(uri);

            //    string textResult = await response.Content.ReadAsStringAsync();
            //}
            //return Json(new { status = "false", Msg = "CEP não pode ser vazio." });
            return new JsonResult() { Data = stock_code };
        }
    }
}