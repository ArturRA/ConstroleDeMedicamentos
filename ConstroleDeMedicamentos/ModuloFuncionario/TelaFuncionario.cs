using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFuncionario
{
    internal class TelaFuncionario : Tela<RepositorioFuncionario, EntidadeFuncionario>
    {
        public override string TipoDaTela { get { return "Funcionario"; } }

        protected override EntidadeFuncionario ObterInformacaoElementoUsuario()
        {
            string nome, login, senha;

            while (true)
            {
                Console.Write($"Digite o nome do {TipoDaTela}: ");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome.Trim()))
                    Console.WriteLine("O campo \"nome\" é obrigatório");
                else
                    break;
            }
            while (true)
            {
                Console.Write($"Digite o login do {TipoDaTela}: ");
                login = Console.ReadLine();
                if (string.IsNullOrEmpty(login.Trim()))
                    Console.WriteLine("O campo \"login\" é obrigatório");
                else
                    break;
            }
            while (true)
            {
                Console.Write($"Digite a senha do {TipoDaTela}: ");
                senha = Console.ReadLine();
                if (string.IsNullOrEmpty(senha.Trim()))
                    Console.WriteLine("O campo \"senha\" é obrigatório");
                else
                    break;
            }

            EntidadeFuncionario elemento = new EntidadeFuncionario(nome, login, senha);

            return elemento;
        }
    }
}
