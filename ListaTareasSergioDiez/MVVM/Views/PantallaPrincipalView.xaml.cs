using Microsoft.Maui.Controls;
using ListaTareasSergioDiez.MVVM.ViewModels;
using ListaTareasSergioDiez.Models;

namespace ListaTareasSergioDiez.MVVM.Views
{
    public partial class PantallaPrincipalView : ContentPage
    {
        public PantallaPrincipalView()
        {
            InitializeComponent();
            BindingContext = new PantallaPrincipalViewModel();
        }

        private async void OnEditarClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Tarea tarea)
            {
                // Se pasa la tarea al constructor de PantallaDetalle
                await Navigation.PushAsync(new PantallaDetalle(tarea)); 
            }
        }

    }
}
