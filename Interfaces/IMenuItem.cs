namespace burgershack.Interfaces
{

  public interface IMenuItem
  {
    string Name { get; set; }
    string Description { get; set; }
    double Price { get; set; }
    int KCal { get; set; }
    string Ingredients { get; set; }
  }

}