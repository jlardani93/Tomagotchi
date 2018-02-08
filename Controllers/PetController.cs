using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TomagotchiProject.Models;

namespace TomagotchiProject.Controllers
{
  public class PetController : Controller
  {
    [HttpPost("Pet/Create")]
    public ActionResult Create()
    {
      Farm myFarm = new Farm();
      myFarm.SetName(Request.Form["farm-name"]);
      myFarm.SetInitPets(Request.Form["petNum"]);
      myFarm.Save();
      Pet.TakeHealth();
      return View(myFarm);
    }

    [HttpGet("Pet/Info/{id}")]
    public ActionResult Info(int id)
    {
      Pet myPet = Pet.Find(id);
      Pet.TakeHealth();
      return View(myPet);
    }

    [HttpGet("Pet/Feed/{id}")]
    public ActionResult Feed(int id)
    {
      Pet myPet = Pet.Find(id);
      myPet.Feed();
      return RedirectToAction("Info");
    }

    [HttpGet("Pet/Rest/{id}")]
    public ActionResult Rest(int id)
    {
      Pet myPet = Pet.Find(id);
      myPet.Rest();
      return RedirectToAction("Info");
    }
  }
}
