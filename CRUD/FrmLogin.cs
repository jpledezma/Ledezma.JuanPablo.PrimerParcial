namespace CRUD
{
    public partial class FrmLogin : Form
    {
        /*
         * fondo: 38, 40, 51
         * azul oscuro: (2, 118, 170)
         * azul medio: (3, 169, 244)
         * azul claro: (0, 229, 255)
         * verde oscuro: (53, 122, 56)
         * verde medio: (76, 175, 80)
         * verde claro: (139, 195, 74)
         * indigo: (42, 62, 177)
         * blanco-azul: (224, 242, 241)
         */

        private List<Usuario> usuarios;
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarios = new List<Usuario>();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.DeserializarJson();

            bool loginValido = false;
            string clave = this.txtClave.Text;
            string correo = this.txtUsuario.Text;

            foreach (Usuario usuario in this.usuarios)
            {
                if(usuario.clave == clave &&  usuario.correo == correo)
                {
                    loginValido = true;
                    break;
                }
            }


            if (!loginValido)
            {
                MessageBox.Show("Error");
                return;
                
            }

            FrmCRUD frmCRUD = new FrmCRUD();

            this.Hide();
            DialogResult resultado = frmCRUD.ShowDialog();

            if (resultado == DialogResult.Cancel) 
            {
                this.Close();
            }
            // Si lo quiero mostrar de nuevo le mando este
            //this.Show();
        }

        private void DeserializarJson()
        {
            using (StreamReader sr = new StreamReader("./usuarios.json"))
            {
                string json_str = sr.ReadToEnd();
                this.usuarios = (List<Usuario>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));
            }

        }
    }
}
