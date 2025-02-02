using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Data;
using DataLayer.Entities;
using Application.Interfaces;
using System.Threading;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        [ProducesResponseType(typeof(List<Client>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                    return StatusCode(StatusCodes.Status499ClientClosedRequest);

                var data = await _clientService.GetAllClientsAsync(cancellationToken);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);    
            }
            catch (OperationCanceledException)
            { 
                return StatusCode(StatusCodes.Status499ClientClosedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<ActionResult<Client>> GetClientById(int id, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                    return StatusCode(StatusCodes.Status499ClientClosedRequest);

                var data = await _clientService.GetClientByIdAsync(id, cancellationToken);

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(int id, Client client)
        //{
        //    if (id != client.ClientId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(Client), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<ActionResult<Client>> PostClient(Client client, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                    return StatusCode(StatusCodes.Status499ClientClosedRequest);

                var id = await _clientService.CreateClientAsync(client, cancellationToken);

                return CreatedAtAction(nameof(GetClients), new { id }, client);
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE: api/Client/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClient(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clients.Remove(client);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ClientExists(int id)
        //{
        //    return _context.Clients.Any(e => e.ClientId == id);
        //}
    }
}
