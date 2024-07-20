using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMS.Model.Common.Constants;
using PMS.Model.DTOs.Request.Client;
using PMS.Model.DTOs.Response;
using PMS.Model.DTOs.Response.Client;
using PMS.Model.Models;
using PMS.Service.Interface;

namespace PMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientService clientService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Get list of all clients.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            IEnumerable<Client> clients = await clientService.GetAllClientsIncludePlan();

            IEnumerable<ClientResponseDTO> result = mapper.Map<IEnumerable<ClientResponseDTO>>(clients);

            return Ok(new ApiResponseDTO(result));
        }

        /// <summary>
        /// Add new client.
        /// </summary>
        /// <param name="clientRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddClient(ClientRequestDTO clientRequestDTO)
        {
            Client client = mapper.Map<Client>(clientRequestDTO);

            await clientService.InsertAsync(client);

            return Ok(new ApiResponseDTO(client.Id, ClientConstants.INSERT_SUCCESS_MESSAGE));
        }

        /// <summary>
        /// Delete client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            Client client = await clientService.GetAsync(client => client.Id == id) ?? throw new BadHttpRequestException(ClientConstants.NOT_FOUND_MESSAGE);

            await clientService.DeleteAsync(client);

            return Ok(new ApiResponseDTO(client.Id, ClientConstants.DELETE_SUCCESS_MESSAGE));

        }
    }
}
