namespace jcorreaExamen.Views;

public partial class Resumen : ContentPage
{
	public Resumen(string nombre, string apellido, string va, string ciudad, DateTime fecha, decimal montoInicial)
	{
		InitializeComponent();

        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblVA.Text = va;
        lblFecha.Text = fecha.ToString("dd/MM/yyyy");
        lblCiudad.Text = ciudad;
        lblMontoInicial.Text = $"${montoInicial:F2}";

        // Ejemplo: Calcular cuota mensual y pago total
        decimal cuotaMensual = montoInicial / 12;
        decimal pagoTotal = cuotaMensual * 12;

        lblCuotaMensual.Text = $"${cuotaMensual:F2}";
        lblPagoTotal.Text = $"${pagoTotal:F2}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.Login());
    }
}