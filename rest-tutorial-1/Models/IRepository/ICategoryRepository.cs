using rest_tutorial_1.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_tutorial_1.Models.IRepository
{
    public interface ICategoryRepository
    {
        CategoryDto Create(CategoryDto categoryDto);
        List<CategoryDto> GetList();
        CategoryDto GetById(Guid Id);
        CategoryDto Update(CategoryDto categoryDto);
        bool Delete(Guid Id);
    }
}
