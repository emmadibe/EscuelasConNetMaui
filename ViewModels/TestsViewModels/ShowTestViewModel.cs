using EscuelaConMaui.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EscuelaConMaui.ViewModels.TestsViewModels
{
    public partial class ShowTestViewModel : ObservableObject
    {
        //INYECCIÓN DE DEPENDENCIAS
        private readonly ITests _iTestsFunctions;
        private readonly GeneralsIFunctions _generalsIFunctions;
        private readonly IStudents _students;
        private readonly IstudentXtest _studentXtest;

        //PROPIEDADES
        [ObservableProperty]
        private int testId;
        [ObservableProperty]
        private TestsModels testModels = new();

        [ObservableProperty]
        private ObservableCollection<StudentsModels> studentes = new();
        public string LabelTest
        {
            get => testModels != null && testModels.Id != 0 ? $"Datos del Test:\n Id: {MyCurrentTest.TestId}\n Name: {MyCurrentTest.TestName}\n TestNoumber: {MyCurrentTest.TestNoumber}\n Course: {MyCurrentCourse.courseName} del colegio {MyCurrentCourse.courseSchool}." : "Cargando...";
            set => _generalsIFunctions.OnPropertyChanged(nameof(LabelTest));
        }

        public List<int> Notes => Enumerable.Range(1, 10).ToList();

        [ObservableProperty]
        private int note = 0;

        //BUILDERS
        public ShowTestViewModel(int testId)
        {
            this.testId = testId;
            _iTestsFunctions = App.Current.Services.GetRequiredService<ITests>();
            _generalsIFunctions = App.Current.Services.GetRequiredService<GeneralsIFunctions>();
            _students = App.Current.Services.GetRequiredService<IStudents>();
            _studentXtest = App.Current.Services.GetRequiredService<IstudentXtest>();
            InitializeTest(testId).GetAwaiter().GetResult(); //De esta manera, me aseguro que el Label de la view se cargue únicamente cuando este método termina de ejecutarse.
        }

        public ShowTestViewModel() { }

        //MÉTODOS
        private async Task InitializeTest(int id)
        {
            await GetMyTest(id);
            _generalsIFunctions.OnPropertyChanged(nameof(LabelTest)); // Notificar cambio después de cargar los datos
            GetMyStudents();
        }
        public async Task GetMyTest(int Id)
        {
            Debug.WriteLine($"El id es {Id}");
            this.testModels = await _iTestsFunctions.GetById(Id);
            MyCurrentTest.CourseId = this.testModels.CourseId;
            MyCurrentTest.TestNoumber   = this.testModels.TestNoumber;
            MyCurrentTest.TestId = this.testModels.Id;
            MyCurrentTest.TestName = this.testModels.Name;
        }

        public async Task GetMyStudents()
        {
            List<StudentsModels> MyStudents = await this._students.GetAllByCourseId(MyCurrentCourse.courseId);
            foreach (StudentsModels student in MyStudents)
            {
                this.Studentes.Add(student);
            }
            
        }

        [RelayCommand]
        public async Task AddNote(int studentId)
        {
            int idTestXStudent = await _studentXtest.GetIdByStudentIdAndTestId(studentId, MyCurrentTest.TestId); //Debo obtener el ID del registro de la tabla intermedia que quiero actualiar. Pues, la consulta UPDATE actualiza el registro identificado por el primaryKey.
               
           int rowAfectadas = await _studentXtest.UpdateTestXStudent(new TestsXStudentsModels { StudentId = studentId, TestId = MyCurrentTest.TestId, Nota = this.Note, Id = idTestXStudent });
            Debug.WriteLine($"Columnas afectadas: {rowAfectadas}");
            TraerTodoDefinitivoModels TTDM = new();
            TTDM.UpdateNota(MyCurrentTest.TestName, Note);
        }

        [RelayCommand]
        public async Task Back()
        {
            await Shell.Current.GoToAsync("ShowAllTests");
        }
    }
}
