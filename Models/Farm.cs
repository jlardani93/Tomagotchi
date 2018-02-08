using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TomagotchiProject.Models;

namespace TomagotchiProject.Models
{
  public class Farm
  {
    private string _name;
    private int _initPets;
    private int _id;
    private List<Pet> _pets;

    private static List<Farm> _allFarms = new List<Farm>();

    public void SetName(string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetInitPets(string initPets)
    {
      _initPets = Int32.Parse(initPets);
    }

    public int GetInitPets()
    {
      return _initPets;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetPets(List<Pet> pets)
    {
      _pets = pets;
      int parentFarm = _id;
      foreach(Pet p in _pets)
      {
        p.SetParentFarm(parentFarm);
      }
    }

    public List<Pet> GetPets()
    {
      return _pets;
    }

    public void Save()
    {
      _allFarms.Add(this);
      _id = _allFarms.Count;
    }

    public static Farm Find(int searchId)
    {
      return _allFarms[searchId - 1];
    }

    public static List<Farm> GetAllFarms()
    {
      return _allFarms;
    }


  }
}
