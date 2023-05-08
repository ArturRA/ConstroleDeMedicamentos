using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloPaciente
{
    internal class TelaPaciente : Tela<RepositorioPaciente, EntidadePaciente>
    {
        public override string TipoDaTela { get { return "Paciente"; } }

        protected override EntidadePaciente ObterInformacaoElementoUsuario()
        {
            string nome, SUS;

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
                Console.Write($"Digite o SUS do {TipoDaTela}: ");
                SUS = Console.ReadLine();
                if (string.IsNullOrEmpty(SUS.Trim()))
                    Console.WriteLine("O campo \"SUS\" é obrigatório");
                else
                    break;
            }

            EntidadePaciente elemento = new EntidadePaciente(nome, SUS);

            return elemento;
        }
    }
}
