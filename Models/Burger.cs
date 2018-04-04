using System.ComponentModel.DataAnnotations;
using burgershack.Interfaces;

namespace burgershack.Models
{

  public class Burger : IMenuItem
  {
    public int Id {get;set;}
    
    [Required]
    [MinLength(3)]
     public string Name { get; set; }

    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    public int KCal { get; set; }
    public string Ingredients { get; set; }
   
    // public Burger(string name, string desc, double price, int kcal, string ingredients)
    // {
    //   Name = name;
    //   Description = desc;
    //   Price = price;
    //   KCal = kcal;
    //   Ingredients = ingredients;
    // }
  }

}