using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFuncionario
{
    internal class TelaFuncionario : Tela<RepositorioFuncionario, EntidadeFuncionario>
    {
        public override string TipoDaTela { get { return "Funcionario"; } }

        protected override EntidadeFuncionario ObterInformacaoElementoUsuario()
        {

            Console.Write($"Digite o nome do {TipoDaTela}: ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o login do {TipoDaTela}: ");
            string login = Console.ReadLine();

            Console.Write($"Digite a senha do {TipoDaTela}: ");
            string senha = Console.ReadLine();

            EntidadeFuncionario elemento = new EntidadeFuncionario(nome, login, senha);

            return (EntidadeFuncionario)Convert.ChangeType(elemento, typeof(EntidadeFuncionario));
        }

        //public void InserirReposicao()
        //{
        //    Console.WriteLine($"Cadastro de {TipoDaTela}\n"
        //                    + $"Inserindo novo(a) {TipoDaTela}:\n");

        //    if (ChecarTemTodosAtributosDisponiveis())
        //    {
        //        TipoEntidade novoElemento = ObterInformacaoElementoUsuario();

        //        Repositorio.Inserir(novoElemento);

        //        ApresentarMensagemColorida($"{TipoDaTela} inserido(a) com sucesso!", ConsoleColor.Green);
        //        Console.ReadLine();
        //    }
        //    else
        //        return;

        //}
    }
}
