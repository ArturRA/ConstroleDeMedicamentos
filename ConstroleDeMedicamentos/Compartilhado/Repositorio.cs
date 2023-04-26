using System.Reflection;

namespace ConstroleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class Repositorio<TipoEntidade> where TipoEntidade : Entidade
    {
        protected int contadorDeId = 1;
        protected List<TipoEntidade> Registros { get;} = new List<TipoEntidade>();

        public void Inserir(TipoEntidade entidade)
        {
            entidade.Id = contadorDeId;
            Registros.Add(entidade);
            contadorDeId++;
        }

        public void Editar(TipoEntidade entidadeParaEditar, TipoEntidade entidadeAtualizada)
        {
            // Pega o Tipo
            Type tipo = typeof(TipoEntidade);

            // Para cada propriedade, que não seja o id, atualiza o valor
            foreach (PropertyInfo p in tipo.GetProperties())
            {
                if (p != entidadeParaEditar.Id.GetType())
                    p.SetValue(entidadeParaEditar, p.GetValue(entidadeAtualizada));
            }

            //entidadeParaEditar.AtualizarInformacoes(typeof(TipoEntidade) ,entidadeAtualizada);
        }

        public void Excluir(TipoEntidade elementoParaExcluir)
        {
            Registros.Remove(elementoParaExcluir);
        }

        public TipoEntidade SelecionarElementoPeloId(int id)
        {
            TipoEntidade elemento = null;

            foreach (TipoEntidade e in Registros)
            {
                if (e.Id == id)
                {
                    elemento = e;
                    break;
                }
            }

            return elemento;
        }

        public List<TipoEntidade> SelecionarTodaALista()
        {
            return Registros;
        }

        public bool EstaVazio()
        {
            if (Registros.Count == 0)
                return true;
            else
                return false;
        }
    }
}
