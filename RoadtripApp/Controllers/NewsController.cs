using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoadtripApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository repo;

        public NewsController(INewsRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult News()
        {
            var news = repo.GetAllNews();

            return View(news);
        }
    }
}
