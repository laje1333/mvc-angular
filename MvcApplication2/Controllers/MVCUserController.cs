﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class MVCUserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}