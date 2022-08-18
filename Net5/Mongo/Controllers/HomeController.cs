using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mongo.Models;
using Mongo.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mongo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Personel> _personelRepository;
        public HomeController(ILogger<HomeController> logger, IRepository<Personel> personelRepository)
        {
            _logger = logger;
            _personelRepository = personelRepository;
        }

        public IActionResult Index()
        {
            var result = _personelRepository.InsertOne(new Personel
            {
                Id=1,
                Name = "aa",
                Surname = "aa",
                Age = 27,
                Title = "aa"
            });
            var result2 = _personelRepository.InsertOneAsync(new Personel
            {
                Id =2,
                Name = "aa",
                Surname = "aa",
                Age = 27,
                Title = "aa"
            });
            return View();
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
        //public IActionResult Create()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            
            return View();
        }
    }
}
