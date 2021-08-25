using System;

namespace CockTails
{
    /// <summary>
    /// this class's purpose for printing menu's to the console
    /// </summary>
    public class Gui
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("1. get drinks");
            Console.WriteLine("2. delete drink");
            Console.WriteLine("3. new drink options");
            Console.WriteLine("4. update existing drink");
            Console.WriteLine("5. search for drink");
            Console.WriteLine("6. exit");
        }

        public void PrintNewDrinkOptions()
        {
            Console.WriteLine("1. show current ingredients");
            Console.WriteLine("2. add another ingredient to the drink");
            Console.WriteLine("3. create new drink");
        }

        public void PrintCreateNewDrink()
        {
            Console.WriteLine("1. drink name");
            Console.WriteLine("2. add ingredient to the drink");
            Console.WriteLine("3. create drink");
        }

        public void PrintChangeDrinkParameters()
        {
            Console.WriteLine("1. change the name");
            Console.WriteLine("2. add a new ingredient");
            Console.WriteLine("3. remove all ingredients and add new ones");
        }
    }
}