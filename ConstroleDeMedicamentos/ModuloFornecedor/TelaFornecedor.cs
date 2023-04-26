using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFornecedor
{
    internal class TelaFornecedor : Tela<RepositorioFornecedor, EntidadeFornecedor>
    {
        public override string TipoDaTela { get { return "Fornecedor"; } }

        protected override EntidadeFornecedor ObterInformacaoElementoUsuario()
        {

            Console.Write($"Digite o nome do {TipoDaTela}: ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o CNPJ do {TipoDaTela}: ");
            string CNPJ = Console.ReadLine();

            Console.Write($"Digite o Contato do {TipoDaTela}: ");
            string contato = Console.ReadLine();

            Console.Write($"Digite o Endereço do {TipoDaTela}: ");
            string endereco = Console.ReadLine();

            EntidadeFornecedor elemento = new EntidadeFornecedor(nome, CNPJ, contato, endereco);

            return (EntidadeFornecedor)Convert.ChangeType(elemento, typeof(EntidadeFornecedor));
        }
    }
}
