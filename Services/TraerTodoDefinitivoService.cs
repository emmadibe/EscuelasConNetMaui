using EscuelaConMaui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui.Services
{
    public class TraerTodoDefinitivoService : ITraerTodoDefinitivo
    {
        private List<TraerTodoDefinitivoModels> traerTodosDefinitivo = new();
        List<string> TestLists = new List<string>();
        Dictionary<string, List<string>> StudentsAndTestsNameDictionary = new Dictionary<string, List<string>>();   
        string? StudentName;
        string? TestNameAndNoumber;
        int Note = 0;
        int exist = 88;
        public Task<List<TraerTodoDefinitivoModels>> pasarRegistrosDeUnaColeccionAOtra(List<TraerTodoModels> traerTodos) //En este método voy a pasar mis registros de la colección original, que posee dos campos string; a otro que posee un string y un diccionario. 
        {
            for(int i = 0; i < traerTodos.Count(); i++) //Voy iterando la colección originar para pasar los registros a la otra colección. 
            {
                StudentName = traerTodos[i].NameAndLastName;
                TestNameAndNoumber = traerTodos[i].NoumberAndNameTest;
                Note = (int) traerTodos[i].Nota;
                exist = existStudent(StudentName);
                if (exist == -1)//Si no existe el nombre del estudiante en la colección, lo agrego. Y ya sé que no va a tener ese examen así que lo agrego también. 
                {
                    Dictionary<string, int> testAndNot = new Dictionary<string, int>();
                    testAndNot.Add(TestNameAndNoumber, Note);
                    TraerTodoDefinitivoModels traerTodoDefinitivoModels = new(StudentName, testAndNot);
                    traerTodosDefinitivo.Add(traerTodoDefinitivoModels);
                }
                else
                {
                    if (!ExistTestInStudent(StudentName, TestNameAndNoumber))
                    {
                        traerTodosDefinitivo[exist].TestAndNote.Add(TestNameAndNoumber, Note);
                    }
                }
                AddTestToStudentDictionary(StudentName, TestNameAndNoumber);
            }

            return Task.FromResult(traerTodosDefinitivo);
        }

        public void AddTestToStudentDictionary(string student, string test)
        {
            if (StudentsAndTestsNameDictionary.ContainsKey(student))
            {
                StudentsAndTestsNameDictionary[student].Add(test);
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(test);
                StudentsAndTestsNameDictionary.Add(student, list);
            }
        }

        public bool ExistTestInStudent(string studentName, string test)
        {
            bool exist = false;
            if (StudentsAndTestsNameDictionary.ContainsKey(studentName)) //Primero, verifico que contenga la key; sino, ya sé que es false.
            {
                for(int i = 0; i < StudentsAndTestsNameDictionary [studentName].Count; i++)
                {
                    string nameTest = StudentsAndTestsNameDictionary[studentName][i];
                    if(test.Equals(nameTest)) { exist = true; break; }
                }
            }
            return exist;
        }
        public int existStudent(string studentName) //En este método corroboro si ya existe el estudiante en la colección definitiva. 
        {
            int existe = -1;
            for(int i = 0; i < traerTodosDefinitivo.Count; i++ ) 
            {
                string palabraAComparar = traerTodosDefinitivo[i].NameAndLastName;                
                if (studentName.Equals(palabraAComparar))
                {
                    existe = i;
                    break;//Corto el bucle porque ya encontré el nombre.
                }
            }
            return existe;
        }
    
    }

       
}

