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
        private readonly IRepository<PersonelDetail> _personelDetailRepository;
        private readonly IRepository<Company> _companyRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<Personel> personelRepository, IRepository<PersonelDetail> personelDetailRepository, IRepository<Company> companyRepository)
        {
            _logger = logger;
            _personelRepository = personelRepository;
            _personelDetailRepository = personelDetailRepository;
            _personelDetailRepository = personelDetailRepository;
            _companyRepository = companyRepository;
        }

        public IActionResult Index()
        {
            var result = _personelRepository.InsertOne(new Personel
            {
                Id = 10,
                Name = "aa",
                Surname = "aa",
                PersonelDetailId = 3,
            });
            var result2 = _personelDetailRepository.InsertOne(new PersonelDetail
            {
                Id = 3,
                Email = "aaa",
                PhoneNumber="123",
                Age=111,
                Title=".",
                JobDescription=".",
                PersonelId=10,
            });
            var result3 = _personelRepository.InsertOne(new Personel
            {
                Id = 11,
                Name = "bb",
                Surname = "bb",
                PersonelDetail = new PersonelDetail{
                    Id=5,
                    Email = "bb",
                    PhoneNumber = "123",
                    Age = 111,
                    Title = ".",
                    JobDescription = ".",
                    PersonelId = 11,
                }
            });
            var result4 = _personelRepository.InsertOne(new Personel
            {
                Id = 12,
                Name = "bb",
                Surname = "bb",
                PersonelDetail = new PersonelDetail
                {
                    Id = 6,
                    Email = "bb",
                    PhoneNumber = "123",
                    Age = 111,
                    Title = ".",
                    JobDescription = ".",
                    PersonelId = 12,
                },
                Company = new Company
                {
                    Id=1,
                    Name="a",
                    Count=2,
                    Category="a",
                }
            });
            var result5 = _companyRepository.InsertOne(new Company
            {
                Id = 12,
                Name = "bb",
                Count=1,
                //Personels=new List<Personel>
                //{
                //    Id = 6,
                //    Email = "bb",
                //    PhoneNumber = "123",
                //    Age = 111,
                //    Title = ".",
                //    JobDescription = ".",
                //    PersonelId = 12,
                //},
                //Company = new Company
                //{
                //    Id = 1,
                //    Name = "a",
                //    Count = 2,
                //    Category = "a",
                //}
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
