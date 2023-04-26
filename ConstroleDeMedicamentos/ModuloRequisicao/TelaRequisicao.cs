using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;
using ConstroleDeMedicamentos.ModuloFornecedor;
using ConstroleDeMedicamentos.ModuloFuncionario;
using ConstroleDeMedicamentos.ModuloMedicamento;
using ConstroleDeMedicamentos.ModuloPaciente;
using ConstroleDeMedicamentos.ModuloReposicao;

namespace ConstroleDeMedicamentos.ModuloRequisicao
{
    internal class TelaRequisicao : Tela<RepositorioRequisicao, EntidadeRequisicao>
    {
        public override string TipoDaTela { get { return "Requisicao"; } }
        public TelaFuncionario TelaFuncionario { get; set; } = null;
        public TelaPaciente TelaPaciente { get; set; } = null;
        public TelaMedicamento TelaMedicamento { get; set; } = null;

        protected override bool ChecarTemTodosAtributosDisponiveis()
        {
            if (TelaFuncionario.SelecionarRepositorio().EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TelaFuncionario.TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return false;
            }
            if (TelaPaciente.SelecionarRepositorio().EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TelaPaciente.TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return false;
            }
            if (TelaMedicamento.SelecionarRepositorio().EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TelaMedicamento.TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return false;
            }

            return true;
        }

        protected override EntidadeRequisicao ObterInformacaoElementoUsuario()
        {
            EntidadeFuncionario entidadeFuncionario;
            EntidadePaciente entidadePaciente;
            EntidadeMedicamento entidadeMedicamento;

            int idSelecionado;
            while (true)
            {
                Console.Write($"Digite o Id do(a) {TelaFuncionario.TipoDaTela}: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                entidadeFuncionario = TelaFuncionario.SelecionarRepositorio().SelecionarElementoPeloId(idSelecionado);

                if (entidadeFuncionario == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            while (true)
            {
                Console.Write($"Digite o Id do(a) {TelaPaciente.TipoDaTela}: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                entidadePaciente = TelaPaciente.SelecionarRepositorio().SelecionarElementoPeloId(idSelecionado);

                if (entidadeFuncionario == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            while (true)
            {
                Console.Write($"Digite o Id do(a) {TelaMedicamento.TipoDaTela}: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                entidadeMedicamento = TelaMedicamento.SelecionarRepositorio().SelecionarElementoPeloId(idSelecionado);

                if (entidadeMedicamento == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            Console.Write($"Digite a quantidade do(a) {TelaMedicamento.TipoDaTela}: ");

            int quantidade = Convert.ToInt32(Console.ReadLine());

            EntidadeRequisicao entidade = new EntidadeRequisicao(entidadeFuncionario,
                                                               entidadePaciente,
                                                               entidadeMedicamento,
                                                               quantidade);

            return entidade;

            //return (EntidadeReposicao)Convert.ChangeType(entidade, typeof(EntidadeReposicao));
        }
    }
}
