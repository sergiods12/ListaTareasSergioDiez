using ListaTareasSergioDiez.Models;
using ListaTareasSergioDiez.MVVM.ViewModels;

namespace ListaTareasSergioDiez.MVVM.Views
{
    public partial class PantallaDetalle : ContentPage
    {
        public PantallaDetalle(Tarea tarea) // Recibe la tarea para editar
        {
            InitializeComponent();
            BindingContext = new PantallaDetalleViewModel { Tarea = tarea };
        }
    }
}
