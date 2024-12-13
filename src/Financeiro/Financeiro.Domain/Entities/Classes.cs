namespace Financeiro.Domain.Entities;

public class PlanoConta { }
public class ContaFinanceira { }
public class MeioPagamento { }
public class ItemParcelamento { }
public class ConfiguracaoParcelamento { }
public class FormaPagamento
{
    public string Nome { get; set; }
    public ContaFinanceira ContaFinanceira { get; set; }
    public MeioPagamento MeioPagamento { get; set; }
    public ConfiguracaoParcelamento ConfiguracaoParcelamento { get; set; }
}

public enum TipoValor
{
    ABSOLUTO,
    RELATIVO
}

public enum TipoIncidenciaPenalidade
{
	POR_DIA = 1,
	POR_MES = 2,
	FIXA = 3
}

public class RegraPenalidade
{
	public TipoIncidenciaPenalidade TipoIncidencia { get; set; }
	public TipoValor TipoValor { get; set; }
	public decimal Valor { get; set; }
}

public class PoliticaPenalidadePorAtrasoDePagamento
{
    private int _diasCarencia;
    private RegraPenalidade _multa;
    private RegraPenalidade _juros;

	public Penalidades CalcularPenalidades(Parcela parcela, DateOnly dataPrevisaoPagamento)
    {
        var ultimoDiaCarencia = parcela.Vencimento.AddDays(_diasCarencia);

        if (dataPrevisaoPagamento <= ultimoDiaCarencia)
            return Penalidades.NoPenalidades();
    }
}

public record Penalidades(decimal Multa, decimal Juros)
{
    public static Penalidades NoPenalidades()
        => new(0, 0);
}

// ClienteFornecedor
public class Entidade { }

public class Titulo { }
public class Parcela
{
    public DateOnly Vencimento { get; set; }
}
public class Baixa
{
    public DateOnly Compensacao { get; set; }
    public DateOnly Pagamento { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public ContaFinanceira ContaFinanceira { get; set; }

    public decimal ValorTotalPago { get; set; }
    public decimal Acrescimo { get; set; }
    public decimal Multa { get; set; }
    public decimal Juros { get; set; }
    public decimal Desconto { get; set; }

	public decimal Troco { get; set; } // não está presente no valor total
	public decimal TaxaTransacao { get; set; } // não está presente no valor total

	public decimal ValorAbatido
		=> ValorTotalPago + Acrescimo + Multa + Juros - Desconto;
}

public record Desconto(decimal Valor);