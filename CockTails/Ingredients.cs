using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CockTails
{
    /// <summary>
    /// this Class's purpose is to be an object of an ingredient
    /// </summary>
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