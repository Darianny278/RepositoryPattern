using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Contexts;
using RepositoryPattern.Entities;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public PersonController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAll(){
            try{
                return Ok(await _unitOfWork.PersonRepository.GetAllAsync());
                // var response = await _context.People.ToListAsync();
                // if(response.Count>0){
                //     return Ok(response);
                // }else{
                //     return NotFound();
                // }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // // [HttpGet("{id}")]
        // // public async Task<ActionResult<PersonDTO>> GetById(int id){
        // //     try{
        // //         // var response = await _context.People.Where(person=>person.Id == id).FirstOrDefaultAsync();
        // //         // if(response == null){
        // //         //     return NotFound();
        // //         // }else{
        // //         //     return Ok(response);
        // //         // }
        // //     }catch(Exception ex){
        // //         return BadRequest(ex.Message);
        // //     }
        // // }

        // // [HttpPost]
        // // public async Task<ActionResult<PersonDTO>> SavePerson([FromBody] PersonDTO model){
        // //     try{
        // //         // var dbPerson = _mapper.Map<Person>(model);

        // //         // await _context.People.AddAsync(dbPerson);
        // //         // await _context.SaveChangesAsync();
                
        // //         // return Ok(dbPerson);

        // //     }catch(Exception ex){
        // //         return BadRequest(ex.Message);
        // //     }
        // // }

        // // [HttpPut("{id}")]
        // // public async Task<ActionResult> UpdatePerson([FromBody] PersonDTO model, int id){
        // //     try{
        // //         // var dbPerson = await _context.People.Where(person => person.Id == id).FirstOrDefaultAsync();
                
        // //         // if(dbPerson==null){
        // //         //     return NotFound();
        // //         // }else{
        // //         //     dbPerson.FirstName = model.FirstName;
        // //         //     dbPerson.LastName = model.LastName;
        // //         //     dbPerson.Age = model.Age;
        // //         //     _context.People.Update(dbPerson);
        // //         //     await _context.SaveChangesAsync();
        // //         //     return Ok();
        // //         // }
        // //     }catch(Exception ex){
        // //         return BadRequest(ex.Message);
        // //     }
        // // }

        // // [HttpDelete("{id}")]
        // // public async Task<ActionResult> DeletePerson(int id){
        //     try{
        //         // var dbPerson = await _context.People.Where(person=> person.Id == id).FirstOrDefaultAsync();
        //         // if(dbPerson==null){
        //         //     return NotFound();
        //         // }else{
        //         //     _context.People.Remove(dbPerson);
        //         //     await _context.SaveChangesAsync();
        //         //     return Ok();
        //         // }
        //     }catch(Exception ex){
        //         return BadRequest(ex.Message);
        //     }
        // }
    }
}