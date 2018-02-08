using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TomagotchiProject.Models
{
  public class Pet
  {
    private string _name;
    private int _health = 100;
    private string _gender;
    private string _color;
    private int _localId;
    private int _allPetsId;
    private int _parentFarm;

    private static List<Pet> _allPets = new List<Pet>();

    public void SetName(string name)
    {
      _name = name;
    }

    public void SetGender(string gender)
    {
      _gender = gender;
    }

    public void SetColor(string color)
    {
      _color = color;
    }

    public void ChangeHealth(int healthChange)
    {
      _health += healthChange;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetGender()
    {
      return _gender;
    }

    public string GetColor()
    {
      return _color;
    }

    public int GetHealth()
    {
      return _health;
    }

    public void SetLocalId(int id)
    {
      _localId = id;
    }

    public int GetLocalId()
    {
      return _localId;
    }

    public void SetAllPetsId(int id)
    {
      _allPetsId = id;
    }

    public int GetAllPetsId()
    {
      return _allPetsId;
    }

    public void SetParentFarm(int parentFarm)
    {
      _parentFarm = parentFarm;
    }

    public int GetParentFarm()
    {
      return _parentFarm;
    }

    public void Save()
    {
      _allPets.Add(this);
      _allPetsId = _allPets.Count;
    }

    public void Feed()
    {
      _health += 15;
      if (_health > 100)
      {
        _health = 100;
      }
    }

    public void Rest()
    {
      _health += 10;
      if (_health > 100)
      {
        _health = 100;
      }
    }

    public static void TakeHealth()
    {
      foreach(Pet pet in _allPets)
      {
        pet._health -= 1;
        if (pet._health <= 0)
        {
          pet._health = 0;
        }
      }
    }
    public static Pet Find(int searchId)
    {
      return _allPets[searchId - 1];
    }

    public static List<Pet> GetAllPets()
    {
      return _allPets;
    }

    public static void ClearPets()
    {
      _allPets.Clear();
    }
  }
}
