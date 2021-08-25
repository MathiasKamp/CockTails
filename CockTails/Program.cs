using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Threading;


namespace CockTails
{
    internal static class Program
    {
        public static void Main()
        {
            
            DrinkDatabaseInitializer drinkDatabaseInitializer = new DrinkDatabaseInitializer();
            CockTailContext ctx = new CockTailContext();
            Gui gui = new Gui();


            bool start = false;

            // add default ingredients and drinks to the database just for test data.
            drinkDatabaseInitializer.AddDefaultIngredients(ctx);
            drinkDatabaseInitializer.AddDefaultDrinks(ctx);

            string drinkName = null;
            List<Ingredients> ingredientsForDrink = null;

            while (!start)
            {
                gui.PrintMainMenu();
                int userInput = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (userInput)
                {
                    case 1: // user choose to see all drinks
                        Console.Clear();
                        var allDrinks = DrinkManager.GetAllDrinks(ctx);
                        foreach (var drinks in allDrinks)
                        {
                            Console.WriteLine(drinks.ToString());
                        }

                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2: // user choose to delete a drink
                        Console.Clear();
                        Console.Write("Enter the id number of the drink you wish to delete :");
                        userInput = int.Parse(Console.ReadLine() ?? string.Empty);

                        if (DrinkManager.DeleteDrink(userInput, ctx))
                        {
                            Console.WriteLine("new list of drinks...");
                            var newListOfDrinks = DrinkManager.GetAllDrinks(ctx);
                            foreach (var drinks in newListOfDrinks)
                            {
                                Console.WriteLine(drinks.ToString());
                            }
                        }

                        else
                        {
                            Console.WriteLine($"drink id :{userInput} could't be deleted");
                        }

                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 3: // user choose the new drink options 
                        Console.Clear();
                        gui.PrintNewDrinkOptions();
                        userInput = int.Parse(Console.ReadLine() ?? string.Empty);
                        switch (userInput)
                        {
                            case 1: // user choose to see the current ingredients
                                Console.Clear();
                                Console.WriteLine("current ingredients :");
                                var ingredients = DrinkManager.GetAllIngredients(ctx);
                                foreach (var ingredient in ingredients)
                                {
                                    Console.WriteLine("ingredient # " + ingredient.IngredientsId + "name :" +
                                                      ingredient.IngredientName);
                                }

                                Thread.Sleep(3000);
                                Console.Clear();
                                break;
                            case 2: // user choose to add a new ingredient to the database
                                Console.Clear();
                                Console.Write("ingredient name :");
                                string ingredientName = Console.ReadLine();
                                if (DrinkManager.AddNewIngredient(ingredientName, ctx))
                                {
                                    Console.WriteLine("ingredient has been added...");
                                    Thread.Sleep(1000);
                                }

                                else
                                {
                                    Console.WriteLine($"ingredient :{ingredientName} could't be added");
                                }

                                Console.Clear();
                                break;
                            case 3: // user choose the option of creating a new drink in the database
                                Console.Clear();
                                gui.PrintCreateNewDrink();
                                userInput = int.Parse(Console.ReadLine());
                                switch (userInput)
                                {
                                    case 1: // user choose the option to set the new drink's name
                                        Console.Clear();
                                        Console.Write("drink name :");
                                        drinkName = Console.ReadLine();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    case 2: // user choose to add ingredients to the new drink
                                        Console.Clear();
                                        ingredientsForDrink = new List<Ingredients>();
                                        Console.Write("how many ingredients would you like to add : ");
                                        userInput = int.Parse(Console.ReadLine());
                                        while (ingredientsForDrink.Count != userInput)
                                        {
                                            Console.Write("ingredient number to be added :");
                                            int ingredientNumber = int.Parse(Console.ReadLine());
                                            var ingredient = DrinkManager.GetSpecificIngredient(ingredientNumber, ctx);
                                            ingredientsForDrink.Add(ingredient);
                                            Console.WriteLine("you have added " + ingredient.ToString());
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        }

                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;


                                    case 3: // user choose to create the drink with the name and ingreidnets, in the database 
                                        Console.Clear();
                                        Console.WriteLine("creating drink...");
                                        if (ingredientsForDrink != null && drinkName != null &&
                                            DrinkManager.AddNewDrink(ctx, drinkName, ingredientsForDrink))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("drink created..");
                                            Thread.Sleep(1000);
                                        }

                                        Thread.Sleep(1000);
                                        break;
                                }

                                break;
                        }

                        break;
                    case 4: // user choose to update an existing drink
                        Console.Clear();
                        Console.WriteLine("existing drinks...");
                        var allDrinksList = DrinkManager.GetAllDrinks(ctx);
                        foreach (var drinks in allDrinksList)
                        {
                            Console.WriteLine(drinks.ToString());
                        }

                        Console.Write("which drink id would you like to update : ");
                        userInput = int.Parse(Console.ReadLine());
                        var drinkToUpdate = DrinkManager.GetSpecificDrink(userInput, ctx);
                        Console.Clear();
                        Console.WriteLine("you choose : " + drinkToUpdate.ToString());
                        Console.WriteLine("which parameter would you like to change : ");
                        gui.PrintChangeDrinkParameters();
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case 1: // user choose to update an existing drink's name
                                Console.Clear();
                                Console.Write("new name :");
                                string newName = Console.ReadLine();
                                var newNamedDrink =
                                    DrinkManager.UpdateExistingDrinksName(drinkToUpdate.DrinkId, ctx, newName);
                                Console.WriteLine("the drinks name is now : " + newNamedDrink.ToString());
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                            case 2: // user choose to add a new ingredient to an existing drink
                                Console.Clear();
                                Console.Write("new ingredient id : ");
                                userInput = int.Parse(Console.ReadLine());
                                var newIngredient = DrinkManager.GetSpecificIngredient(userInput, ctx);
                                Console.WriteLine("you choose the ingredient : " + newIngredient.ToString());
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.WriteLine("adding new ingredient....");
                                Thread.Sleep(2000);
                                var drinkWithNewIngredient =
                                    DrinkManager.UpdateExistingDrinksIngredients(drinkToUpdate.DrinkId, ctx,
                                        newIngredient);
                                Console.WriteLine("drink is updated : " + drinkWithNewIngredient.ToString());
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                            case 3: // user choose to update an existing drink's ingredients with a new List<Ingredients>
                                Console.Clear();
                                Console.Write("how many ingredients would you like to add :");
                                userInput = int.Parse(Console.ReadLine());
                                ingredientsForDrink = new List<Ingredients>();
                                while (ingredientsForDrink.Count != userInput)
                                {
                                    Console.Write("ingredient number to be added :");
                                    int ingredientNumber = int.Parse(Console.ReadLine());
                                    var ingredient = DrinkManager.GetSpecificIngredient(ingredientNumber, ctx);
                                    ingredientsForDrink.Add(ingredient);
                                    Console.WriteLine("you have added " + ingredient.ToString());
                                }

                                Console.WriteLine("adding ingredients...");
                                Thread.Sleep(2000);
                                var drinkWithNewIngredients =
                                    DrinkManager.UpdateExistingDrinkWithNewIngredients(drinkToUpdate.DrinkId, ctx,
                                        ingredientsForDrink);
                                Console.WriteLine("new drinks ingredients : " + drinkWithNewIngredients.ToString());
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                        }

                        break;
                    case 5: // user choose to search for a drinks name
                        Console.Clear();
                        Console.Write("insert a name of a drink to search for :");
                        string searchNameDrink = Console.ReadLine();
                        Console.WriteLine("searching....");
                        Thread.Sleep(2000);
                        var searchResult = DrinkManager.SearchForDrink(searchNameDrink, ctx);
                        if (searchResult.Count > 0)
                        {
                            Console.WriteLine($"the drinks that contains : {searchNameDrink} is");
                            foreach (var drink in searchResult)
                            {
                                Console.WriteLine(drink.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine("no result try again");
                        }

                        Thread.Sleep(2000);
                        Console.Clear();

                        break;
                    case 6: // user choose to exit
                        start = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("you've inserted an invalid number, try again.");
                        Thread.Sleep(2000);
                        gui.PrintMainMenu();
                        break;
                }
            }
        }
    }
}