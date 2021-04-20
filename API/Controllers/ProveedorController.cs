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
    public class ProveedorController : BaseApiController
    {
        #region Constructor
        public ProveedorController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.ProveedorRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Proveedor>> GetAsync() => await _unitOfWork.ProveedorRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Proveedor> GetByIdAsync(int id) => await _unitOfWork.ProveedorRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateProveedorDTO proveedorDTO)
        {
            var proveedor = new Proveedor
                (
                    proveedorDTO.NameProveedor,
                    proveedorDTO.ContactProveedor,
                    proveedorDTO.PhoneProveedor,
                    proveedorDTO.AddressProveedor
                );

            var newProveedor = await _unitOfWork.ProveedorRepository.InsertAsync(proveedor);
            if (newProveedor is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newProveedor.ProveedorId }, newProveedor);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateProveedorDTO proveedorDTO)
        {
            if (id != proveedorDTO.ProveedorId)
            {
                return BadRequest();
            }

            var proveedorInDb = await _unitOfWork.ProveedorRepository.GetByIdAsync(id);
            if (proveedorInDb is null)
            {
                return NotFound();
            }

            proveedorInDb.NameProveedor = proveedorDTO.NameProveedor;
            proveedorInDb.ContactProveedor = proveedorDTO.ContactProveedor;
            proveedorInDb.PhoneProveedor = proveedorDTO.PhoneProveedor;
            proveedorInDb.AddressProveedor = proveedorDTO.AddressProveedor;
            proveedorInDb.Status = proveedorDTO.status;


            var result = await _unitOfWork.ProveedorRepository.UpdateAsync(proveedorInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
