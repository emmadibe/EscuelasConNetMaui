using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    class StudentsService : IStudents
    {
        public Task<int> DeleteStudent(StudentsModels student)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentsModels>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StudentsModels> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertStudent(StudentsModels student)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStudent(StudentsModels student)
        {
            throw new NotImplementedException();
        }
    }
}
