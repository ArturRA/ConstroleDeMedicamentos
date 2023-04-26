using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloPaciente
{
    internal class TelaPaciente : Tela<RepositorioPaciente, EntidadePaciente>
    {
        public override string TipoDaTela { get { return "Paciente"; } }

        protected override EntidadePaciente ObterInformacaoElementoUsuario()
        {

            Console.Write($"Digite o nome do {TipoDaTela}: ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o numero do SUS do {TipoDaTela}: ");
            string SUS = Console.ReadLine();

            EntidadePaciente elemento = new EntidadePaciente(nome, SUS);

            return (EntidadePaciente)Convert.ChangeType(elemento, typeof(EntidadePaciente));
        }
    }
}
