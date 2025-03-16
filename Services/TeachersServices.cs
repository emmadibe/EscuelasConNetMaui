using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Interfaz;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    public class TeachersServices : ITeachers
    {
        private readonly SQLLiteHelper<TeachersModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public TeachersServices()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<int> DeleteTeacher(TeachersModels teacher)
            => Task.FromResult(db.Delete(teacher)); 
         
        public Task<List<TeachersModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<TeachersModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertTeacher(TeachersModels teacher)
            => Task.FromResult(db.Add(teacher));

        public Task<int> UpdateTeacher(TeachersModels teacher)
            => Task.FromResult(db.Update(teacher));

        public int ExistsTeacher(TeachersModels instance) //Verifico la existencia del usuario. Este ingresó un name y un password. Debo verificar en la tabla teachers de la base de datos que exista algún registro con ese name y ese pass. Si lo encuentra, retorna el Id. 
        {
            if (instance == null)
                return -1; //Ya si es null, significa que no existe en la bdd.

            if (instance is TeachersModels teacher)
            {
                var found = db.returnTableQuery(instance)
                              .ToList() // Trae todos los datos a la memoria  principal (RAM).
                              .FirstOrDefault(x => x is TeachersModels t && //Verifico que sea una instancia de TeacherModel
                                                  t.Name == teacher.Name && //Verifico que el Name ingresado por el usuario se igual al de registro
                                                  t.Password == teacher.Password); //lo mismo con el pass
                return found != null ? found.Id : -1; //Si found es null (no encontrò  un registro con coincidencias) retorna -1; sino, retorna el valor del campo id. Es el operador ternario, un condicional.
            }

            // Fallback por Id si no es TeachersModels. Medio al pedo igual. 
            var foundById = db.returnTableQuery(instance).FirstOrDefault(x => x.Id == instance.Id);
            return foundById != null ? foundById.Id : -1;
        }
    }
}
