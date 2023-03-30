using ListPeoplePost.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListPeoplePost.Data;
using System.Dynamic;

namespace ListPeoplePost.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            "Data Source=.\\sqlexpress;Initial Catalog=ListPeoplePost;Integrated Security=true;";


        public IActionResult Index()
        {
            var mgr = new PersonManager(_connectionString);
            var vm = new HomePageViewModel
            {
                People = mgr.GetPeople(),
            };

            if (TempData["success-message"] != null)
            {
                //vm.Message = (string)TempData["success-message"];
                ViewBag.Message = (string)TempData["success-message"];
            }

            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            var mgr = new PersonManager(_connectionString);
            var peopleToAdd =
                people.Where(p => !String.IsNullOrEmpty(p.FirstName) && !String.IsNullOrEmpty(p.LastName)).ToList();

            mgr.AddPeople(peopleToAdd);
            TempData["success-message"] = $"{peopleToAdd.Count} people added successfully!";
            return Redirect("/home/index");
        }

        public IActionResult AddSingle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSingle(Person person)
        {
            var mgr = new PersonManager(_connectionString);
            mgr.AddPerson(person);
            ViewBag.Message = "Person added successfully";
            return View();
        }
    }
}
