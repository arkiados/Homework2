﻿using Homework2.Models;
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

        public class Contact
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Phone { get; set; }
        }

        public string IdSort { get; set; }
        public string NameSort { get; set; }
        public string CitySort { get; set; }
        public string StateSort { get; set; }
        public string PhoneSort { get; set; }

        public IList<Contact> Contacts { get; set; }

        public IActionResult Index(string sortOrder)
        {

            List<Contact> contacts = new List<Contact>()
            {
                new Contact{Id = 1, Name="dave", City="Seattle", State="WA", Phone="123"},
                new Contact{Id = 2, Name="mike", City="Spokane", State="WA", Phone="234"},
                new Contact{Id = 3, Name="lisa", City="San Jose", State="CA", Phone="345"},
                new Contact{Id = 4, Name="cathy", City="Dallas", State="TX", Phone="456"},
            };

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
                            contacts = (List<Contact>)Contacts.OrderByDescending(s => s.Id);
                            break;
                        }
                    case "name":
                        {
                            contacts = (List<Contact>)Contacts.OrderByDescending(s => s.Name);
                            break;
                        }
                    case "city":
                        {
                            contacts = (List<Contact>)Contacts.OrderByDescending(s => s.City);
                            break;
                        }
                    case "state":
                        {
                            contacts = (List<Contact>)Contacts.OrderByDescending(s => s.State);
                            break;
                        }
                    case "phone":
                        {
                            contacts = (List<Contact>)Contacts.OrderByDescending(s => s.Phone);
                            break;
                        }
                    default:
                        contacts = (List<Contact>)Contacts.OrderBy(s => s.Id);
                        break;
                }
            }

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