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
    public class OrderController : BaseApiController
    {
        #region Constructor
        public OrderController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.OrderRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Order>> GetAsync() => await _unitOfWork.OrderRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Order> GetByIdAsync(int id) => await _unitOfWork.OrderRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateOrderDTO orderDTO)
        {
            var order = new Order
                (
                    orderDTO.CiClient,
                    orderDTO.Idroduct,
                    orderDTO.CantOrder,
                    orderDTO.DeliveryPrice,
                    orderDTO.PriceOrder,
                    orderDTO.AddressOrder,
                    orderDTO.StatusOrder

                );

            var newOrder = await _unitOfWork.OrderRepository.InsertAsync(order);
            if (newOrder is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newOrder.CiClient }, newOrder);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateOrderDTO orderDTO)
        {
            if (id != orderDTO.IdOrder)
            {
                return BadRequest();
            }

            var OrderInDb = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (OrderInDb is null)
            {
                return NotFound();
            }
            OrderInDb.DeliveryPrice = orderDTO.DeliveryPrice;
            OrderInDb.CantProduct = orderDTO.cantProduct;
            OrderInDb.PriceOrder = orderDTO.PriceOrder;
            OrderInDb.AddressOrder = orderDTO.AddressOrder;
            OrderInDb.StatusOrder = orderDTO.StatusOrder;

            var result = await _unitOfWork.OrderRepository.UpdateAsync(OrderInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
