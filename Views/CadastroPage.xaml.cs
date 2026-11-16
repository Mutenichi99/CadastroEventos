using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class CadastroPage : ContentPage
{
    private readonly Evento evento = new();

    public CadastroPage()
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void AoVerResumo(object? sender, EventArgs e)
    {
        BotaoResumo.IsEnabled = false;
        try
        {
            string? erro = evento.Validar();
            if (erro is not null)
            {
                await DisplayAlertAsync("Confira os dados", erro, "OK");
                return;
            }

            await Navigation.PushAsync(new ResumoPage(evento));
        }
        finally
        {
            BotaoResumo.IsEnabled = true;
        }
    }
}
