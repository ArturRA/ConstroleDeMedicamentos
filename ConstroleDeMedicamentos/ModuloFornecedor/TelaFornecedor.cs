using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFornecedor
{
    internal class TelaFornecedor : Tela<RepositorioFornecedor, EntidadeFornecedor>
    {
        public override string TipoDaTela { get { return "Fornecedor"; } }

        protected override EntidadeFornecedor ObterInformacaoElementoUsuario()
        {
            string nome, CNPJ, contato, endereco;

            while(true)
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
                Console.Write($"Digite o CNPJ do {TipoDaTela}: ");
                CNPJ = Console.ReadLine();
                if (string.IsNullOrEmpty(CNPJ.Trim()))
                    Console.WriteLine("O campo \"CNPJ\" é obrigatório");
                else
                    break;
            }
            while (true)
            {
                Console.Write($"Digite o Contato do {TipoDaTela}: ");
                contato = Console.ReadLine();
                if (string.IsNullOrEmpty(contato.Trim()))
                    Console.WriteLine("O campo \"contato\" é obrigatório");
                else
                    break;
            }
            while (true)
            {
                Console.Write($"Digite o Endereço do {TipoDaTela}: ");
                endereco = Console.ReadLine();
                if (string.IsNullOrEmpty(endereco.Trim()))
                    Console.WriteLine("O campo \"endereco\" é obrigatório");
                else
                    break;
            }

            EntidadeFornecedor elemento = new EntidadeFornecedor(nome, CNPJ, contato, endereco);

            return elemento;
        }
    }
}
