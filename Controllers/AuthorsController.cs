using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly LibraryContext _context;
    private readonly IConfiguration _config;
    public AuthorsController(IConfiguration config, LibraryContext context)
    {
        _config = config;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        return await _context.Authors.Include(a => a.Books).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthor(int id)
    {
        var Author = await _context.Authors.Include(a => a.Books)
                                           .FirstOrDefaultAsync(a => a.Id == id);
        if (Author == null)
            return NotFound();

        return Author;
    }

    [HttpPost]
    public async Task<ActionResult<Author>> PostAuthor(Author Author)
    {
        _context.Authors.Add(Author);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuthor), new { id = Author.Id }, Author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuthor(int id, Author Author)
    {
        if (id != Author.Id)
            return BadRequest();

        _context.Entry(Author).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var Author = await _context.Authors.FindAsync(id);
        if (Author == null)
            return NotFound();

        _context.Authors.Remove(Author);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
