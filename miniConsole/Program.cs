namespace miniConsole;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;
        List<Food> foodList = new List<Food>();

        while(keepRunning)
        {
            Console.WriteLine("Welcome to Ludia's Food Court!!");
            Console.WriteLine("1. Add a food item");
            Console.WriteLine("2. Calculate total cost");
            Console.WriteLine("3. End Transaction");
            Console.Write("Please choose an option: ");

            string option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    AddFood(foodList);
                    break;
                case "2":
                    CalculateTotal(foodList);
                    break;
                case "3":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input.  Please try again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for dining at Ludia's Food Court!!  Please come again!!");
    }

    static void AddFood(List<Food> foodList)
    {
        string name = "";
        bool validName = false;

        while (!validName)
        {
            Console.Write("Enter food name: ");
            name = Console.ReadLine();

            bool isValid = true;
            foreach(char c in name)
            {
                if (!Char.IsLetter(c))
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid) 
            {
                validName = true;
            }
            else 
            {
                Console.WriteLine("Food name must only consist of alphabetic letters.  Please try again.");
            }
        }
        
        double price = 0;
        bool validPrice = false;

        while (!validPrice)
        {
            Console.Write("Enter the price of the food: ");
            string priceInput = Console.ReadLine();
            
            if (double.TryParse(priceInput, out price) && price > 0)
            {
                validPrice = true;
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid positive number.");
            }
        }

        Food food = new Food(name, price);
        foodList.Add(food);
        Console.WriteLine($"Added {name} with price ${price:F2}.");
    }
    static void CalculateTotal(List<Food> foodList)
    {
        if (foodList.Count == 0)
        {
            Console.WriteLine("No food items added yet.");
            return;
        }

        double totalCost = 0;

        // Sum up the prices of all foods in the list
        foreach (var food in foodList)
        {
            totalCost += food.Price;
        }

        Console.WriteLine($"Total cost of all food items: ${totalCost:F2}");
    }
}



/*
C# .NET Console APP
Take user input
Input validation
Use a collection to store data
Have a menu with atleast 3 options
Transform or do some calculation with that data
////////////////////

- validate input: maybe the user inputs their age or something, and maybe you gotta make sure it is a number and not some letters.
- use a collection: maybe it's a list of something
- have a menu with 3 options: this is just a switch statement, such as add a movie, add new users, add a new car, etc.  one option can even be to quit the app. (maybe i can do this part next time?)
- manipulate data: maybe u have a list of movies, and u can get the average rating of the movie.  maybe a user can input a movie name and a rating, and one of the "options"?  (maybe the menu?) you can get the calculated average rating.
*/
