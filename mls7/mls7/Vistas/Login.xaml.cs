using mls7.Vistas;
using mls7;
using mlsS7;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mls7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> select_where(SQLiteConnection db, String usuario, String contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario=? and contrasena=?", usuario, contrasena);
        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_where(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("ERROR", "Usuario o contraseña incorrectos", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", ex.Message, "Cerrar");
            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}