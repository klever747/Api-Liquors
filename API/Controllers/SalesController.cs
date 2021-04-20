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
    public class SalesController : BaseApiController
    {
        #region Constructor
        public SalesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.SalesRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Sales>> GetAsync() => await _unitOfWork.SalesRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Sales> GetByIdAsync(int id) => await _unitOfWork.SalesRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateSaleDTO saleDTO)
        {
            var sale = new Sales
                (
                    saleDTO.ciClient,
                    saleDTO.IdOrder,
                    saleDTO.PriceSale,
                    saleDTO.PriceDelivery,
                    saleDTO.PaymentMethod,
                    saleDTO.IdPaymentSale,
                    saleDTO.Status

                );

            var newSale = await _unitOfWork.SalesRepository.InsertAsync(sale);
            if (newSale is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newSale.IdSales }, newSale);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateSaleDTO saleDTO)
        {
            if (id != saleDTO.IdSales)
            {
                return BadRequest();
            }

            var salesInDb = await _unitOfWork.SalesRepository.GetByIdAsync(id);
            if (salesInDb is null)
            {
                return NotFound();
            }
            salesInDb.PriceSale = saleDTO.PriceSale;
            salesInDb.PriceDelivery = saleDTO.PriceDelivery;
            salesInDb.PaymentMethod = saleDTO.PaymentMethod;
            salesInDb.Status = saleDTO.Status;

            var result = await _unitOfWork.SalesRepository.UpdateAsync(salesInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
