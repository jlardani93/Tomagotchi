using System;
using Microsoft.AspNetCore.Mvc;

namespace TomagotchiProject.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
