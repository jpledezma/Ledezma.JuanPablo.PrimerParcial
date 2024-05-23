namespace CRUD
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;
        public FrmLogin()
        {
            InitializeComponent();
            this.usuarios = new List<Usuario>();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.LeerUsuarios();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool loginValido = false;
            string clave = this.txtClave.Text;
            string correo = this.txtUsuario.Text;

            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.clave == clave && usuario.correo == correo)
                {
                    loginValido = true;
                    break;
                }
            }

            if (!loginValido)
            {
                MessageBox.Show("El correo y/o la contraseña son incorrectos.\nInténtelo de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void LeerUsuarios()
        {
            try
            {
                using (StreamReader sr = new StreamReader("./usuarios.json"))
                {
                    string json_str = sr.ReadToEnd();
                    this.usuarios = (List<Usuario>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"El archivo con los datos de usuarios no existe.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron leer los datos de usuarios.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
