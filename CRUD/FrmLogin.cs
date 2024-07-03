namespace CRUD
{
    public partial class FrmLogin : Form
    {
        private List<Usuario> usuarios;
        private Usuario usuarioLogueado;

        public Usuario UsuarioLogueado
        {
            get { return this.usuarioLogueado; }
        }

        public FrmLogin()
        {
            InitializeComponent();
            this.usuarios = new List<Usuario>();
            this.MaximizeBox = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.LeerUsuarios();
            this.cboPerfilUsuario.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool loginValido = false;
            string clave = this.txtClave.Text;
            string correo = this.txtUsuario.Text;
            int indiceUsuario = 0;

            foreach (Usuario usuario in this.usuarios)
            {
                if (usuario.clave == clave && usuario.correo == correo)
                {
                    loginValido = true;
                    break;
                }
                indiceUsuario++;
            }

            if (!loginValido)
            {
                MessageBox.Show("El correo y/o la contraseña son incorrectos.\nInténtelo de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.usuarioLogueado = this.usuarios[indiceUsuario];
            this.DialogResult = DialogResult.OK;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtClave.Clear();
            this.txtUsuario.Clear();
        }

        private void btnAutocompletar_Click(object sender, EventArgs e)
        {
            if (this.cboPerfilUsuario.SelectedIndex == 0)
            {
                this.txtUsuario.Text = "admin@admin.com";
                this.txtClave.Text = "12345678";
            }
            else if (this.cboPerfilUsuario.SelectedIndex == 1)
            {
                this.txtUsuario.Text = "trobinson@super.com";
                this.txtClave.Text = "12345678";
            }
            else
            {
                this.txtUsuario.Text = "sharris@maiden.com.uk";
                this.txtClave.Text = "eddie666";
            }
        }

        private void LeerUsuarios()
        {
            try
            {
                // Tiene que ser un path absoluto por si se fuera a ejecutar desde un medio externo,
                // por ejemplo, la terminal (desde un directorio diferente).
                string pathUsuarios = Application.StartupPath + "usuarios.json";
                using (StreamReader sr = new StreamReader(pathUsuarios))
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
