using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AthabascaAssesmentTest.Models;
using Newtonsoft.Json;


namespace AthabascaAssesmentTest.Controllers
{
    public class DisplayCluesController : Controller
    {
        string Baseurl = "http://jservice.io/";
        // GET: DisplayClues
        public ActionResult Index()
        {
            return View();
        }

  

        

        public async Task<ActionResult> GetRandom()
        {
            List<ClueData> clueInfo = new List<ClueData>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/random");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ClueResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    clueInfo = JsonConvert.DeserializeObject<List<ClueData>>(ClueResponse);

                }
                //returning the employee list to view  
                //return View(EmpInfo);

                return PartialView("GetRandom", clueInfo);
            }
        }

        public async Task<ActionResult> period(String toDate, String fromDate)
        {
            List<PeriodClues> clueInfo = new List<PeriodClues>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/clues?min_date="+fromDate+"&max_date="+toDate);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ClueResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    clueInfo = JsonConvert.DeserializeObject<List<PeriodClues>>(ClueResponse);

                }
                //returning the employee list to view  
                //return View(EmpInfo);

                return PartialView("PeriodClues", clueInfo);
            }
        }

        public async Task<ActionResult> Category( int id)
        {
            //  List<Category> clueInfo = new List<Category>();
            List<RootObject> cluess = new List<RootObject>();
            RootObject category = new RootObject();
            category.clues = new List<Clue>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/category?id=" + id);
                Debug.WriteLine("My debug string here");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ClueResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    category = JsonConvert.DeserializeObject<RootObject>(ClueResponse);
                    cluess.Add(category);
                }

                /*foreach(var a in category.clues)
                {
                    Debug.WriteLine( + a.question.ToString());
                }
                */

                                // return View();
                return PartialView("Category", cluess);
            }
        }
    }
}