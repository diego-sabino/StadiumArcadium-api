using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity, TService>
        : ControllerBase where TEntity : class where TService : IService<TEntity>
    {
        private readonly TService _service;

        protected BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var entities = await _service.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TEntity>> GetById(string id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new { message = $"{typeof(TEntity).Name} not found" });
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            await _service.CreateAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TEntity entity)
        {
            var existingEntity = await _service.GetByIdAsync(id);

            if (existingEntity == null)
            {
                return NotFound(new { message = $"{typeof(TEntity).Name} not found" });
            }

            entity.GetType().GetProperty("Id").SetValue(entity, id);

            await _service.UpdateAsync(id, entity);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingEntity = await _service.GetByIdAsync(id);

            if (existingEntity == null)
            {
                return NotFound(new { message = $"{typeof(TEntity).Name} not found" });
            }

            await _service.RemoveAsync(id);

            return NoContent();
        }
    }
}
