using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contexts;
using RepositoryPattern.Entities;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonPhoneController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public PersonPhoneController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonPhoneNumber>>> GetAll()
        {
            try
            {
                var response = await _context.PersonPhoneNumbers.Include(p => p.Person).ToListAsync();
                if (response.Count > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneNumber>> getById(int id)
        {
            try
            {
                var response = await _context.PersonPhoneNumbers.Where(PersonPhoneNumbers => PersonPhoneNumbers.Id == id).FirstOrDefaultAsync();
                if (response == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<PersonPhoneNumberDTO>> AddPersonPhoneNumbers([FromBody] PersonPhoneNumberDTO model)
        {
            try
            {
                var dbPersonPhone = _mapper.Map<PersonPhoneNumber>(model);

                await _context.PersonPhoneNumbers.AddAsync(dbPersonPhone);
                await _context.SaveChangesAsync();
                
                return Ok(dbPersonPhone);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonPhoneNumbers([FromBody] PersonPhoneNumber model, int id)
        {
            try
            {
                var db_PersonPhoneNumbers = await _context.PersonPhoneNumbers.Where(PersonPhoneNumbers => PersonPhoneNumbers.Id == id).FirstOrDefaultAsync();
                if (db_PersonPhoneNumbers == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.PersonPhoneNumbers.Update(db_PersonPhoneNumbers);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonPhoneNumbers(int id)
        {
            try
            {
                var db_PersonPhoneNumbers = await _context.PersonPhoneNumbers.Where(PersonPhoneNumbers => PersonPhoneNumbers.Id == id).FirstOrDefaultAsync();
                if (db_PersonPhoneNumbers == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.PersonPhoneNumbers.Remove(db_PersonPhoneNumbers);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}