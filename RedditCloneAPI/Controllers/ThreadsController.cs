using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedditCloneAPI.Data;
using Core.Model; 

namespace RedditCloneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThreadsController : ControllerBase
    {
        private readonly RedditCloneContext _context;

        public ThreadsController(RedditCloneContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThreadPost>>> GetThreads()
        {
            return await _context.Threads.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadPost>> GetThread(int id)
        {
            var thread = await _context.Threads.FindAsync(id);

            if (thread == null)
            {
                return NotFound();
            }

            return thread;
        }

        [HttpPost]
        public async Task<ActionResult<ThreadPost>> PostThread([FromBody] ThreadPost thread)
        {
            if (thread == null)
            {
                return BadRequest("Thread data is missing.");
            }

            _context.Threads.Add(thread);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThread), new { id = thread.Id }, thread);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutThread(int id, [FromBody] ThreadPost thread)
        {
            if (thread == null || id != thread.Id)
            {
                return BadRequest("Invalid thread data.");
            }

            _context.Entry(thread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThread(int id)
        {
            var thread = await _context.Threads.FindAsync(id);
            if (thread == null)
            {
                return NotFound();
            }

            _context.Threads.Remove(thread);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThreadExists(int id)
        {
            return _context.Threads.Any(e => e.Id == id);
        }
    }
}
