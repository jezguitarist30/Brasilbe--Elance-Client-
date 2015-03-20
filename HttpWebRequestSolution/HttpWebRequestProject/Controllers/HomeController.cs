using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HttpWebRequestProject.Models;
using Newtonsoft.Json;

namespace HttpWebRequestProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var postData = new Dictionary<string, string>();

            //postData.Add("__VIEWSTATE", "");
            //postData.Add("ctl00$ucContent$cntrlLogin$btnLogin", "");
            //postData.Add("ctl00$ucContent$cntrlLogin$txtBoxLogin", "34234sdsdfdsfada@yahoo.com");
            //postData.Add("ctl00$ucContent$cntrlLogin$txtBoxPassword", "password");
            //postData.Add(" ctl00$ucContent$cntrlLogin$chkBoxRememberMe", "");

            //return Redirect(HttpPostRequestLogin("https://www.amolatina.com/Pages/Security/Login.aspx", postData));

            //var model = new UserModel()
            //{
            //    Email = "12345jezreel@yahoo.com",
            //    Password = "password"
            //};

            return View();            
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            var postData = new Dictionary<string, string>();

            postData.Add("first-name", model.FirstName);
            postData.Add("last-name", model.LastName);
            postData.Add("day", "26");
            postData.Add("month", "8");
            postData.Add("year", "1990");
            postData.Add("country", "46");
            postData.Add("email", model.Email);
            postData.Add("password", model.Password);
            postData.Add("afid", "516978");
            postData.Add("subafid", "face");
            
            var responseModel = HttpPostRequestRegister("https://www.amolatina.com/member/register/?source=amolatina.com&motivation=&afid=&subafid=&current-language=&transaction-id=&offer-id=", postData);

            if (responseModel.id > 0)
            {
                return
                    Redirect("https://www.amolatina.com/login.html?userID=" + responseModel.id + "&pwd=" +
                             responseModel.password + "&ReturnUrl=%2Flogin%2Fpages%2Fhome.aspx&newbie=1");
            }

            return View("Index");
        }

        public ActionResult Login(LoginModel data)
        {          
            return View(data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            //var postData = new Dictionary<string, string>();

            //postData.Add("__VIEWSTATE", "");
            //postData.Add("ctl00$ucContent$cntrlLogin$btnLogin", "");
            //postData.Add("ctl00$ucContent$cntrlLogin$txtBoxLogin", model.Email);
            //postData.Add("ctl00$ucContent$cntrlLogin$txtBoxPassword", model.Password);
            //postData.Add("ctl00$ucContent$cntrlLogin$chkBoxRememberMe", "");


            //HttpPostRequestLogin("https://www.amolatina.com/Pages/Security/Login.aspx", postData);
            ////GetAuthCookie(new Uri("https://www.amolatina.com/Pages/Security/Login.aspx"), postData);
            ////return Redirect("https://www.amolatina.com");

            return
                   Redirect("https://www.amolatina.com/login.html?userID=16926686&pwd=password&ReturnUrl=%2Flogin%2Fpages%2Fhome.aspx&newbie=1");
            
        }

        private ResponseModel HttpPostRequestRegister(string url, Dictionary<string, string> postParameters)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                string postData = "";
                string result = "";

                foreach (string key in postParameters.Keys)
                {
                    postData += HttpUtility.UrlEncode(key) + "="
                                + HttpUtility.UrlEncode(postParameters[key]) + "&";
                }

                postData = postData.Remove(postData.LastIndexOf('&'));


                CookieCollection cookies = new CookieCollection();
                HttpWebRequest Cookiesrequest = (HttpWebRequest)WebRequest.Create("https://www.amolatina.com/Pages/Security/Register.aspx");
                Cookiesrequest.CookieContainer = new CookieContainer();
                Cookiesrequest.CookieContainer.Add(cookies);
                //Get the response from the server and save the cookies from the first request..
                HttpWebResponse Cookiesresponse = (HttpWebResponse)Cookiesrequest.GetResponse();
                cookies = Cookiesresponse.Cookies;


                // Create a request using a URL that can receive a post. 
                HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(url);

                // Create Cookie Container
                getRequest.CookieContainer = new CookieContainer();
                // Add site cookie to the Container
                getRequest.CookieContainer.Add(cookies); //recover cookies First request
                // Set the Method property of the request to POST.
                getRequest.Method = WebRequestMethods.Http.Post;
                getRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                getRequest.AllowWriteStreamBuffering = true;
                getRequest.ProtocolVersion = HttpVersion.Version11;
                getRequest.AllowAutoRedirect = true;
                // Set the ContentType property of the WebRequest.
                getRequest.ContentType = "application/x-www-form-urlencoded";
                // Create POST data and convert it to a byte array.        
                byte[] byteArray = Encoding.ASCII.GetBytes(postData);
                // Set the ContentLength property of the WebRequest.
                getRequest.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream newStream = getRequest.GetRequestStream(); //open connection
                // Write the data to the request stream.
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                // Clean up the streams.
                newStream.Close();

                HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();

                using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }


              

                if (!string.IsNullOrEmpty(result))
                {
                    model = JsonConvert.DeserializeObject<ResponseModel>(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


            return model;
        }

    }
}