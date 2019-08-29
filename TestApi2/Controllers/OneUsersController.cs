using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi2.Models;

namespace TestApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneUsersController : ControllerBase
    {
        private readonly TestApi2Context _context;

        public OneUsersController(TestApi2Context context)
        {
            _context = context;
        }

        // GET: api/OneUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OneUser>>> GetOneUser()
        {
            return await _context.OneUser.ToListAsync();
        }

        // GET: api/OneUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OneUser>> GetOneUser(int id)
        {
            var oneUser = await _context.OneUser.FindAsync(id);

            if (oneUser == null)
            {
                return NotFound();
            }

            return oneUser;
        }

        // PUT: api/OneUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOneUser(int id, OneUser oneUser)
        {
            if (id != oneUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(oneUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OneUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OneUsers
        [HttpPost]
        public async Task<ActionResult<OneUser>> PostOneUser(OneUser oneUser)
        {
            _context.OneUser.Add(oneUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneUser", new { id = oneUser.Id }, oneUser);
        }

        // DELETE: api/OneUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OneUser>> DeleteOneUser(int id)
        {
            var oneUser = await _context.OneUser.FindAsync(id);
            if (oneUser == null)
            {
                return NotFound();
            }

            _context.OneUser.Remove(oneUser);
            await _context.SaveChangesAsync();

            return oneUser;
        }

        private bool OneUserExists(int id)
        {
            return _context.OneUser.Any(e => e.Id == id);
        }
    }
}
