using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CockTails
{
    [Table("Drinks", Schema = "dbo")]
    public class Drinks
    {
        [Key] public int DrinkId { get; set; }

        [MaxLength(50)] 
        public string DrinkName { get; set; }

        public virtual List<Ingredients> Ingredients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("drink #:" + DrinkId + " name :" + DrinkName + ", with the following ingredients :");
            foreach (var ingredient in Ingredients)
            {
                if (ingredient == Ingredients.Last())
                {
                    sb.Append(ingredient.IngredientName);
                }
                else
                {
                    sb.Append(ingredient.IngredientName+ " , ");
                }
            }
            return sb.ToString();
        }
    }
}