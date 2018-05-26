using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbDataLibrary.Data;
using DbDataLibrary.Models;
using SCI_lab6.ViewModels;

namespace SCI_lab6.Controllers
{
    [Produces("application/json")]
    [Route("api/tours")]
    public class ToursController : Controller
    {
        private readonly ToursSqliteDbContext _context;

        public ToursController(ToursSqliteDbContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public IEnumerable<TourViewModel> GetTours()
        {
            return _context.Tours.Include(b => b.Client).Include(o => o.TourKind).Select(c =>
                new TourViewModel
                {
                    Id = c.Id,
                    TourKindId = c.TourKindId,
                    ClientId = c.ClientId,
                    TourKind = c.TourKind.Name,
                    Client = c.Client.Name,
                    Name = c.Name,
                    Price = c.Price,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate
                });
        }

        // GET api/values
        [HttpGet("tourkinds")]
        [Produces("application/json")]
        public IEnumerable<TourKind> GetTourKinds()
        {
            return _context.TourKinds.ToList();
        }
        // GET api/values
        [HttpGet("clients")]
        [Produces("application/json")]
        public IEnumerable<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tour = await _context.Tours.SingleOrDefaultAsync(m => m.Id == id);

            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        // PUT: api/Tours/5
        [HttpPut]
        public async Task<IActionResult> PutTour([FromBody] Tour tour)
        {
            if (tour == null)
            {
                return BadRequest();
            }
            if (!TourExists(tour.Id))
            {
                return NotFound();
            }

            _context.Update(tour);
            _context.SaveChanges();
            return Ok(tour);
        }

        // POST: api/Tours
        [HttpPost]
        public async Task<IActionResult> PostTour([FromBody] Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.Id }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tour = await _context.Tours.SingleOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return Ok(tour);
        }

        private bool TourExists(int id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}