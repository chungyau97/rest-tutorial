using Microsoft.AspNetCore.Mvc;
using rest_tutorial_1.Models.Dtos;
using rest_tutorial_1.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_tutorial_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            CategoryDto result = _categoryRepository.Create(categoryDto);
            if (result is null) return BadRequest();
            return Ok(result);
        }
        [HttpGet]
        [Route("All")]
        public IActionResult GetList()
        {
            IEnumerable<CategoryDto> categoryList = _categoryRepository.GetList();
            if (categoryList is null) return NotFound();
            return Ok(categoryList);
        }
        [HttpGet]
        [Route("GetById/{Id?}")]
        public IActionResult GetById(Guid Id)
        {
            CategoryDto categoryDto = _categoryRepository.GetById(Id);
            if(categoryDto is null) return NotFound();
            return Ok(categoryDto);
        }
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            categoryDto = _categoryRepository.Update(categoryDto);
            if (categoryDto is null) return NotFound();
            return Ok(categoryDto);
        }
        [HttpDelete]
        [Route("DeleteById/{Id?}")]
        public IActionResult Delete(Guid Id)
        {
            if (!_categoryRepository.Delete(Id)) return NotFound();
            return Ok();
        }
    }
}
