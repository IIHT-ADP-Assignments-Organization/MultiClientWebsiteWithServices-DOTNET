﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MultiClientWebsiteWithServices.Controllers
{
    public class MerchantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}