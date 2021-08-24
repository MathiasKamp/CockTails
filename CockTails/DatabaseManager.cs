using System;
using System.Collections.Generic;
using System.Linq;

namespace CockTails
{
    public static class DatabaseManager
    {
        public static List<Ingredients> GetAllIngredients(CockTailContext ctx)
        {
            List<Ingredients> newIngredientsList = null;

            ctx = new CockTailContext();

            var ingredients = (from ingredient in ctx.Ingredients
                select ingredient).ToList();

            newIngredientsList = ingredients;

            return newIngredientsList;
        }

        public static bool AddNewDrink(CockTailContext ctx, string name, List<Ingredients> ingredients)
        {
            bool drinkAdded = false;

            using (ctx = new CockTailContext())
            {
                var newDrink = new Drinks() {DrinkName = name, Ingredients = ingredients};
                ctx.Drinks.Add(newDrink);
                ctx.SaveChanges();
                drinkAdded = true;
            }

            return drinkAdded;
        }


        public static Drinks GetSpecificDrink(int drinkId, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var specificDrink = (from drink in
                    ctx.Drinks
                where drink.DrinkId == drinkId
                select drink).ToList();

            return specificDrink.First();
        }

        public static bool AddNewIngredient(string name, CockTailContext ctx)
        {
            bool ingredientHasBeenAdded = false;
            using (ctx = new CockTailContext())
            {
                var newIngredient = new Ingredients() {IngredientName = name};
                ctx.Ingredients.Add(newIngredient);
                ctx.SaveChanges();
                ingredientHasBeenAdded = true;
            }

            return ingredientHasBeenAdded;
        }
        


        public static Ingredients GetSpecificIngredient(int ingredientId, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var specificIngredient = (from ingredient in
                    ctx.Ingredients
                where ingredient.IngredientsId.Equals(ingredientId)
                select ingredient).ToList();

            return specificIngredient.First();
        }

        public static List<Drinks> GetAllDrinks(CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var drinks = (from drink in ctx.Drinks
                select drink).ToList();
            return drinks;
        }
        
        public static Drinks UpdateExistingDrinkWithNewIngredients(int drinkId, CockTailContext ctx, List<Ingredients> newIngredients)
        {
            var drinkToUpdate = GetSpecificDrink(drinkId, ctx);

            if (newIngredients != null)
            {
                using (ctx = new CockTailContext())
                {
                    drinkToUpdate.Ingredients = newIngredients;
                    ctx.SaveChanges();
                }
            }
            return drinkToUpdate;
        }

        public static List<Drinks> SearchForDrink(string searchName, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var searchedDrinksResult = (from drink in ctx.Drinks
                where drink.DrinkName.Contains(searchName)
                select drink).ToList();
            return searchedDrinksResult;
        }


        public static Drinks UpdateExistingDrinksIngredients(int drinkId, CockTailContext ctx,
            Ingredients newIngredient)
        {
            var drinkToUpdate = GetSpecificDrink(drinkId, ctx);

            if (newIngredient != null)
            {
                using (ctx = new CockTailContext())
                {
                    drinkToUpdate.Ingredients.Add(newIngredient);
                    ctx.SaveChanges();
                }
            }

            return drinkToUpdate;
        }
        

        public static Drinks UpdateExistingDrinksName(int drinkId, CockTailContext ctx, string newName)
        {

            Drinks drinkToUpdate = GetSpecificDrink(drinkId, ctx);

            if (newName != string.Empty)
            {
                using (ctx = new CockTailContext())
                {
                    
                    drinkToUpdate.DrinkName = newName;
                    ctx.SaveChanges();
                }
            }
            return drinkToUpdate;
        }
        

        public static bool DeleteDrink(int drinkIdToDelete, CockTailContext ctx)
        {
            var drinkToDelete = ctx.Drinks.First(drink => drink.DrinkId == drinkIdToDelete);
            bool drinkHasBeenRemoved = false;
            using (ctx = new CockTailContext())
            {

                ctx.Drinks.Attach(drinkToDelete);
                ctx.Drinks.Remove(drinkToDelete);
                ctx.SaveChanges();
                drinkHasBeenRemoved = true;

            }

            return drinkHasBeenRemoved;
        }
    }
}