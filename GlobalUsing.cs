global using EscuelaConMaui.Interfaz;
global using EscuelaConMaui.Services;
global using EscuelaConMaui.ViewModels;
global using EscuelaConMaui.ViewModels.TeachersViewModels;
global using EscuelaConMaui.Views;
global using EscuelaConMaui.Enums;
global using EscuelaConMaui.Helpers;
global using EscuelaConMaui.Services.DataBase;

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using System.Collections.ObjectModel;
global using SQLite;

//En la carpeta GlobalUsing pongo, con la palabra reservada global, las carpetas a las cuales requiero acceso recurrente. Voy a necesitar entrar, por ejemplo, muchas veces a la carpeta interfaz. Entonces, poniendo su acceso en esta clase y bajo la palabra reservada global, me ahorro tener que poner el namespace en un montón de archivos. 