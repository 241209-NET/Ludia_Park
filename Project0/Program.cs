﻿/*
C# .NET Console APP
Take user input
Input validation
Use a collection to store data
Have a menu with atleast 3 options
Transform or do some calculation with that data
*/


namespace miniConsole;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;
        List<Food> foodList = new List<Food>();

        while (keepRunning)                          // research this
        {
            Console.WriteLine("🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥");
            Console.WriteLine("⬜  🍕  Welcome to Ludia's Food Court!! 🍔  ⬜");
            Console.WriteLine("🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥⬜🟥");
            Console.WriteLine("1. Add a food item");
            Console.WriteLine("2. Calculate total cost");
            Console.WriteLine("3. End Transaction");
            Console.Write("Please choose an option: ");

            string? option = Console.ReadLine();         // ? = can be null or a string

            switch (option)
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
                    break;
            }
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("*Thank you for dining at Ludia's Food Court!!*");
        Console.WriteLine("========== 🍴 Please come again!!🍴 ==========");
    }

    static void AddFood(List<Food> foodList)
    {
        string name = "";
        bool validName = false;

        while (!validName)
        {
            Console.Write("Enter food name: ");
            name = Console.ReadLine()?.Trim();              // removing extra spaces and handle null input

            if (name.Length == 0)
            {
                Console.WriteLine("You must enter a food name.  Please try again.");
                continue;
            }

            bool isValid = true;
            
            foreach (char c in name)             
            {
                if (!Char.IsLetter(c))
                {
                    Console.WriteLine("Food name must only consist of alphabetic letters.  Please try again.");
                    isValid = false;
                    break;
                }
            }
    
            if (isValid)
            {
                validName = true;
            }
        }
        
        double price = 0;
        bool validPrice = false;

        while (!validPrice)
        {
            Console.Write("Enter the price of the food: ");
            string? priceInput = Console.ReadLine();                 
            
            price = double.Parse(priceInput);
            if (price > 0) 
            {
                validPrice = true;
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a value greater than 0.");
            }
        }

        Food food = new Food(name, price);
        foodList.Add(food);
        Console.WriteLine($"Added: [ {name}: ${price:F2} ]");     // F2 = 2 decimal places
    }
    static void CalculateTotal(List<Food> foodList)
    {
        if (foodList.Count == 0)
        {
            Console.WriteLine("No food items added yet.");
            return;
        }

        double totalCost = 0;

        foreach (var food in foodList)                  
        {
            totalCost += food.Price;
        }

        Console.WriteLine($"Your total today is: [ ${totalCost:F2} ]");
    }
}




