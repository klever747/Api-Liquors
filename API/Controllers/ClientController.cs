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
    public class ClientController : BaseApiController
    {
        #region Constructor
        public ClientController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.ClientRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<Client>> GetAsync() => await _unitOfWork.ClientRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Client> GetByIdAsync(int id) => await _unitOfWork.ClientRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateClientDTO clientDTO)
        {
            var client = new Client
                (
                    clientDTO.CiUser,
                    clientDTO.PictureClient,
                    clientDTO.DisplaynameClient,
                    clientDTO.EmailClient,
                    clientDTO.PasswordClient,
                    clientDTO.PhoneClient,
                    clientDTO.AddessClient,
                    clientDTO.DateBirthClient
                );

            var newClient = await _unitOfWork.ClientRepository.InsertAsync(client);
            if (newClient is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newClient.CiClient }, newClient);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateClientDTO clientDTO)
        {
            if (id != clientDTO.CiClient)
            {
                return BadRequest();
            }

            var clientInDb = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (clientInDb is null)
            {
                return NotFound();
            }

            clientInDb.PictureClient = clientDTO.PictureClient;
            clientInDb.DisplayNameClient = clientDTO.DisplaynameClient;
            clientInDb.EmailClient = clientDTO.EmailClient;
            clientInDb.PasswordClient = clientDTO.PasswordClient;
            clientInDb.PhoneClient = clientDTO.PhoneClient;
            clientInDb.AddessClient = clientDTO.AddessClient;
            clientInDb.DateBirthClient = clientDTO.DateBirthClient;
            clientInDb.Status = clientDTO.Status;

            var result = await _unitOfWork.ClientRepository.UpdateAsync(clientInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
