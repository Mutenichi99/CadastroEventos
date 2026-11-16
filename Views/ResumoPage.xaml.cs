using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class ResumoPage : ContentPage
{
    public ResumoPage(Evento evento)
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void AoVoltar(object? sender, EventArgs e)
    {
        BotaoVoltar.IsEnabled = false;
        try
        {
            await Navigation.PopAsync();
        }
        finally
        {
            BotaoVoltar.IsEnabled = true;
        }
    }
}
