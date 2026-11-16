using System.Globalization;

namespace CadastroEventos.Models;

public sealed class Evento
{
    private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");
    private const NumberStyles EstiloCusto = NumberStyles.AllowDecimalPoint;

    public string? Nome { get; set; }
    public DateTime? DataInicio { get; set; } = DateTime.Today;
    public DateTime? DataTermino { get; set; } = DateTime.Today;
    public string? Local { get; set; }

    // O formulário mantém os valores digitados como texto até a validação.
    public string? ParticipantesDigitados { get; set; }
    public string? CustoDigitado { get; set; }
    public int NumeroParticipantes { get; private set; }
    public decimal CustoPorParticipante { get; private set; }

    public TimeSpan Duracao => DataTermino!.Value.Date - DataInicio!.Value.Date;
    public int DuracaoEmDias => Duracao.Days;
    public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;

    public string InicioFormatado => DataInicio!.Value.ToString("dd/MM/yyyy", Cultura);
    public string TerminoFormatado => DataTermino!.Value.ToString("dd/MM/yyyy", Cultura);
    public string ParticipantesFormatados => NumeroParticipantes.ToString("N0", Cultura);
    public string DuracaoFormatada => $"{DuracaoEmDias} {(DuracaoEmDias == 1 ? "dia" : "dias")}";
    public string CustoUnitarioFormatado => CustoPorParticipante.ToString("C2", Cultura);
    public string CustoTotalFormatado => CustoTotal.ToString("C2", Cultura);

    public string? Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            return "Informe o nome do evento.";

        if (DataInicio is not DateTime inicio || DataTermino is not DateTime termino)
            return "Selecione as datas de início e de término.";

        if (termino.Date < inicio.Date)
            return "A data de término deve ser igual ou posterior à data de início.";

        if (!int.TryParse(ParticipantesDigitados, NumberStyles.Integer, Cultura, out int participantes)
            || participantes <= 0)
            return "Informe um número inteiro de participantes maior que zero.";

        if (string.IsNullOrWhiteSpace(Local))
            return "Informe o local do evento.";

        // Aceita vírgula ou ponto decimal, sem separador de milhares.
        string? custoDigitado = CustoDigitado?.Trim().Replace('.', ',');
        int separador = custoDigitado?.IndexOf(',') ?? -1;
        if (!decimal.TryParse(custoDigitado, EstiloCusto, Cultura, out decimal custo)
            || (separador >= 0 && custoDigitado!.Length - separador - 1 is not (1 or 2)))
            return "Informe um custo válido, como 35,50 ou 0 para um evento gratuito.";

        if (custo > decimal.MaxValue / participantes)
            return "O valor total do evento ultrapassa o limite permitido.";

        NumeroParticipantes = participantes;
        CustoPorParticipante = custo;
        return null;
    }
}
