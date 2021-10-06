using DemoWebApi.Interface;
using DemoWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Repository
{
    public class StudentRepository : IDataInterface<Student>
    {
        readonly TestDbContext _testDbContext;

        public StudentRepository(TestDbContext context)
        {
            _testDbContext = context;
        }
        public async Task<int> Add(Student entity)
        {
            if (_testDbContext != null)
            {
               await _testDbContext.Students.AddAsync(entity);
               await _testDbContext.SaveChangesAsync();
               return entity.RollNo;
            }
            return 0;
        }

        public async Task<int> Delete(Student entity)
        {
            int result = 0;
            if (_testDbContext != null)
            {
                _testDbContext.Students.Remove(entity);
                result= await _testDbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<Student> Get(long id)
        {
            if (_testDbContext != null)
            {
                return await _testDbContext.Students
                  .FirstOrDefaultAsync(s => s.RollNo == id);
            }
            return null;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            if (_testDbContext != null)
            {
                return await _testDbContext.Students.ToListAsync();
            }
            return null;
        }

        public async Task Update(Student student, Student entity)
        {
            if (_testDbContext != null)
            {
                student.FirstName = entity.FirstName;
                student.LastName = entity.LastName;
                student.DateOfBirth = entity.DateOfBirth;
                student.Email = entity.Email;
                student.ContactNo = entity.ContactNo;
                student.Gender = entity.Gender;
               await _testDbContext.SaveChangesAsync();
            }
        }
    }
}
