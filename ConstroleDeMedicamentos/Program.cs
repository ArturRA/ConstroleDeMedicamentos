using ConstroleDeMedicamentos.ConsoleApp.Compartilhado;
using ConstroleDeMedicamentos.ModuloFornecedor;
using ConstroleDeMedicamentos.ModuloFuncionario;
using ConstroleDeMedicamentos.ModuloMedicamento;
using ConstroleDeMedicamentos.ModuloPaciente;
using ConstroleDeMedicamentos.ModuloReposicao;
using ConstroleDeMedicamentos.ModuloRequisicao;

namespace ConstroleDeMedicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Repositorios
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            RepositorioReposicao repositorioReposicao = new RepositorioReposicao();
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
            #endregion

            #region Telas
            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.Repositorio = repositorioFornecedor;

            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.Repositorio = repositorioFuncionario;

            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.Repositorio = repositorioMedicamento;

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.Repositorio = repositorioPaciente;

            TelaReposicao telaReposicao = new TelaReposicao();
            telaReposicao.Repositorio = repositorioReposicao;
            telaReposicao.TelaFornecedor = telaFornecedor;
            telaReposicao.TelaFuncionario = telaFuncionario;
            telaReposicao.TelaMedicamento = telaMedicamento;

            TelaRequisicao telaRequisicao = new TelaRequisicao();
            telaRequisicao.Repositorio = repositorioRequisicao;
            telaRequisicao.TelaFuncionario = telaFuncionario;
            telaRequisicao.TelaPaciente = telaPaciente;
            telaRequisicao.TelaMedicamento = telaMedicamento;
            #endregion

            PopularRegistros(repositorioFornecedor,
                             repositorioFuncionario,
                             repositorioMedicamento,
                             repositorioPaciente);

            string opcao;
            string opcaoCadastro;

            while (true)
            {
                opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                switch (opcao)
                {
                    case "1":
                        opcaoCadastro = telaFornecedor.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaFornecedor.InserirElemento();
                                break;
                            case "2":
                                telaFornecedor.VisualizarElementos();
                                break;
                            case "3":
                                telaFornecedor.EditarElemento();
                                break;
                            case "4":
                                telaFornecedor.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        opcaoCadastro = telaFuncionario.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaFuncionario.InserirElemento();
                                break;
                            case "2":
                                telaFuncionario.VisualizarElementos();
                                break;
                            case "3":
                                telaFuncionario.EditarElemento();
                                break;
                            case "4":
                                telaFuncionario.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        opcaoCadastro = telaMedicamento.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaMedicamento.InserirElemento();
                                break;
                            case "2":
                                telaMedicamento.VisualizarElementos();
                                break;
                            case "3":
                                telaMedicamento.EditarElemento();
                                break;
                            case "4":
                                telaMedicamento.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        opcaoCadastro = telaPaciente.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaPaciente.InserirElemento();
                                break;
                            case "2":
                                telaPaciente.VisualizarElementos();
                                break;
                            case "3":
                                telaPaciente.EditarElemento();
                                break;
                            case "4":
                                telaPaciente.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "5":
                        opcaoCadastro = telaReposicao.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaReposicao.InserirElemento();
                                break;
                            case "2":
                                telaReposicao.VisualizarElementos();
                                break;
                            case "3":
                                telaReposicao.EditarElemento();
                                break;
                            case "4":
                                telaReposicao.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "6":
                        opcaoCadastro = telaRequisicao.ApresentarMenuCadastroElemento();

                        switch (opcaoCadastro)
                        {
                            case "1":
                                telaRequisicao.InserirElemento();
                                break;
                            case "2":
                                telaRequisicao.VisualizarElementos();
                                break;
                            case "3":
                                telaRequisicao.EditarElemento();
                                break;
                            case "4":
                                telaRequisicao.ExcluirElemento();
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("Controle de Medicamentos 1.0\n"
                            + "->Digite 1 para Cadastrar Fornecedores\n"
                            + "->Digite 1 para Cadastrar Funcionarios\n"
                            + "->Digite 2 para Cadastrar Medicamento\n"
                            + "->Digite 3 para Cadastrar Paciente\n"
                            + "->Digite 4 para Cadastrar Reposição\n"
                            + "->Digite 4 para Cadastrar Requisição\n"
                            + "\n"
                            + "->Digite s para Sair");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        private static void PopularRegistros(RepositorioFornecedor repositorioFornecedor,
                                             RepositorioFuncionario repositorioFuncionario,
                                             RepositorioMedicamento repositorioMedicamento,
                                             RepositorioPaciente repositorioPaciente)
        {
            EntidadeFuncionario funcionario1 = new EntidadeFuncionario("Alexandre Rech", "rech", "123");
            EntidadeFuncionario funcionario2 = new EntidadeFuncionario("Tiago Santini", "santini", "456");

            repositorioFuncionario.Inserir(funcionario1);
            repositorioFuncionario.Inserir(funcionario2);

            EntidadeFornecedor fornecedor1 = new EntidadeFornecedor("Ultrafarma", "987654312", "49 9 0000-0000", "Lages");
            EntidadeFornecedor fornecedor2 = new EntidadeFornecedor("Medica Super", "12345679", "49 9 0000-0000", "Lages");

            repositorioFornecedor.Inserir(fornecedor1);
            repositorioFornecedor.Inserir(fornecedor2);

            EntidadeMedicamento medicamento1 = new EntidadeMedicamento("Gliclazida", "Remédio p/ Diabetes", 50);
            EntidadeMedicamento medicamento2 = new EntidadeMedicamento("Entresto", "Remédio p/ Coração", 70);

            repositorioMedicamento.Inserir(medicamento1);
            repositorioMedicamento.Inserir(medicamento2);

            EntidadePaciente paciente1 = new EntidadePaciente("Gabriel Rech", "741258963");
            EntidadePaciente paciente2 = new EntidadePaciente("Palmira Souza", "582147852");
            EntidadePaciente paciente3 = new EntidadePaciente("Léo Rech", "111111111");
            EntidadePaciente paciente4 = new EntidadePaciente("Diane Rech", "222222222");

            repositorioPaciente.Inserir(paciente1);
            repositorioPaciente.Inserir(paciente2);
            repositorioPaciente.Inserir(paciente3);
            repositorioPaciente.Inserir(paciente4);
        }
    }
}