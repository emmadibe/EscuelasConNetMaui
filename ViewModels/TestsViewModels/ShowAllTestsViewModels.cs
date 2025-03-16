using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.ViewModels.TestsViewModels
{
    public partial class ShowAllTestsViewModels : ObservableObject
    {
        ///INYECCION DE DEPENDENCIAS
        private readonly GeneralsIFunctions _generalFunctions;
        private readonly ITests _testsFunctions;
        ///

        //PROPIEDADES
        private string _labelMyCourse;
        public string LabelMyCourse
        {
            get => $"Curso:\n ID: {MyCurrentCourse.courseId}\n Nombre: {MyCurrentCourse.courseName}\n Escuela: {MyCurrentCourse.courseSchool}\n Materia: {MyCurrentCourse.courseSubject}\n";
            set => this._generalFunctions.OnPropertyChanged();
        }
        [ObservableProperty]
        private ObservableCollection<TestsModels> tests = new(); //Colección, de tipo ObservableCollection, de TestsModels. O sea, cada elemento de mi colección es una instancia de la clase TestsModels.
        ///

        //BUILDER
        public ShowAllTestsViewModels()
        {
            _generalFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _testsFunctions = App.Current.Services.GetRequiredService<ITests>();
            GetAllTests();
        }
        //

        //METODOS
        public async Task GetAllTests()
        {
            List<TestsModels> TestsModelsList = await _testsFunctions.GetAllByCourseId(MyCurrentCourse.courseId); //Ya tengo todos los tests de este curso en la lista.
            //Ahora, debo pasar los elementos de la lista al ObservableCOllection:
            foreach (TestsModels model in TestsModelsList)
            {
                Tests.Add(model); //voy agregando uno por uno.
            }
        }

        [RelayCommand]
        public async Task InTest(int TestId)
        {
            await Shell.Current.GoToAsync($"ShowTest?TestId={TestId}");
        }

        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("ShowCourse");
        }
    }
}
