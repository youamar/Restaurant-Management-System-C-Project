using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class RecipeService
    {

        private readonly RecipeRepository _recipeRepository;

        public RecipeService(string connectionString)
        {
            _recipeRepository = new RecipeRepository(connectionString);
        }

        public List<RecipeModel> GetRecipeFromItem(int item_id)
        {
            return _recipeRepository.GetRecipeFromItem(item_id);
        }
    }
}
