using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloFornecedor
{
    internal class EntidadeFornecedor : Entidade
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }

        public EntidadeFornecedor(string nome, string CNPJ, string contato, string endereco)
        {
            this.Nome=nome;
            this.CNPJ=CNPJ;
            this.Contato=contato;
            this.Endereco=endereco;
        }
    }
}
