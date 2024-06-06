using APBD8.DTO;
using APBD8.Models;
using EfCodeFirst.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD8.Controller;
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase {
    private readonly AppDbContext _context;

    public DoctorsController(AppDbContext context)
    {
            _context = context;
    }

    // GET: api/Doctors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
    {
        return await _context.Doctors
            .Select(d => new DoctorDto
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email
            })
            .ToListAsync();
    }

    // GET: api/Doctors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        var doctorDto = new DoctorDto
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };

        return doctorDto;
    }

        // POST: api/Doctors
    [HttpPost]
    public async Task<ActionResult<DoctorDto>> PostDoctor(CreateDoctorDto createDoctorDto)
    {
        var doctor = new Doctor
        {
            FirstName = createDoctorDto.FirstName,
            LastName = createDoctorDto.LastName,
            Email = createDoctorDto.Email
        };

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();

        var doctorDto = new DoctorDto
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };

        return CreatedAtAction(nameof(GetDoctor), new { id = doctorDto.IdDoctor }, doctorDto);
    }

    // PUT: api/Doctors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDoctor(int id, UpdateDoctorDto updateDoctorDto)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor == null)
        {
            return NotFound();
        }

        doctor.FirstName = updateDoctorDto.FirstName;
        doctor.LastName = updateDoctorDto.LastName;
        doctor.Email = updateDoctorDto.Email;

        _context.Entry(doctor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DoctorExists(id))
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

    // DELETE: api/Doctors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return NotFound();
        }

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DoctorExists(int id)
    {
        return _context.Doctors.Any(e => e.IdDoctor == id);
    }
}