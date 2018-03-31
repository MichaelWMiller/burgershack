using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burger_shack {
  [Route ("api/[controller]")]
  public class DrinksController : Controller {
    List<Drink> Drinks { get; set; }
    public DrinksController () {
      Drinks = new List<Drink> () {
        new Drink ("Pepsi", "Brown liquid wid bubbles", 3.00, 3200, "brown and bubbles and liquid"),
        new Drink ("Mt Dew", "Yellow liquid wid bubbles--ew", 3.00, 3050, "dont even wanna know"),
        new Drink ("Coffe", "Brown liquid bubbles not so much", 2.50, 0, "brown and liquid"),
        new Drink ("Milk", "White liquid bubbles sometimes", 2.00, 50, "Cow squeezins")
      };
    }

    [HttpGet]
    public IEnumerable<Drink> Get () {
      return Drinks;
    }

    [HttpGet ("{id}")]
    public Drink Get (int id) {
      return id > -1 && id < Drinks.Count - 1 ? Drinks[id] : null;
    }

    [HttpPost]
    public IEnumerable<Drink> AddDrink ([FromBody] Drink drink) {
      if (ModelState.IsValid) {
        Drinks.Add (drink);
      }
      return Drinks;
    }

    [HttpDelete ("{id}")]
    public IEnumerable<Drink> DeleteDrink ([FromBody] int id) {
      if (ModelState.IsValid) {
        Drink drink = Drinks[id];
        Drinks.Remove (drink);
      }
      return Drinks;
    }
    public IEnumerable<Drink> EditDrink ([FromBody] int id) {
      if (ModelState.IsValid) {
        Drink drink = Drinks[id];
        Drinks.Add (drink);
      }
      return Drinks;
    }
        [HttpPut ("{id}")]
    public IEnumerable<Drink> Put (int id, [FromBody] Drink drink) {
      if (id > -1 && id < Drinks.Count -1 && ModelState.IsValid) {
        Drinks.RemoveAt(id);
        Drinks.Insert(id, drink);
        Drinks.Add (drink);
      }
      return Drinks;
    }

  }
}