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

        public List<EntidadeMedicamento> SelecionarMedicamentosComMaisSaida()
        {
            List<EntidadeMedicamento> medicamentos = new List<EntidadeMedicamento>(Registros);
            medicamentos.Sort((a, b) => b.QuantidadeSaida.CompareTo(a.QuantidadeSaida));
            return medicamentos;

            //medicamentos.Sort((a, b) => b .CompareTo(a));
            //li.Sort((a, b) => a.CompareTo(b)); // ascending sort
            //li.Sort((a, b) => b.CompareTo(a)); // descending sort
        }
    }
}
