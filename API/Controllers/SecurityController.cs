using Application.API.DTOs;
using Application.API.Interfaces.Repositories;
using Application.API.Repositories;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : BaseApiController
    {
        private readonly ISecurityService _securityService;

        #region Constructor
        public SecurityController(IUnitOfWork unitOfWork, ISecurityService securityService) : base(unitOfWork)
        {
            _securityService = securityService;
        }
        #endregion
        #region Endpoints
        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<Security> GetByIdAsync(int id) => await _unitOfWork.SecurityRepository.GetByIdAsync(id);

        [HttpPost]
        [ActionName(nameof(InsertAsync))]
        public async Task<IActionResult> InsertAsync(CreateSecurityDTO securityDTO)
        {
            var security = new Security
                (
                    securityDTO.Users,
                    securityDTO.UserName,
                    securityDTO.Passwordu,
                    (RoleType)securityDTO.Roleu
                    
                );
            //await _securityService.RegisterUser(security);
            var newSecurity = await _unitOfWork.SecurityRepository.InsertAsync(security);
            if (newSecurity is null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newSecurity.Id }, newSecurity);
        }
        #endregion
    }
}
