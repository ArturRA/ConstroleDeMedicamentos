using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;
using ConstroleDeMedicamentos.ModuloFornecedor;
using ConstroleDeMedicamentos.ModuloFuncionario;
using ConstroleDeMedicamentos.ModuloMedicamento;

namespace ConstroleDeMedicamentos.ModuloReposicao
{
    internal class EntidadeReposicao : Entidade
    {
        public EntidadeFornecedor EntidadeFornecedor{ get; set; }
        public EntidadeFuncionario EntidadeFuncionario { get; set; }
        public EntidadeMedicamento EntidadeMedicamento { get; set; }
        public int QuantidadeMedicamento { get; set; }

        public EntidadeReposicao(EntidadeFornecedor entidadeFornecedor, EntidadeFuncionario entidadeFuncionario, EntidadeMedicamento entidadeMedicamento, int quantidadeMedicamento)
        {
            EntidadeFornecedor=entidadeFornecedor;
            EntidadeFuncionario=entidadeFuncionario;
            EntidadeMedicamento=entidadeMedicamento;
            QuantidadeMedicamento=quantidadeMedicamento;

            EntidadeMedicamento.RegistrarEntrada(quantidadeMedicamento);
        }
    }
}
