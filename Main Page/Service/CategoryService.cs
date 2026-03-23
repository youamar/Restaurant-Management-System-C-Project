using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Page.Model;
using Main_Page.Repository;

namespace Main_Page.Service
{
    internal class CategoryService
    {
        private readonly CategoryRepository _catogeryRepository;

        public CategoryService(string connectionstring)
        {
            _catogeryRepository = new CategoryRepository(connectionstring);
        }

        public List<CategoryModel> GetAllCategory()
        {
            return _catogeryRepository.GetAllCategory();
        }

        public List<CategoryModel> GetRevenueByCategoryID()
        {
            return _catogeryRepository.GetRevenueByCategoryID();
        }
    }
}
