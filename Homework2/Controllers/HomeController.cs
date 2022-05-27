using Homework2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Homework2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string IdSort { get; set; }
        public string NameSort { get; set; }
        public string CitySort { get; set; }
        public string StateSort { get; set; }
        public string PhoneSort { get; set; }

        public List<Contact> Contacts { get; set; }

        public IActionResult Index(string sortOrder)
        {

            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact() { Id = 1, Name = "dave", City = "Seattle", State = "WA", Phone = "123" });
            contacts.Add(new Contact() { Id = 2, Name = "mike", City = "Spokane", State = "WA", Phone = "234" });
            contacts.Add(new Contact() { Id = 3, Name = "lisa", City = "San Jose", State = "CA", Phone = "345" });
            contacts.Add(new Contact() { Id = 4, Name = "cathy", City = "Dallas", State = "TX", Phone = "456" });


            IdSort = String.IsNullOrEmpty(sortOrder) ? "id" : "";
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            CitySort = String.IsNullOrEmpty(sortOrder) ? "city" : "";
            StateSort = String.IsNullOrEmpty(sortOrder) ? "state" : "";
            PhoneSort = String.IsNullOrEmpty(sortOrder) ? "phone" : "";

            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "id":
                        {
                            contacts = contacts.OrderByDescending(s => s.Name).ToList();
                            break;
                        }
                    case "name":
                        {
                            contacts = contacts.OrderByDescending(s => s.Name).ToList();
                            break;
                        }
                    case "city":
                        {
                            contacts = contacts.OrderByDescending(s => s.City).ToList();
                            break;
                        }
                    case "state":
                        {
                            contacts = contacts.OrderByDescending(s => s.State).ToList();
                            break;
                        }
                    case "phone":
                        {
                            contacts = contacts.OrderByDescending(s => s.Phone).ToList();
                            break;
                        }
                    default:
                        contacts = contacts.OrderBy(s => s.Id).ToList();
                        break;
                }
            }
            Contacts = contacts;
            return View(this);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}