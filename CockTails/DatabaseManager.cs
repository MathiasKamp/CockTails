using System.Collections.Generic;
using System.Linq;

namespace CockTails
{
    /// <summary>
    /// this class has the purpose of inserting and collecting data from the database
    /// </summary>
    public static class DatabaseManager
    {
        /// <summary>
        /// this method returns all the ingredients
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>List<Ingredients></returns>
        public static List<Ingredients> GetAllIngredients(CockTailContext ctx)
        {
            List<Ingredients> newIngredientsList = null;

            ctx = new CockTailContext();

            var ingredients = (from ingredient in ctx.Ingredients
                select ingredient).ToList();

            newIngredientsList = ingredients;

            return newIngredientsList;
        }
        /// <summary>
        /// this method creates a new Drinks object in the database
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="name"></param>
        /// <param name="ingredients"></param>
        /// <returns>Bool</returns>

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


        /// <summary>
        /// this method returns a specific drink from the database based on the drinkId from the user
        /// </summary>
        /// <param name="drinkId"></param>
        /// <param name="ctx"></param>
        /// <returns>Drinks</returns>
        public static Drinks GetSpecificDrink(int drinkId, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var specificDrink = (from drink in
                    ctx.Drinks
                where drink.DrinkId == drinkId
                select drink).ToList();

            return specificDrink.First();
        }
        /// <summary>
        /// this method adds a new ingredient to the database based on the name from the user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ctx"></param>
        /// <returns>bool</returns>
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
        


        /// <summary>
        /// this method gets a specific ingredient from the database based on the ingredientId from the user
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <param name="ctx"></param>
        /// <returns>Ingredients</returns>
        public static Ingredients GetSpecificIngredient(int ingredientId, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var specificIngredient = (from ingredient in
                    ctx.Ingredients
                where ingredient.IngredientsId.Equals(ingredientId)
                select ingredient).ToList();

            return specificIngredient.First();
        }

        /// <summary>
        /// this method gets all the drinks objects from the database
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public static List<Drinks> GetAllDrinks(CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var drinks = (from drink in ctx.Drinks
                select drink).ToList();
            return drinks;
        }
        /// <summary>
        /// this method updates an existing drink with a new List<Ingredients>
        /// </summary>
        /// <param name="drinkId"></param>
        /// <param name="ctx"></param>
        /// <param name="newIngredients"></param>
        /// <returns>Drinks</returns>
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

        /// <summary>
        ///  this method serach for a drinks name in the database based on a string from the user
        /// </summary>
        /// <param name="searchName"></param>
        /// <param name="ctx"></param>
        /// <returns>List<Drinks></returns>
        public static List<Drinks> SearchForDrink(string searchName, CockTailContext ctx)
        {
            ctx = new CockTailContext();
            var searchedDrinksResult = (from drink in ctx.Drinks
                where drink.DrinkName.Contains(searchName)
                select drink).ToList();
            return searchedDrinksResult;
        }


        /// <summary>
        /// this method adds another ingredient to the drink object in the database
        /// </summary>
        /// <param name="drinkId"></param>
        /// <param name="ctx"></param>
        /// <param name="newIngredient"></param>
        /// <returns>Drinks</returns>
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
        

        /// <summary>
        /// this method updates an existing drinks name in the database
        /// </summary>
        /// <param name="drinkId"></param>
        /// <param name="ctx"></param>
        /// <param name="newName"></param>
        /// <returns>Drinks</returns>
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
        

        /// <summary>
        /// this method deletes an existing drink object in the database, based on the DrinkId from the user
        /// </summary>
        /// <param name="drinkIdToDelete"></param>
        /// <param name="ctx"></param>
        /// <returns>bool</returns>
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