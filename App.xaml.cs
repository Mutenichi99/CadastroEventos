using CadastroEventos.Views;

namespace CadastroEventos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navigation = new NavigationPage(new CadastroPage())
        {
            BarBackgroundColor = Color.FromArgb("#006B5B"),
            BarTextColor = Colors.White
        };

        return new Window(navigation) { Title = "Cadastro de Eventos" };
    }
}
