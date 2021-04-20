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
    public class UserController : BaseApiController
    {
        #region Constructor
        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Endpoints
        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteByIdAsync))]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _unitOfWork.UserRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [ActionName(nameof(GetAsync))]
        public async Task<IEnumerable<User>> GetAsync() => await _unitOfWork.UserRepository.GetAllAsync();

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<User> GetByIdAsync(int id) => await _unitOfWork.UserRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateUserDTO userDTO)
        {
            var user = new User
                (
                    userDTO.PictureUser,
                    userDTO.DisplaynameUser,
                    userDTO.EmailUser,
                    userDTO.PasswordUser,
                    userDTO.PhoneUser ,
                    userDTO.AddessUser,
                    userDTO.DateBirthUser
                );

            var newUser = await _unitOfWork.UserRepository.InsertAsync(user);
            if (newUser is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newUser.CiUser }, newUser);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateAsync))]
        public async Task<IActionResult> UpdateAsync(int id, UpdateUserDTO userDTO)
        {
            if (id != userDTO.CiUser)
            {
                return BadRequest();
            }

            var userInDb = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (userInDb is null)
            {
                return NotFound();
            }

            userInDb.PictureUser = userDTO.PictureUser;
            userInDb.DisplaynameUser = userDTO.DisplaynameUser;
            userInDb.EmailUser = userDTO.EmailUser;
            userInDb.PasswordUser = userDTO.PasswordUser;
            userInDb.PhoneUser = userDTO.PhoneUser;
            userInDb.AddessUser = userDTO.AddessUser;
            userInDb.DateBirthUser = userDTO.DateBirthUser;
            userInDb.Status = userDTO.Status;          

            var result = await _unitOfWork.UserRepository.UpdateAsync(userInDb);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion Endpoints
    }
}
