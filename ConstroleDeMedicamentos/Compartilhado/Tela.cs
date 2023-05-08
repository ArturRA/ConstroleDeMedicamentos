using System.Reflection;

namespace ConstroleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class Tela<TipoRepositorio, TipoEntidade> where TipoRepositorio : Repositorio<TipoEntidade> where TipoEntidade : Entidade
    {
        public virtual string TipoDaTela { get; }
        public Repositorio<TipoEntidade> Repositorio { get; set; } = null;

        public void ApresentarMensagemColorida(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public Repositorio<TipoEntidade> SelecionarRepositorio()
        {
            return Repositorio;
        }

        public void VisualizarElementos()
        {
            Console.WriteLine($"Cadastro de {TipoDaTela}\n"
                            + $"Visualizando {TipoDaTela}s:\n");

            if (Repositorio.EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarElementos();
            Console.ReadLine();
        }

        public void ListarElementos()
        {
            List<TipoEntidade> listaDeEntidades = Repositorio.SelecionarTodaALista();

            List<string> listaDePropriedadesEValores = new List<string>();
            string elemento = "";
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (TipoEntidade e in listaDeEntidades)
            {
                listaDePropriedadesEValores.AddRange(SelecionarValorAtributoElementos(e, ""));
                //// Para cada propriedade adiciona o valor no ArrayList para gerar o cabeçalho
                //foreach (PropertyInfo p in typeof(TipoEntidade).GetProperties())
                //    listaDePropriedadesEValores.Add($"{p.Name}: {Convert.ToString(p.GetValue(e))}");

                elemento = String.Join("\n", listaDePropriedadesEValores);
                Console.WriteLine(elemento + "\n");
                listaDePropriedadesEValores.Clear();
                elemento = "";
            }

            Console.ResetColor();
        }

        private List<string> SelecionarValorAtributoElementos<T>(T entidade, string offset)
        {
            List<string> listaDePropriedadesEValoresBase = new List<string>();
            List<string> listaDePropriedadesEValoresDerivado = new List<string>();


            // Para cada propriedade adiciona o valor no ArrayList para gerar o cabeçalho
            foreach (PropertyInfo p in entidade.GetType().GetProperties())
            {
                if (p.GetValue(entidade).GetType().BaseType == typeof(Entidade))
                {
                    listaDePropriedadesEValoresDerivado.Add("");
                    listaDePropriedadesEValoresDerivado.AddRange(SelecionarValorAtributoElementos(p.GetValue(entidade), $"{offset}\t"));
                }
                else
                    listaDePropriedadesEValoresBase.Add($"{offset}{entidade.GetType().Name} {p.Name}: {Convert.ToString(p.GetValue(entidade))}");
            }

            listaDePropriedadesEValoresBase.AddRange(listaDePropriedadesEValoresDerivado);
            return listaDePropriedadesEValoresBase;
        }

        public virtual string ApresentarMenuCadastroElemento()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {TipoDaTela}s\n"
                            + $"-->Digite 1 para Inserir um(a) novo(a) {TipoDaTela}\n"
                            + $"-->Digite 2 para Visulizar os(as) {TipoDaTela}s\n"
                            + $"-->Digite 3 para Editar um(a) {TipoDaTela}\n"
                            + $"-->Digite 4 para Excluir um(a) {TipoDaTela}\n"
                            +  "\n"
                            +  "-->Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public void InserirElemento()
        {
            Console.WriteLine($"Cadastro de {TipoDaTela}\n"
                            + $"Inserindo novo(a) {TipoDaTela}:\n");

            if (ChecarTemTodosAtributosDisponiveis())
            {
                TipoEntidade novoElemento = ObterInformacaoElementoUsuario();

                Repositorio.Inserir(novoElemento);

                ApresentarMensagemColorida($"{TipoDaTela} inserido(a) com sucesso!", ConsoleColor.Green);
                Console.ReadLine();
            }
            else
                return;
        }

        public void EditarElemento()
        {
            Console.WriteLine($"Cadastro de {TipoDaTela}\n"
                            + $"Editando {TipoDaTela}s:\n");

            if (Repositorio.EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarElementos();

            TipoEntidade entidadeParaEditar = EncontrarElementoNaLista();
            TipoEntidade entidadeAtualizada = ObterInformacaoElementoUsuario();
            Repositorio.Editar(entidadeParaEditar, entidadeAtualizada);

            ApresentarMensagemColorida($"{TipoDaTela} editado(a) com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExcluirElemento()
        {
            Console.WriteLine($"Cadastro de {TipoDaTela}\n"
                            + $"Excluindo {TipoDaTela}s:\n");

            if (Repositorio.EstaVazio())
            {
                ApresentarMensagemColorida($"Nenhum(a) {TipoDaTela} cadastrado(a)!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarElementos();

            TipoEntidade entidadeParaExcluir = EncontrarElementoNaLista();
            Repositorio.Excluir(entidadeParaExcluir);

            ApresentarMensagemColorida($"{TipoDaTela} excluido(a) com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }


        protected abstract TipoEntidade ObterInformacaoElementoUsuario();

        public TipoEntidade EncontrarElementoNaLista()
        {
            TipoEntidade elemento = default;
            int idSelecionado;
            while (true)
            {
                Console.Write($"Digite o Id do(a) {TipoDaTela}: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                elemento =  (TipoEntidade?)Repositorio.SelecionarElementoPeloId(idSelecionado);

                if (elemento == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return elemento;
        }

        protected virtual bool ChecarTemTodosAtributosDisponiveis()
        {
            //if (telaCaixa.SelecionarTodaALista().EstaVazio())
            //{
            //    ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
            //    Console.ReadLine();
            //    return;
            //}



            return true;
        }





    }
}
