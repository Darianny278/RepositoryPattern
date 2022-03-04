using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contexts;
using RepositoryPattern.Entities;

namespace RepositoryPattern.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly Context _context;
        public PersonController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll(){
            try{
                var response = await _context.Persons.ToListAsync();
                if(response.Count>0){
                    return Ok(response);
                }else{
                    return NotFound();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id){
            try{
                var response = await _context.Persons.Where(person=>person.Id == id).FirstOrDefaultAsync();
                if(response == null){
                    return NotFound();
                }else{
                    return Ok(response);
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> SavePerson([FromBody] Person model){
            try{
                await _context.Persons.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok(model);

            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePerson([FromBody] Person model, int id){
            try{
                var dbPerson = await _context.Persons.Where(person => person.Id == id).FirstOrDefaultAsync();
                
                if(dbPerson==null){
                    return NotFound();
                }else{
                    dbPerson.FirstName = model.FirstName;
                    dbPerson.LastName = model.LastName;
                    dbPerson.Age = model.Age;
                    _context.Persons.Update(dbPerson);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id){
            try{
                var dbPerson = await _context.Persons.Where(person=> person.Id == id).FirstOrDefaultAsync();
                if(dbPerson==null){
                    return NotFound();
                }else{
                    _context.Persons.Remove(dbPerson);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}