using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models {
  public class User {

    [Key]
    [Required]
    public string Id { get; set; }
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength (4)]
    public string Password { get; set; }

  }
  public class UserCreateModel {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength (4)]
    public string Password { get; set; }
  }
  public class UserLoginModel
  {
        [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength (4)]
    public string Password { get; set; }


  }

  public class UserReturnModel 
  {
       [Required]
    public string Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Name { get; set; }

//How microsoft handles login retention. Will be saved into httpcontext.
//Context comes from the controller.
//setting up session tokens AKA Claims for auto login
    public ClaimsPrincipal SetClaims ()
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email, Email), //hashes the email
        new Claim(ClaimTypes.Name, Id)
      };
      var userIdentity = new ClaimsIdentity(claims, "login");
      var principal = new ClaimsPrincipal(userIdentity);
      return principal;
      //node equivalent of req.setData(userId)
    }
 
  }
   public class PublicUserModel {
    public string Name { get; set; }
  }

  //Add ChangeUserPasswordModel class here
}