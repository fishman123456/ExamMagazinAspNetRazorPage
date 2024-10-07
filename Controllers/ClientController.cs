using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamMagazinAspNetRazorPage.Storage;
using ExamMagazinAspNetRazorPage.Service;
using ExamMagazinAspNetRazorPage.Models;

namespace ExamMagazinAspNetRazorPage.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<List<Client>> ListAll()
        {
            return await _clientService.ListAll();
        }

        [HttpGet("{id:int}")]
        public async Task<Client?> GetById(int id)
        {
            Client? client = await _clientService.GetById(id);
            if (client == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return client;
        }

        [HttpPost]
        public async Task<Client?> Add(Client client)
        {
            Client? result = await _clientService.Add(client);
            if (result == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return result;
        }


        [HttpDelete("{id:int}")]
        public async Task<Client?> RemoveById(int id)
        {
            Client? client = await _clientService.RemoveById(id);
            if (client == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return client;
        }

        [HttpPost("{id:int}")]
        public async Task<Client?> UpdateById(int id, Client client)
        {
            Client? updated = await _clientService.UpdateById(id, client);
            if (updated == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            return updated;
        }
    }
}
