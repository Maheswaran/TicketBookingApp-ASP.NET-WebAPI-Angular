using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TicketBookingApp.Models;

namespace TicketBookingApp.Controllers
{
    public class UserController : Controller
    {

        string Baseurl = "http://localhost:61";

        // GET: User
        public async Task<ActionResult> Index()
        {
            List<User> lstUser = new List<User>();

            try
            {
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/Users/");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        lstUser = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                    }                  
                }
            }
            catch (Exception ex)
            {

            }  

            //returning the employee list to view  
            return View(lstUser);               
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User objUser = null;
            try
            {
                objUser = await GetUserDetail(id, objUser);
            }
            catch (Exception ex)
            { }
        
            return View(objUser);
        }

        private async Task<User> GetUserDetail(int id, User objUser)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(string.Format("api/Users/{0}", id));

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    objUser = JsonConvert.DeserializeObject<User>(EmpResponse);
                }

            }

            return objUser;
        }

        // GET: User/Create
        [HttpGet()]
        public ActionResult Create()
        {
            User usr = new User();
            return View("Create", usr);
        }

        // POST: User/Create
        [HttpPost]
        [HandleError]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                // TODO: Add insert logic here

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    
                    HttpResponseMessage responseMessage = await client.PostAsync("api/Users", 
                            new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json"));

                    if (!responseMessage.IsSuccessStatusCode)
                    {
                        string errorMessage = responseMessage.Content.ReadAsStringAsync().Result;
                        throw new Exception(errorMessage);
                    }

                   return RedirectToAction("Index");
                }                            
            }
            catch(Exception ex)
            {
                throw ex;
                //return View("Error", ex);
            }
          
        }

        // GET: User/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            User objUser = null;            
            try
            {
                objUser = await GetUserDetail(id, objUser);
            }
            catch (Exception ex)
            { }

            return View(objUser);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
