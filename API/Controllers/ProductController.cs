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
    public class ProductController : BaseApiController
    {
        #region Constructor
        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.ProductRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Product>> GetAsync() => await _unitOfWork.ProductRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Product> GetByIdAsync(int id) => await _unitOfWork.ProductRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateProductDTO productDTO)
        {
            var product = new Product
                (
                    productDTO.ProveedorId,
                    productDTO.CiUser,
                    productDTO.IdCategory,
                    productDTO.NameProduct,
                    productDTO.ImageProduct,
                    productDTO.PriceProduct,
                    productDTO.StockProduct,
                    productDTO.DetailProduct,
                    productDTO.SalesProduct
                   
                );

            var newProduct = await _unitOfWork.ProductRepository.InsertAsync(product);
            if (newProduct is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newProduct.ProductId}, newProduct);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateProductDTO productDTO)
        {
            if (id != productDTO.ProductId)
            {
                return BadRequest();
            }

            var productInDb = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (productInDb is null)
            {
                return NotFound();
            }
            productInDb.ProveedorId = productDTO.ProveedorId;
            productInDb.IdCategory = productDTO.IdCategory;
            productInDb.NameProduct= productDTO.NameProduct;
            productInDb.ImageProduct = productDTO.ImageProduct;
            productInDb.PriceProduct = productDTO.PriceProduct;
            productInDb.StockProduct = productDTO.StockProduct;
            productInDb.DetailProduct= productDTO.DetailProduct;
            productInDb.SalesProduct = productDTO.SalesProduct;

            var result = await _unitOfWork.ProductRepository.UpdateAsync(productInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
