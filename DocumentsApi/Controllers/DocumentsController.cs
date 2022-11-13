using DocumentsApi.Database.Models;
using DocumentsApi.Repository.Interfaces;
using DocumentsApi.Services;
using DocumentsApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsRepository _repository;
        private readonly IMessageProducer _messagePublisher;

        public DocumentsController(IDocumentsRepository repository, IMessageProducer messagePublisher)
        {
            _repository = repository;
            _messagePublisher = messagePublisher;
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
                _messagePublisher.SendMessage(document);

                return CreatedAtAction("Create", await _repository.CreateAsync(document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
