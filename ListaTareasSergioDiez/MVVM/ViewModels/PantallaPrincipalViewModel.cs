using System.Collections.ObjectModel;
using System.Windows.Input;
using ListaTareasSergioDiez.Models;

namespace ListaTareasSergioDiez.MVVM.ViewModels
{
    public class PantallaPrincipalViewModel : BindableObject
    {
        // Propiedad para la lista de tareas
        public ObservableCollection<Tarea> Tareas { get; set; }

        // Comandos
        public ICommand AgregarTareaCommand { get; }
        public ICommand EliminarTareaCommand { get; }

        // Constructor
        public PantallaPrincipalViewModel()
        {
            // Inicialización de la lista de tareas
            Tareas = new ObservableCollection<Tarea>();

            // Definir los comandos
            AgregarTareaCommand = new Command(OnAgregarTarea);
            EliminarTareaCommand = new Command<Tarea>(OnEliminarTarea);

            // Suscribirse al evento de actualización de tarea
            MessagingCenter.Subscribe<PantallaPrincipalViewModel, Tarea>(this, "ActualizarTarea", (sender, tarea) => HandleActualizarTarea(tarea));
        }


        // Método para manejar la actualización o adición de tareas
        private void HandleActualizarTarea(Tarea tarea)
        {
            // Buscar si la tarea existe por su título
            var tareaExistente = Tareas.FirstOrDefault(t => t.Titulo == tarea.Titulo);

            // Si la tarea existe, actualízala
            if (tareaExistente != null)
            {
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.Completada = tarea.Completada;
            }
            else
            {
                // Si no existe, agrega la tarea nueva
                Tareas.Add(tarea);
            }
        }

        // Método para agregar una nueva tarea
        private void OnAgregarTarea()
        {
            Tareas.Add(new Tarea { Titulo = "Nueva Tarea", Descripcion = "Descripción de la nueva tarea", Completada = false });
        }

        // Método para eliminar una tarea
        private void OnEliminarTarea(Tarea tarea)
        {
            if (tarea != null)
            {
                Tareas.Remove(tarea);
            }
        }
    }

    // Definición del mensaje de actualización de tarea
    public class ActualizarTareaMessage
    {
        public Tarea Value { get; }

        public ActualizarTareaMessage(Tarea tarea)
        {
            Value = tarea;
        }
    }
}
