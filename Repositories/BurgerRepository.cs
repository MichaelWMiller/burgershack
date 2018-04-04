using System.Collections.Generic;
using System.Data;
using burgershack.Models;

using Dapper;

namespace burgershack.Repositories {
  public class BurgerRepository {
    //crud methods
    private readonly IDbConnection _db;
    public BurgerRepository (IDbConnection db) {
      _db = db;

    }

    //CREATEONE
    public Burger Add (Burger burger) {
      int id = _db.ExecuteScalar<int> (@"insert into 
      mindfulmoose.burgers (name, description, price, kcal)
      values((
        @name, @Description, @Price, @KCal)", burger);
      burger.Id = id;
      return burger;
    }

    public Burger GetById (int id) {
      return _db.QueryFirstOrDefault<Burger> (@"
      SELECT * FROM burgers where id = @Id", new{Id = id});
    }

    public IEnumerable<Burger> GetBurgers () {
      return _db.Query<Burger> (@"
      SELECT * FROM BURGERS");
    }
    //you figure - Update

    

    public Burger Update (Burger burger) {
      string updateQuery = "UPDATE EMPLOYEE SET NAME = @Name WHERE Id = @Id";
      int count = _db.Execute(updateQuery,new {
        burger.Name,
        burger.Id
      });  
      return burger;

    }
    //you figure
    // public Burger Delete (int Id) {
    //   _db

    //  }

    //read: findone, findall, findmany
    //update: editone
    //createone
    //deleteone
  }
}