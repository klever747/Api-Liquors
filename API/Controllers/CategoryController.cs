using Application.API.DTOs;
using Application.API.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        #region Constructor
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.CategoryRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Category>> GetAsync() => await _unitOfWork.CategoryRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Category> GetByIdAsync(int id) => await _unitOfWork.CategoryRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateCategoryDTO categoryDTO)
        {
            var category = new Category
                (
                    categoryDTO.NameCategory,
                    categoryDTO.ImageCategory
                );

            var newCategory = await _unitOfWork.CategoryRepository.InsertAsync(category);
            if (newCategory is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newCategory.IdCategory}, newCategory);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateCategoryDTO categoryDTO)
        {
            if (id != categoryDTO.IdCategory)
            {
                return BadRequest();
            }

            var categoryInDb = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (categoryInDb is null)
            {
                return NotFound();
            }

            categoryInDb.NameCategory = categoryDTO.NameCategory;
            categoryInDb.ImageCategory = categoryDTO.ImageCategory;

            var result = await _unitOfWork.CategoryRepository.UpdateAsync(categoryInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
