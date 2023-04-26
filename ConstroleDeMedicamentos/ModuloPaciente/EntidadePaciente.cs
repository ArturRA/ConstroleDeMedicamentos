using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloPaciente
{
    internal class EntidadePaciente : Entidade
    {
        public string Nome { get; set; }
        public string SUS { get; set; }

        public EntidadePaciente(string nome, string SUS)
        {
            this.Nome=nome;
            this.SUS=SUS;
        }
    }
}
