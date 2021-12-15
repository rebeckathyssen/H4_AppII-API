using System;
using System.Threading.Tasks;
using H4_API.Core;
using H4_API.UseCases.Base;
using Microsoft.AspNetCore.Mvc;

namespace H4_API.Web.Controllers.Base
{
    [ApiController]
    public class BaseController<TValue> : ControllerBase where TValue : class, IEntity, new()
    {
        protected readonly IBaseUseCase<TValue> UseCase;

        public BaseController(IBaseUseCase<TValue> useCase)
        {
            UseCase = useCase;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await UseCase.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            try
            {
                return Ok(await UseCase.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TValue value)
        {
            try
            {
                return Ok(await UseCase.Create(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            try
            {
                return Ok(new TValue());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TValue value)
        {
            try
            {
                return Ok(await UseCase.Update(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await UseCase.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}