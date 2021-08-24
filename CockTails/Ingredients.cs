using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CockTails
{
    [Table("Ingredients", Schema="dbo")]
    public class Ingredients
    {
        

        [Key]
        public int IngredientsId { get; set; }
        [MaxLength(50)]
        public string IngredientName { get; set; }

        public override string ToString()
        {
            return "ingredientId : " + IngredientsId + " ingredient name :" + IngredientName;
        }
    }
}