using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly DataContext _context;

        public GroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Group/5    
        [HttpGet("{id}")]
        [Authorize(Policy = "group:read")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var Group = await _context.Groups.FindAsync(id);

            if (Group == null)
            {
                return NotFound();
            }

            return Group;
        }

        // PUT: api/Group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "group:edit")]
        public async Task<IActionResult> PutGroup(int id, Group Group)
        {
            if (id != Group.GroupId)
            {
                return BadRequest();
            }

            _context.Entry(Group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group Group)
        {
            _context.Groups.Add(Group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = Group.GroupId }, Group);
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var Group = await _context.Groups.FindAsync(id);
            if (Group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(Group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
