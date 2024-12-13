using Financeiro.Domain.Entities;

namespace Financeiro.Application;

public class UseCase
{
	public void Baixar()
	{
		DateOnly hoje = DateOnly.FromDateTime(DateTime.UtcNow);

		Parcela parcela = new();
		PoliticaPenalidadePorAtrasoDePagamento politicaAtrasoPagamento = new();

		Penalidades penalidades = politicaAtrasoPagamento.CalcularPenalidades(parcela, hoje);
	}
}
