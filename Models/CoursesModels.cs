using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace EscuelaConMaui.Models
{
    [Table("courses")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public class CoursesModels : AbstractBaseClass
    {
        [ForeignKey("teachers")] //Defino a la propiedad-campo TeacherId, perteneciente a la clase-modelo-tabla Courses, como una Foreign Key. Esta clave foranea hace referencia al campo Id de la clase-modelo-tabla teachers. EN SQLiteExtensions se asume que el campo al que hace referencia la FK es la Primary KEY de la clase referenciada. Por ello, no tengo que aclararlo. 
        public int TeacherId { get; set; }
        [MaxLength(20)]
        public string? Name { get; set; }    
        [MaxLength(20)]
        public string? School { get; set; }
        [MaxLength(20)]
        public string? Subject { get; set; }
        [MinLength(5)]
        public string? Description { get; set; }
    }
}
