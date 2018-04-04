using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace burgershack {
  [Route ("api/[controller]")]
  public class BurgersController : Controller {
    private readonly BurgerRepository repo;
    private BurgerRepository _repo;

    public BurgersController (BurgerRepository repo) {
    
       _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Burger> Get () {
      return _repo.GetBurgers();
    }

    [HttpGet ("{id}")]
    public Burger Get (int id) {
      return _repo.GetById(id);
    }

    [HttpPost]
    public Burger AddBurger ([FromBody] Burger burger) {
      if (ModelState.IsValid) {
        return _repo.Add(burger);
      }
      return burger;
    }

    // [HttpDelete ("{id}")]
    // public IEnumerable<Burger> DeleteBurger ([FromBody] int id) {
      // if (ModelState.IsValid) {
      //   Burger burger = Burgers[id];
      //   Burgers.Remove (burger);
      // }
      // //       foreach(Burger burger in Burgers)
      // //       {
      // // return burger;
      // //       }
      // return Burgers;
    //}

    // [HttpPut ("{id}")]
    // public IEnumerable<Burger> Put (int id, [FromBody] Burger burger) {
      // if (id > -1 && id < Burgers.Count -1 && ModelState.IsValid) {
      //   Burgers.RemoveAt(id);
      //   Burgers.Insert(id, burger);
      //   Burgers.Add (burger);
      // }
      // return Burgers;
    //}
  }
}