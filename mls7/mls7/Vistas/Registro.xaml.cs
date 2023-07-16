using mls7.Vistas;
using mls7;
using mlsS7;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mls7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtcontrasena.Text };
                con.InsertAsync(datosRegistro);
                Navigation.PushAsync(new Login());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }
    }
}