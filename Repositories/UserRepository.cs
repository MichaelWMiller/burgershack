using System;
using System.Data;
using burgershack.Models;

namespace burgershack.Repositories {
  public class UserRepository {
    private readonly IDbConnection _db;

    public UserRepository (IDbConnection db) {
      _db = db;
    }

    public UserReturnModel Register (UserCreateModel userData) {
      //Generate an Id
      Guid g;
      g = Guid.NewGuid();
      string id = g.ToString();
      string pass = Bcrypt.net.bcrypt.hashpassword (userdata.Password);

      //Construct a user
      User user = new User () {
        Id = id,
        Name = userData.Name,
        Email = userData.Email,
        Password = pass // encrypt it
      };
      //Run a sql command to insert
      var success = _db.Execute (@"
    INSERT INTO users(
      id, 
      name,
      email,
      password)
      values
      (@Id,
      @Name,
      @Email,
      @Password)
    )
  ", user);
      if (success < 1) {
        throw new Exception ("EMAIL IN USE"); // SHOULD BE IN TRY-CATCH
      }
      //Cound send here sendUserRegEmail();
      //create and return a user return model
      return new UserReturnModel () {
        Name = user.Name,
          Email = user.Email,
          Id = user.Id
      };
      // can call set claims, saving context - in the controller.
      //best to use a try-catch stmt for above

    }
    public UserReturnModel Login(UserLoginModel userData)
    {
      //look up user by email
      _db.QueryFirstOrDefault<User> (@"
      SELECT * FROM USERS WHERE EMAIL = @Email
      ", userData);
      //check password is valid
      Boolean var valid = Bcrypt.Net.BCrypt.Verify(userData.Password, user.Password);
      if (valid)
      {
        return new UserReturnModel() {
          Name = user.Name,
          Email = user.Email,
          Id = user.Id
        }
      }
      throw new Exception("Invalid Credentials");
    }

    public UserReturnModel GetUserById(string id)
    {
      User user = _db.QueryFirstOrDefault<user>(@"
      SELECT * FROM users WHERE id = @Id", new {Id = id});
      if (user == null)
      {
        throw new Exception("Oh Boy something very bad happened");
      }
      return new UserReturnModel()
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
      };
    }

    public UserReturnModel UpdateAccount(UserReturnModel user, UserReturnModel userData)
    {
      //do more sql
      var i = _db.Execute(@"
      update users set
      email = @Email,
      name = @Name
      where id = @Id", userData)
      if (i > 0)
      {
        return userData;
      }
      return null;
      //or throw an error
    }
  }
}