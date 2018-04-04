using System;
using System.Collections.Generic;
using System.threading.task;

namespace burgershack.Controllers {
  [Route ("[controller]")]
  public class AccountController : Controllers {
    private readonly UserRepository _repo;

    public AccountController (UserRepository db) {
      _repo = repo;

    }

    [HttpPost ("register")]
    public async Task<UserReturnModel> Register ([FromBody] UserCreateModel userData) {
      if (ModelState.IsValid) {
        try {
          userReturnModel user = _repo.Register (userData);
          ClaimsPrincipal principal = user.SetClaims ();
          await HttpContext.SignInAsync (principal);
          return user;
        } catch (Exceoption e) {
          System.Console.WriteLine (e.Message);
        }
      }
      return null;
    }

    [HttPost ("login")]
    public async Task<UserReturnModel> Login ([FromBody] UserLoginModel userData) {
      if (!ModelState.IsValid) {
        return null;
      }
      try {
        UserReturnModel user = _repo.Login (userData);
        var principal = user.SetClaims ();
        await HttpContext.SignInAsync (principal);
        return user;
      } catch (Exception e) {
        System.Console.WriteLine (e.Message);
      }
    }

    public UserReturnModel Login (UserLoginModel userData) {
      throw new NotImplementedException (exception e);
    }

    [HttpDelete ("logout")]

    public async Task<string> Logout () {
      await HttpContext.SignOutAsync ();
      return "successfully logged out";
    }

    [Authorize]
    [HttpPut]
    public UserReturnModel UpdateAccount ([FromBody] UserReturnModel userData) {
      var id = HttpContext.User.Claims.Where (c => c.Type == ClaimTypes.Name)
        .Select (c => c.Value).SingleOrDefault ();
      _repo.GetUserById (id);
      UserReturnModel user = _repo.GetUserById (id);
      return _repo.UpdateAccount (user, userData);

    }

    //Add ChangeUserPassword

    //Add [Authorize] [HttpPut("change-password")] and public string ChangePassword method here
  }
}