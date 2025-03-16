using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;
using EscuelaConMaui.Services.DataBase;
using SQLite;

namespace EscuelaConMaui.Helpers
{
    public class SQLLiteHelper<T> : SQLLiteBase where T : AbstractBaseClass, new() //Como quiero que me sirva para cualquier tabla, a la clase la hago de tipo genérico; pero, es genérico con una restricción: extiende de BaseModels. O sea, solo las clases que hereden de BaseModels pueden emplear los métodos aquí presentes. Al extender de BaseModels, sabemos ya que tiene el atributo ID. 
        ///new() especifica que T debe tener un constructor público sin parámetros. Esto permite que la clase SQLLiteHelper<T> pueda crear nuevas instancias de T cuando sea necesario, por ejemplo, para mapear datos de la base de datos a objetos.
        //Esta clase es la encargada de getionar la conexión a mi base de datos. 
        //Al heredar de SQLLIteBase cada vez que use SQLLitehElper va a ir a SQLLiteBAse a obtener la conexión. 
    {
        //En esta clase genérica implemento los métodos genéricos de mi CRUD. 
        //Este método me sirve para cualquier tabla de mi bdd. Por eso es genérico. Al ser T una extensión de la clase abstracta AbstractBaseClass, tiene todos los campos comunes a todas las tables, como id. 
        public List<T> GetAllData()
            => _connection.Table<T>().ToList(); //Me retorna una lista. Una lista de cursos, por ejemplo, en donde cada elemento de la colección List es una instancia de CourseModels.
        public int Add(T row)
        {
            _connection.Insert(row);
            return row.Id;
        }

        public int Update(T row)
            => _connection.Update(row);

        public int Delete(T row)
            => _connection.Delete(row);

        public T Get(int ID)
            => _connection.Table<T>().Where(WaitCallback => WaitCallback.Id == ID).FirstOrDefault();

        public TableQuery<T> returnTableQuery(T t)
            => _connection.Table<T>();

        // Nuevo método para ejecutar consultas SQL crudas. Lo usaré para traerme TODOS LOS DATOS
        public List<TResult> ExecuteSql<TResult>(string sql, params object[] parameters) where TResult : new()
        {
            return _connection.Query<TResult>(sql, parameters);
        }

    }



}

