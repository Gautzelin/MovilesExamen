namespace jcorreaExamen.Views;

public partial class Login : ContentPage
{
    string[] users = { "estudiante", "uisrael", "admin" };
    string[] passwords = { "moviles", "2024", "admin123" };
    public Login()
	{
		InitializeComponent();
	}

    

    private void btnInicioSesion_Clicked(object sender, EventArgs e)
    {
        string userInput = txtUsuario.Text?.Trim();
        string passInput = txtContrasena.Text?.Trim();

        // Validación de campos vacíos
        if (string.IsNullOrEmpty(userInput) || string.IsNullOrEmpty(passInput))
        {
            DisplayAlert("Advertencia", "Por favor, complete todos los campos.", "OK");
            return;
        }

        // Validación de credenciales
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Equals(userInput, StringComparison.OrdinalIgnoreCase) &&
                passwords[i] == passInput)
            {
                // Éxito: navegación a otra página con el nombre del usuario
                Navigation.PushAsync(new Registro(users[i]));
                return;
            }
        }

        // Si no se encontró una coincidencia
        DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
    }

    private void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Acerca de", "Hola, soy Joss. Yo creé este código.", "OK");
    }
}
