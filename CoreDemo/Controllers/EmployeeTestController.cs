using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44365/api/Default");
            var jsonstring = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<class1>>(jsonstring);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44365/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44365/api/Default" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<class1>(jsonEmployee);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44365/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44365/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public class class1
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }




    }

}
