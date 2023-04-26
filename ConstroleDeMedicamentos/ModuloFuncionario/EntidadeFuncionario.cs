using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFuncionario
{
    internal class EntidadeFuncionario : Entidade
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public EntidadeFuncionario(string nome, string login, string senha)
        {
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
        }
    }
}
