using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;

namespace ConstroleDeMedicamentos.ModuloMedicamento
{
    internal class RepositorioMedicamento : Repositorio<EntidadeMedicamento>
    {
        public EntidadeMedicamento SelecionarMedicamentoPeloNome(string nome)
        {
            EntidadeMedicamento elemento = null;

            foreach (EntidadeMedicamento e in Registros)
            {
                if (e.Nome == nome)
                {
                    elemento = e;
                    break;
                }
            }

            return elemento;
        }
    }
}
