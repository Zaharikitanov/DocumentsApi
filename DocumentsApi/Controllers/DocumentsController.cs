using DocumentsApi.Database.Models;
using DocumentsApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsRepository _repository;

        public DocumentsController(IDocumentsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _repository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Document>> Create(Document document)
        {
            try
            {
                document.Id = Guid.NewGuid();
                return CreatedAtAction("CreateDocument", await _repository.CreateAsync(document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
