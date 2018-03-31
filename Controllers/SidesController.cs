using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack {
  [Route ("api/[controller]")]
  public class SidesController : Controller {
    List<Side> Sides { get; set; }
    public SidesController () {
      Sides = new List<Side> () {
        new Side ("Egg Salad", "Nummy nummy Eggs!  In a Salad!", 1.50, 180, "Eggs and Salad"),
        new Side ("Cottage Cheese", "White curds", 2.75, 50, "curdled cow"),
        new Side ("Fries", "Krispy krunchy", 2.00, 550, "Potatoes"),
        new Side ("Onion Rings", "Rich battered and DFd Onion Rings", 5.00, 800, "Onions and rings")
      };
    }

    [HttpGet]
    public IEnumerable<Side> Get () {
      return Sides;
    }

    [HttpGet ("{id}")]
    public Side Get (int id) {
      return id > -1 && id < Sides.Count - 1 ? Sides[id] : null;
    }

    [HttpPost]
    public IEnumerable<Side> AddSide ([FromBody] Side side) {
      if (ModelState.IsValid) {
        Sides.Add (side);
      }
      return Sides;
    }

    [HttpDelete ("{id}")]
    public IEnumerable<Side> DeleteSide ([FromBody] int id) {
      if (ModelState.IsValid) {
        Side side = Sides[id];
        Sides.Remove (side);
      }
      return Sides;
    }

         [HttpPut ("{id}")]
    public IEnumerable<Side> Put (int id, [FromBody] Side side) {
      if (id > -1 && id < Sides.Count -1 && ModelState.IsValid) {
        Sides.RemoveAt(id);
        Sides.Insert(id, side);
        Sides.Add (side);
      }
      return Sides;
    }
  }
}