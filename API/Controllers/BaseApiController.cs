using Application.API.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        #region Properties
        public readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructors

        public BaseApiController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        #endregion Constructors
    }
}
