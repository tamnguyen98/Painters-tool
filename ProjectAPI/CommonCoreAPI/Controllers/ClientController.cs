using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientData _clientData;

        public ClientController(IClientData clientData)
        {
            _clientData = clientData;
        }

        [HttpPost("newProject")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ClientModel client)
        {
            int id = await _clientData.NewClient(client);
            return Ok(id);
        }

        [HttpGet("byHouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [controller]/byHouse?house=[house]&street=[street]
        public async Task<IActionResult> Get(string house, string? street)
        {
            if (house.Length <= 1)
                return BadRequest();

            var project = await _clientData.GetProjectByHouse(house, street);

            if (project == null)
                return NotFound();

            return Ok(project);
        }
    }
}
