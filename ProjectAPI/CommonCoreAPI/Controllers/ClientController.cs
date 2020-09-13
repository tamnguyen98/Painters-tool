using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCoreAPI.Models;
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

        [HttpPost("NewProject")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ClientModel client)
        {
            int id = await _clientData.NewClient(client);
            return Ok(id);
        }

        [HttpGet("FindProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [controller]/byHouse?house=[house]&street=[street]
        public async Task<IActionResult> Get(int? projectId, string house, string street)
        {
            if (projectId != null)
            {
                var project = await _clientData.GetProjectById((int) projectId);

                if (project == null)
                    return NotFound();

                return Ok(project);
            }
            else if (house != null)
            {
                if (house.Length < 2)
                    return BadRequest();

                var project = await _clientData.GetProjectByHouse(house, street);

                if (project == null)
                    return NotFound();

                return Ok(project);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // /Delete?projectId=[id]
        public async Task<IActionResult> Delete(int projectId)
        {
            await _clientData.DeleteProjectRecord(projectId);

            return Ok();
        }

        [HttpPut("Update")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]ClientModel data)
        {
            Console.WriteLine(data.HouseNum + " " + data.Street);
            //var record = await _clientData.GetProjectByHouse(data.HouseNum, data.Street); // Should replace when query by ID is fix
            var record = await _clientData.GetProjectById(data.Id); // Should replace when query by ID is fix
            if (record == null)
                BadRequest();
            await _clientData.UpdateProject(data);
            return Ok();
        }
    }
}
