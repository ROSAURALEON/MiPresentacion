
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private bool saludoAlternativo = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    // BOTÓN PRESENTARME
    private void Presentarme_Click(object? sender, RoutedEventArgs e)
    {
        string nombre = NombreTextBox.Text?.Trim() ?? "";
        string apellido = ApellidoTextBox.Text?.Trim() ?? "";
        string edadTexto = EdadTextBox.Text?.Trim() ?? "";

        // Validar nombre
        if (string.IsNullOrWhiteSpace(nombre))
        {
            ResultadoTextBlock.Text = "Por favor, escribe tu nombre.";
            NombreTextBox.Focus();
            return;
        }

        // Validar apellido
        if (string.IsNullOrWhiteSpace(apellido))
        {
            ResultadoTextBlock.Text = "Por favor, escribe tu apellido.";
            ApellidoTextBox.Focus();
            return;
        }

        // Validar que la edad sea un número entero
        if (!int.TryParse(edadTexto, out int edad))
        {
            ResultadoTextBlock.Text = "La edad debe ser un número entero.";
            EdadTextBox.Focus();
            return;
        }

        // Validar que la edad sea positiva
        if (edad <= 0)
        {
            ResultadoTextBlock.Text = "La edad debe ser mayor que cero.";
            EdadTextBox.Focus();
            return;
        }

        // Mostrar presentación
        if (!saludoAlternativo)
        {
            ResultadoTextBlock.Text =
                $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edad} años y estoy aprendiendo\na desarrollar interfaces gráficas con C#.";
        }
        else
        {
            ResultadoTextBlock.Text =
                $"¡Mucho gusto! Soy {nombre} {apellido}.\nTengo {edad} años y me gusta aprender\nnuevas tecnologías y programación.";
        }
    }

    // BOTÓN LIMPIAR
    private void Limpiar_Click(object? sender, RoutedEventArgs e)
    {
        NombreTextBox.Text = "";
        ApellidoTextBox.Text = "";
        EdadTextBox.Text = "";

        ResultadoTextBlock.Text = "Aquí aparecerá tu presentación.";

        saludoAlternativo = false;

        NombreTextBox.Focus();
    }

    // BOTÓN CAMBIAR SALUDO
    private void CambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        saludoAlternativo = !saludoAlternativo;

        Presentarme_Click(sender, e);
    }
}
