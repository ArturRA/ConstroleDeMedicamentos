using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;
using ConstroleDeMedicamentos.ModuloFuncionario;
using ConstroleDeMedicamentos.ModuloMedicamento;
using ConstroleDeMedicamentos.ModuloPaciente;

namespace ConstroleDeMedicamentos.ModuloRequisicao
{
    internal class EntidadeRequisicao : Entidade
    {
        public EntidadeFuncionario EntidadeFuncionario{ get; set; }
        public EntidadePaciente EntidadePaciente { get; set; }
        public EntidadeMedicamento EntidadeMedicamento { get; set; }
        public int QuantidadeMedicamento { get; set; }

        public EntidadeRequisicao(EntidadeFuncionario entidadeFuncionario, EntidadePaciente entidadePaciente, EntidadeMedicamento entidadeMedicamento, int quantidadeMedicamento)
        {
            EntidadeFuncionario=entidadeFuncionario;
            EntidadePaciente=entidadePaciente;
            EntidadeMedicamento=entidadeMedicamento;
            QuantidadeMedicamento=quantidadeMedicamento;

            EntidadeMedicamento.RegistrarSaida(quantidadeMedicamento);
        }
    }
}
