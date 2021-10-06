using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApi.Filters;
using DemoWebApi.Interface;
using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [ServiceFilter(typeof(LogActionFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataInterface<Student> _dataRepository;
        public StudentController(IDataInterface<Student> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Student> students = await _dataRepository.GetAll();
            if(students!=null)
            {
                return Ok(students);
            }
            return NoContent();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Student student = await _dataRepository.Get(id);
            if (student != null)
            {
              return Ok(student); 
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }
            int Rollno= await _dataRepository.Add(student);
            if (Rollno != 0)
            {
                return CreatedAtRoute("Get", new { Id = student.RollNo }, student);//Created();
            }
            return BadRequest("Record doesn't added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student is null.");
            }
            Student studentToUpdate = await _dataRepository.Get(id);
            if (studentToUpdate == null)
            {
                return NotFound("The Student record couldn't be found.");
            }
            await _dataRepository.Update(studentToUpdate, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Student student = await _dataRepository.Get(id);
            if (student == null)
            {
                return NotFound("The student record couldn't be found.");
            }            
            int result = await _dataRepository.Delete(student);
            if (result != 0)
            {
                return Ok("Record Deleted Successfully");
            }
            return BadRequest("Record doesn't deleted");
        }
    }
}