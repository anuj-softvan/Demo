using Demo.Authors;
using Microsoft.AspNetCore.Mvc;
using System;
using Volo.Abp.AspNetCore.Mvc;

namespace Demo.Controllers
{
 
    public class HomeController : AbpController
    { 
        public ActionResult Index()
        {
            return Redirect("~/swagger");
        }                
    }
}
