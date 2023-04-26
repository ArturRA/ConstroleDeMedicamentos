using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;
using ConstroleDeMedicamentos.ModuloFornecedor;
using ConstroleDeMedicamentos.ModuloFuncionario;
using ConstroleDeMedicamentos.ModuloMedicamento;

namespace ConstroleDeMedicamentos.ModuloReposicao
{
    internal class TelaReposicao : Tela<RepositorioReposicao, EntidadeReposicao>
    {
        public override string TipoDaTela { get { return "Reposicao"; } }
        public TelaFornecedor TelaFornecedor { get; set; } = null;
        public TelaFuncionario TelaFuncionario { get; set; } = null;
        public TelaMedicamento TelaMedicamento { get; set; } = null;

        protected override bool ChecarTemTodosAtributosDisponiveis()
        {
            if (TelaFornecedor.SelecionarRepositorio().EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TelaFornecedor.TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return false;
            }
            if (TelaFuncionario.SelecionarRepositorio().EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TelaFuncionario.TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
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

        protected override EntidadeReposicao ObterInformacaoElementoUsuario()
        {
            EntidadeFornecedor entidadeFornecedor;
            EntidadeFuncionario entidadeFuncionario;
            EntidadeMedicamento entidadeMedicamento;

            int idSelecionado;
            while (true)
            {
                Console.Write($"Digite o Id do(a) {TelaFornecedor.TipoDaTela}: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                entidadeFornecedor = TelaFornecedor.SelecionarRepositorio().SelecionarElementoPeloId(idSelecionado);

                if (entidadeFornecedor == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

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

            EntidadeReposicao entidade = new EntidadeReposicao(entidadeFornecedor,
                                                               entidadeFuncionario,
                                                               entidadeMedicamento,
                                                               quantidade);


            return entidade;

            //return (EntidadeReposicao)Convert.ChangeType(entidade, typeof(EntidadeReposicao));
        }
    }
}
