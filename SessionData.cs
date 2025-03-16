using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui
{
    public static class SessionData 
    {
        public static string? SessionName { get; set; }
        public static string? SessionLastName { get; set; } 
        public static string? SessionEmail { get; set; }
        public static int SessionId { get; set; }
        public static int SessionAge { get; set; }
        public static Rama SessionRama { get; set; }
    }
}
