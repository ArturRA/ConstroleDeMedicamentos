using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloMedicamento
{
    internal class EntidadeMedicamento : Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeSaida { get; set; } = 0;
        public bool QuantidadeBaixaAviso { get { return QuantidadeDisponivel <= 10; }}

        public EntidadeMedicamento(string nome, string descricao, int quantidadeDisponivel)
        {
            Nome=nome;
            Descricao=descricao;
            QuantidadeDisponivel=quantidadeDisponivel;
        }

        public void RegistrarEntrada(int quantidadeMedicamento)
        {
            this.QuantidadeDisponivel += quantidadeMedicamento;
        }

        public void RegistrarSaida(int quantidadeMedicamento)
        {
            this.QuantidadeDisponivel -= quantidadeMedicamento;
            this.QuantidadeSaida += quantidadeMedicamento;
        }
    }
}
