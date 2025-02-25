using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Models
{
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
