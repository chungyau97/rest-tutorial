using AutoMapper;
using rest_tutorial_1.Entities.Models;
using rest_tutorial_1.Models.Contexts;
using rest_tutorial_1.Models.Dtos;
using rest_tutorial_1.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_tutorial_1.Models.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public CategoryDto Create(CategoryDto categoryDto)
        {
            Category category = _applicationDbContext.Category.Add(_mapper.Map<Category>(categoryDto)).Entity;
            _applicationDbContext.SaveChanges();
            return _mapper.Map<CategoryDto>(category);
        }
        public List<CategoryDto> GetList()
        {
            List<Category> categoryList = _applicationDbContext.Category.ToList();
            if (categoryList.Count() < 1) return null;
            return _mapper.Map<List<CategoryDto>>(categoryList);
        }
        public CategoryDto GetById(Guid Id)
        {
            if (Id == Guid.Empty) return null;
            Category category = _applicationDbContext.Category.Find(Id);
            if (category is null) return null;
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            if (categoryDto is null) return null;
            Category category = await _applicationDbContext.Category.FindAsync(categoryDto.Id);
            if (category is null) return null;
            _applicationDbContext.Category.Update(_mapper.Map<Category>(categoryDto));
            await _applicationDbContext.SaveChangesAsync();
            return categoryDto;
        }
        public bool Delete(Guid Id)
        {
            if (Id == Guid.Empty) return false;
            Category category = _applicationDbContext.Category.Find(Id);
            if (category is null) return false;
            _applicationDbContext.Category.Remove(category);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }
}
