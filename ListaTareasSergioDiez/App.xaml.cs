using ListaTareasSergioDiez.MVVM.Views;

namespace ListaTareasSergioDiez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PantallaPrincipalView());
        }
    }
}
