﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DocumentationController : Controller
    {
        [ResponseCache(CacheProfileName = "Default")]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() =>
            {
                return View();
            });           
        }
    }
}