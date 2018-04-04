using System;
using System.Collections.Generic;
using burgershack.Interfaces;

namespace burgershack.Models {
  public interface IBurgerRepository {
    List<Burger> GetBurgers ();
    bool Add (Burger burger);
    Burger GetByID (int id);
    bool Update (Burger burger);
    bool Delete (Burger burger);
  }
}