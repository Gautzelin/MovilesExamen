namespace jcorreaExamen.Views;

public partial class Registro : ContentPage


{
    private const decimal COSTO_TOTAL =300m;
    public string Usuario { get; set; }
    public Registro()
	{
		InitializeComponent();
	}

    public Registro(String username)
    {
        InitializeComponent();
        welcomeLabel.Text = $"Bienvenido, {username}!";
    }

    private void btnCalcularPago_Clicked(object sender, EventArgs e)
    {
        if (!decimal.TryParse(entryMontoInicial.Text, out var inicial) || inicial < 0)
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return;
        }

        if (inicial >= COSTO_TOTAL)
        {
            DisplayAlert("Error", $"El monto inicial debe ser menor a {COSTO_TOTAL:F2}.", "OK");
            return;
        }

        // Calcular saldo restante
        var resto = COSTO_TOTAL - inicial;
        var cuotaBase = resto / 3;
        var costoAdicional = COSTO_TOTAL * 0.03m;
        var cuotaConInteres = cuotaBase + costoAdicional;
        entryCuotaMensual.Text = cuotaConInteres.ToString("F2");
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            pickerVA.SelectedItem == null ||
            pickerCiudad.SelectedItem == null ||
            string.IsNullOrWhiteSpace(entryMontoInicial.Text) ||
            string.IsNullOrWhiteSpace(entryCuotaMensual.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos antes de continuar.", "OK");
            return;
        }

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string voltaje = pickerVA.SelectedItem.ToString();
        string ciudad = pickerCiudad.SelectedItem.ToString();
        DateTime fecha = datePickerFecha.Date;
        decimal cuotaMensual = decimal.Parse(entryCuotaMensual.Text);

        Navigation.PushAsync(new Resumen(nombre, apellido, voltaje, ciudad, fecha, cuotaMensual));
    }
}