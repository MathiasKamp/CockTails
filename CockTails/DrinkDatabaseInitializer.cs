using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace CockTails
{
    public class DrinkDatabaseInitializer
    {
        public void AddDefaultIngredients(CockTailContext ctx)
        {
            List<Ingredients> defaultIngredients = new List<Ingredients>();

            defaultIngredients.Add(new Ingredients() {IngredientName = "vodka"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "rum"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "lime juice"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "triple sec"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "tequila"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "orange juice"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "tomato juice"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "almond syrup"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "whole lime"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "cherry"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "orange curacao"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "kahlua"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "cachaca"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "sugar"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "bourbon"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "brown sugar"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "italian sweet vermouth"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "french dry vermouth"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "gin"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "cola"});
            defaultIngredients.Add(new Ingredients() {IngredientName = "sprite"});
            defaultIngredients.Add(new Ingredients()
                {IngredientName = "pineapple juice"});
            defaultIngredients.Add(
                new Ingredients() {IngredientName = "coconut cream"});

            ctx.Ingredients.AddRange(defaultIngredients);
            ctx.SaveChanges();
        }

        public void AddDefaultDrinks(CockTailContext ctx)
        {
            List<Drinks> defaultDrinks = new List<Drinks>();
            defaultDrinks.Add(new Drinks() {DrinkName = "test", Ingredients = new List<Ingredients>(){DrinkManager.GetSpecificIngredient(3, ctx), DrinkManager.GetSpecificIngredient(4, ctx), DrinkManager.GetSpecificIngredient(5, ctx)}});

            ctx.Drinks.AddRange(defaultDrinks);
            ctx.SaveChanges();
        }
        
    }
} 