using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloMedicamento
{
    internal class TelaMedicamento : Tela<RepositorioMedicamento, EntidadeMedicamento>
    {
        public override string TipoDaTela { get { return "Medicamento"; } }

        protected override EntidadeMedicamento ObterInformacaoElementoUsuario()
        {

            Console.Write($"Digite o nome do {TipoDaTela}: ");
            string nome = Console.ReadLine();

            Console.Write($"Digite a descrição do {TipoDaTela}: ");
            string descricao = Console.ReadLine();

            Console.Write($"Digite a quantidade disponivel do {TipoDaTela}: ");
            int quantidadeDisponivel = Convert.ToInt32(Console.ReadLine());

            EntidadeMedicamento elemento = new EntidadeMedicamento(nome, descricao, quantidadeDisponivel);

            return elemento;

            //return (EntidadeMedicamento)Convert.ChangeType(elemento, typeof(EntidadeMedicamento));
        }
    }
}
