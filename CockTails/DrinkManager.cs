using System.Collections.Generic;
using System.Security;

namespace CockTails
{
    public static class DrinkManager
    {
        public static List<Ingredients> GetAllIngredients(CockTailContext ctx)
        {
            return DatabaseManager.GetAllIngredients(ctx);
        }

        public static bool AddNewDrink(CockTailContext ctx, string name, List<Ingredients> ingredients)
        {
            return DatabaseManager.AddNewDrink(ctx, name, ingredients);
        }

        public static Drinks GetSpecificDrink(int drinkId, CockTailContext ctx)
        {
            return DatabaseManager.GetSpecificDrink(drinkId, ctx);
        }

        public static bool AddNewIngredient(string name, CockTailContext ctx)
        {
            return DatabaseManager.AddNewIngredient(name, ctx);
        }

        public static Ingredients GetSpecificIngredient(int ingredientId, CockTailContext ctx)
        {
            return DatabaseManager.GetSpecificIngredient(ingredientId, ctx);
        }

        public static List<Drinks> GetAllDrinks(CockTailContext ctx)
        {
            return DatabaseManager.GetAllDrinks(ctx);
        }

        public static bool DeleteDrink(int drinkIdToDelete, CockTailContext ctx)
        {
            return DatabaseManager.DeleteDrink(drinkIdToDelete, ctx);
        }

        public static Drinks  UpdateExistingDrinkWithNewIngredients(int drinkId, CockTailContext ctx, List<Ingredients> newIngredients)
        {
            return DatabaseManager.UpdateExistingDrinkWithNewIngredients(drinkId, ctx, newIngredients);
        }
        
        public static Drinks  UpdateExistingDrinksIngredients(int drinkId, CockTailContext ctx, Ingredients newIngredient)
        {
            return DatabaseManager.UpdateExistingDrinksIngredients(drinkId, ctx, newIngredient);
        }
        
        public static Drinks  UpdateExistingDrinksName(int drinkId, CockTailContext ctx,  string newName)
        {
            return DatabaseManager.UpdateExistingDrinksName(drinkId, ctx, newName);
        }

        public static List<Drinks> SearchForDrink(string searchName, CockTailContext ctx)
        {
            return DatabaseManager.SearchForDrink(searchName, ctx);
        }
    }
}

