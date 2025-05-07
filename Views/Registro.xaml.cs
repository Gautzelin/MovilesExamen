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
            DisplayAlert("Error", "Ingrese un monto inicial v�lido.", "OK");
            return;
        }

        if (inicial >= COSTO_TOTAL)
        {
            DisplayAlert("Error", $"El monto inicial debe ser menor a {COSTO_TOTAL:F2}.", "OK");
            return;
        }

        // Calcular saldo restante
        var resto = COSTO_TOTAL - inicial;
        // 4 cuotas con 4% adicional sobre cada cuota
        var cuotaBase = resto / 3;
        var costoAdicional = COSTO_TOTAL * 0.03m;
        var cuotaConInteres = cuotaBase + costoAdicional;
        entryCuotaMensual.Text = cuotaConInteres.ToString("F2");
    }

    private void btnVerResumen_Clicked(object sender, EventArgs e)
    {
        var nombre = txtNombre.Text?.Trim() ?? string.Empty;
        var apellido = txtApellido.Text?.Trim() ?? string.Empty;
        //var edad = edadEntry.Text?.Trim() ?? string.Empty;
        var fecha = datePickerFecha.Date;
        var ciudad = pickerCiudad.SelectedItem?.ToString() ?? string.Empty;
        var inicial = decimal.TryParse(entryMontoInicial.Text, out var m) ? m : 0m;
        var pagoMensual = decimal.TryParse(entryCuotaMensual.Text, out var p) ? p : 0m;

        Navigation.PushAsync(new Resumen(Usuario, nombre, apellido,
                                              fecha, ciudad,
                                              inicial, pagoMensual));
    }
}