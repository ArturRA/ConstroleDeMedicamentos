using System.Reflection;

namespace ConstroleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class Entidade
    {
        public int Id { get; set; }

        //public void AtualizarInformacoes(Type tipo ,Entidade entidadeAtualizada)
        //{
        //    // Para cada propriedade, que não seja o id, atualiza o valor
        //    foreach (PropertyInfo p in tipo.GetProperties())
        //    {
        //        if (p != this.Id.GetType())
        //            p.SetValue(this, p.GetValue((tipo)entidadeAtualizada));
        //    }
        //}
    }
}
