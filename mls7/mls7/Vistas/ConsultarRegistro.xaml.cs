using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using mls7.Vistas;
using mls7;
using mlsS7;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mls7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tabla;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            Obtener();
        }

        public async void Obtener()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tabla = new ObservableCollection<Estudiante>(Resultado);
            ListaEstudiantes.ItemsSource = tabla;
        }
        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoestudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new Elemento(objetoestudiante));
        }
    }
}