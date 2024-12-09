using System.Windows.Input;
using ListaTareasSergioDiez.Models;

namespace ListaTareasSergioDiez.MVVM.ViewModels
{
    public class PantallaDetalleViewModel : BindableObject
    {
        private Tarea tarea;

        // Propiedad vinculada a la tarea actual.
        public Tarea Tarea
        {
            get => tarea;
            set
            {
                if (tarea != value)
                {
                    tarea = value;
                    OnPropertyChanged(); // Notifica el cambio a la interfaz de usuario
                }
            }
        }

        // Comandos para guardar y cancelar
        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        // Constructor del ViewModel.
        public PantallaDetalleViewModel()
        {
            Tarea = new Tarea(); // Se inicializa para evitar errores de referencia nula
            GuardarCommand = new Command(OnGuardar);
            CancelarCommand = new Command(OnCancelar);
        }

        // Método para guardar los cambios y enviar el mensaje.
        private async void OnGuardar()
        {
            // Validar que la tarea no sea nula antes de enviar el mensaje
            if (Tarea == null)
                return;

            // Enviar el mensaje con la tarea actualizada o nueva
            MessagingCenter.Send(this, "ActualizarTarea", Tarea);

            // Regresar a la pantalla anterior
            if (Application.Current?.MainPage?.Navigation != null)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        // Método para cancelar y regresar sin cambios.
        private async void OnCancelar()
        {
            // Regresar a la pantalla anterior sin realizar cambios
            if (Application.Current?.MainPage?.Navigation != null)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
