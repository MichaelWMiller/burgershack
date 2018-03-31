using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack {
  [Route ("api/[controller]")]
  public class BurgersController : Controller {
    List<Burger> Burgers { get; set; }
    public BurgersController () {
      Burgers = new List<Burger> () {
        new Burger ("The Aloha Burger", "Tasty meat with Pineapple (taste the island)", 11.99, 2200, "stuff n things with pineapple of course"),
        new Burger ("The BBQ Brittany", "tasty meat with BBQ Sauce.... its a secret", 15.74, 2100, "stuff n thing with BBQ sauce"),
        new Burger ("The Veg", "dont worry its gross", 2.99, 15, "lettuce mostly")
      };
    }

    [HttpGet]
    public IEnumerable<Burger> Get () {
      return Burgers;
    }

    [HttpGet ("{id}")]
    public Burger Get (int id) {
      return id > -1 && id < Burgers.Count - 1 ? Burgers[id] : null;
    }

    [HttpPost]
    public IEnumerable<Burger> AddBurger ([FromBody] Burger burger) {
      if (ModelState.IsValid) {
        Burgers.Add (burger);
      }
      return Burgers;
    }

    [HttpDelete ("{id}")]
    public IEnumerable<Burger> DeleteBurger ([FromBody] int id) {
      if (ModelState.IsValid) {
        Burger burger = Burgers[id];
        Burgers.Remove (burger);
      }
      //       foreach(Burger burger in Burgers)
      //       {
      // return burger;
      //       }
      return Burgers;
    }

    [HttpPut ("{id}")]
    public IEnumerable<Burger> Put (int id, [FromBody] Burger burger) {
      if (id > -1 && id < Burgers.Count -1 && ModelState.IsValid) {
        Burgers.RemoveAt(id);
        Burgers.Insert(id, burger);
        Burgers.Add (burger);
      }
      return Burgers;
    }
  }
}