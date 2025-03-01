using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Models
{
    [Table("students")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public class StudentsModels : AbstractBaseClass //hereda de Person. 
    {
        [MaxLength(30)]
        protected string? Name { get; set; }
        [MaxLength(30)]

        protected string? LastName { get; set; }
        protected int? Age { get; set; }
        protected string? Email { get; set; }
    }
}
