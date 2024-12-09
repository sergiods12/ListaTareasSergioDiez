using System.ComponentModel;

namespace ListaTareasSergioDiez.Models
{
    public class Tarea : INotifyPropertyChanged
    {
        private string titulo;
        private string descripcion;
        private bool completada;

        public string Titulo
        {
            get => titulo;
            set
            {
                if (titulo != value)
                {
                    titulo = value;
                    OnPropertyChanged(nameof(Titulo));
                }
            }
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (descripcion != value)
                {
                    descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

        public bool Completada
        {
            get => completada;
            set
            {
                if (completada != value)
                {
                    completada = value;
                    OnPropertyChanged(nameof(Completada));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
