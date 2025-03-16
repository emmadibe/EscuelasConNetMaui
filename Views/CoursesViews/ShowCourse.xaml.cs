using EscuelaConMaui.ViewModels.CoursesViewModels;

namespace EscuelaConMaui.Views.CoursesViews;

[QueryProperty(nameof(CourseId), "courseId")] //Recibo la variable "courseId". Esa variable es enviada desde MainMenuTeacherViewModels. Su valor lo asigno a la propiedad CourseId.
public partial class ShowCourse : ContentPage
{
    public int CourseId
    {
        set
        {
            // Pasas el valor directamente al crear el ViewModel para que se lo asigne a la popiedad courseId.
            BindingContext = new ShowCourseViewModels(value);
        }
    }
    public ShowCourse()
    {
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<ShowCourseViewModels>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase ShowCourseViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
        Loaded += (s, e) => ConstruirTablaDinamica();
    }

    private void ConstruirTablaDinamica()
    {
        var viewModel = BindingContext as ShowCourseViewModels;
        if (viewModel == null || viewModel.StudentsList == null || !viewModel.StudentsList.Any()) return;

        // Limpiar el Grid para evitar duplicados si se reconstruye
        DynamicGrid.Children.Clear();
        DynamicGrid.ColumnDefinitions.Clear();
        DynamicGrid.RowDefinitions.Clear();

        // Obtener todos los exámenes únicos de la colección StudentsList
        var examenesUnicos = viewModel.StudentsList
            .SelectMany(s => s.TestAndNote.Keys)
            .Distinct()
            .OrderBy(k => k)
            .ToList();

        // Configurar las definiciones de columnas
        DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star }); // Nombre y Apellido
        foreach (var examen in examenesUnicos)
        {
            DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star }); // Columna para cada examen
        }

        // Fila de encabezado
        DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        var labelNombre = new Label
        {
            Text = "Nombre y Apellido",
            FontAttributes = FontAttributes.Bold,
            BackgroundColor = Colors.LightGray,
            HorizontalTextAlignment = TextAlignment.Center
        };
        Grid.SetRow(labelNombre, 0);
        Grid.SetColumn(labelNombre, 0);
        DynamicGrid.Children.Add(labelNombre);

        // Encabezados de exámenes
        for (int i = 0; i < examenesUnicos.Count; i++)
        {
            var labelExamen = new Label
            {
                Text = examenesUnicos[i],
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Colors.LightGray,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Grid.SetRow(labelExamen, 0);
            Grid.SetColumn(labelExamen, i + 1);
            DynamicGrid.Children.Add(labelExamen);
        }

        // Filas de datos
        for (int fila = 0; fila < viewModel.StudentsList.Count; fila++)
        {
            DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            var estudiante = viewModel.StudentsList[fila];

            // Nombre y Apellido
            var labelEstudiante = new Label
            {
                Text = estudiante.NameAndLastName,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Grid.SetRow(labelEstudiante, fila + 1);
            Grid.SetColumn(labelEstudiante, 0);
            DynamicGrid.Children.Add(labelEstudiante);

            // Notas de los exámenes
            for (int i = 0; i < examenesUnicos.Count; i++)
            {
                var examen = examenesUnicos[i];
                var labelNota = new Label
                {
                    Text = estudiante.TestAndNote.ContainsKey(examen) ? estudiante.TestAndNote[examen].ToString() : "-",
                    HorizontalTextAlignment = TextAlignment.Center
                };
                Grid.SetRow(labelNota, fila + 1);
                Grid.SetColumn(labelNota, i + 1);
                DynamicGrid.Children.Add(labelNota);
            }
        }
    }
}