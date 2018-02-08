using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TomagotchiProject.Models;

namespace TomagotchiProject.Controllers
{
  public class FarmController : Controller
  {
    [HttpGet("Farm/Create")]
    public ActionResult Create()
    {
      Pet.TakeHealth();
      return View();
    }

    [HttpPost("Farm/CreatePets")]
    public ActionResult CreatePets()
    {
      int myNumPets = Int32.Parse(Request.Form["petsNum"]);
      List<Pet> myPets = new List<Pet>();
      Farm myFarm = Farm.Find(Int32.Parse(Request.Form["FarmId"]));
      for (int i = 1; i <= myNumPets; i++)
      {
        Pet myPet = new Pet();
        myPet.SetName(Request.Form["name"+i.ToString()]);
        myPet.SetGender(Request.Form["gender"+i.ToString()]);
        myPet.SetColor(Request.Form["color"+i.ToString()]);
        myPet.Save();
        myPets.Add(myPet);
        myPet.SetLocalId(myPets.Count);
      }
      myFarm.SetPets(myPets);
      Pet.TakeHealth();
      return View("Info", myFarm);
    }

    [HttpGet("Farm/Display")]
    public ActionResult Display()
    {
      Pet.TakeHealth();
      return View(Farm.GetAllFarms());
    }

    [HttpGet("Farm/Info/{id}")]
    public ActionResult Info(int id)
    {
      Farm myFarm = Farm.Find(id);
      Pet.TakeHealth();
      return View("Info", myFarm);
    }
  }
}
