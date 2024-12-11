namespace miniConsole;

public class Food
{
  public string Name { get; set; }   // these need to be capitalized and public
  public double Price { get; set; }

  public Food(string name, double price)
  {
    Name = name;
    Price = price;
  }
}