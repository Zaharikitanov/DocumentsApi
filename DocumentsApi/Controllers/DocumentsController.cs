using DocumentsApi.Database.Models;
using DocumentsApi.Messages;
using DocumentsApi.Repository.Interfaces;
using DocumentsApi.Services;
using DocumentsApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using STP.Lsb.Impl;

namespace DocumentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsRepository _repository;
        private readonly ICloudBus _bus;

        public DocumentsController(IDocumentsRepository repository, ICloudBus bus)
        {
            _repository = repository;
            _bus = bus;
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
                _bus.Publish(
                    message: new DocumentBusMessage
                    {
                        MessageId = Guid.NewGuid().ToString("D"),
                        DocumentId = document.Id,
                        DocumentName = document.DocumentName,
                        Version = document.Version,
                        FileName = document.FileName,
                        FileSize = document.FileSize,
                    }, 
                    expiration: ExpirationBase.MaxExpiration);

                return CreatedAtAction("Create", await _repository.CreateAsync(document));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
