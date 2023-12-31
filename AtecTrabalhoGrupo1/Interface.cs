using System.Globalization;

namespace AtecTrabalhoGrupo1
{
    internal class Interface
    {
        //Menu Principal
        public static void MenuPrincipal()
        {
            bool escolhaVálida;
            int escolha;

            do
            {
                Console.WriteLine("Menu Principal:\n" +
                  @"
                    1 - Ver detalhes da empresa.
                    2 - Ver Lista de Empregados.
                    3 - Criar Empregado.
                    4 - Remover Empregado.
                    5 - Alocar horário a empregado.
                    6 - Ver Empregados sem horário.
                    7 - Pagamento a Funcionário.
                    8 - Guardar detalhes em ficheiro.
                    9 - Ler detalhes de ficheiro.   
                    10 - Sair da aplicação." +
                    "\nEscolhe uma opção:");

                string escolhaString = Console.ReadLine();
                escolhaVálida = int.TryParse(escolhaString, out escolha);

                if (escolhaVálida == true)
                {
                    if (escolha > 0 && escolha <= 10)
                    {
                        switch (escolha)
                        {
                            case 1:
                                Console.WriteLine("Detalhes da empresa.");
                                MostrarDetalhesEmpresa();
                                break;
                            case 2:
                                Console.WriteLine("´Lista de funcionários.");
                                MostrarListaFuncionários();

                                Console.WriteLine("\nClique qualquer butão para continuar!");
                                Console.ReadLine();
                                Console.Clear();

                                break;
                            case 3:
                                Console.WriteLine("Criar Funcionário.");
                                CriarNovoFuncionário();
                                break;
                            case 4:
                                Console.WriteLine("Remover Funcionário.");
                                MostrarListaFuncionários();
                                Funcionario funcionárioParaRemover = EscolherFuncionárioPorID();
                                RemoverFuncionário(funcionárioParaRemover);
                                Console.Clear();
                                break;
                            case 5:
                                Console.WriteLine("Alocar horário a funcionário.");
                                Funcionario funcionario = EscolherFuncionárioPorID();
                                funcionario = Metodos.AlocarHorário(funcionario);
                                funcionario.SalárioMensal = Metodos.CalcularSalarioMensal(funcionario.SalárioPorHora, funcionario.Turno);
                                AtualizarFuncionário(funcionario);

                                Console.Clear();
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Funcionários sem Horário:");
                                List<Funcionario> funcionariosSemHorario = Metodos.FuncionariosSemHorário();

                                foreach(var funcionário in funcionariosSemHorario)
                                {
                                    Console.WriteLine($"Funcionário Nº{funcionário.Id}, Nome: {funcionário.Nome}, Salario (por hora): {funcionário.SalárioPorHora}, Turno: {funcionário.Turno}, Salario Mensal: {funcionário.SalárioMensal}"); //Mostrar mais propriedad
                                }
                                Console.ReadLine();
                                Console.Clear();

                                break;
                            case 7:
                                Metodos.PagamentoPorFuncionário();
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Guardar detalhes de empresa em ficheiro:");
                                string conteudoParaGuardar = Metodos.CriarConteudo();
                                Metodos.GuardarDados(conteudoParaGuardar);
                                Console.Clear();
                                break;
                            case 9:
                                Console.Clear();

                                Console.WriteLine("Ler informação do ficheiro...");
                                string conteudoLido = Metodos.LerFicheiro();
                                Console.WriteLine(conteudoLido);
                                Console.ReadLine();

                                Console.Clear();

                                break;
                            case 10:
                                Console.WriteLine("A sair da aplicação...");
                                Console.ReadLine();
                                break;
                        }
                    }
                    else//Erro!
                    {
                        
                        escolhaVálida = false;

                        Console.WriteLine("Escolha uma opção/número entre 1-7!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else//Erro!
                {
                    Console.WriteLine("Escolha inválida! Digite um valor númerico!");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while(escolhaVálida == false || escolha != 7);
        }


        public static void AtualizarFuncionário(Funcionario funcionarioAtualizado)
        {
            Funcionario funcionarioDesatualizado = Empresa.funcionarios.Where(f => f.Id == funcionarioAtualizado.Id).FirstOrDefault();

            Empresa.funcionarios.Remove(funcionarioDesatualizado);
            Empresa.funcionarios.Add(funcionarioAtualizado);
            Empresa.funcionarios.OrderBy(f => f.Id).ToList();
        }

        public static Funcionario DefinirDisponibilidadeDeHorário(Funcionario funcionario)
        {
            bool escolhaVálida;
            int escolha;

            do
            {
                Console.WriteLine("Qual a disponibilidade de horário do funcionário - 1 (Laboral), 2 (Pós-Laboral) ou 3 (Ambas):");
                string escolhaString = Console.ReadLine();
                escolhaVálida = int.TryParse(escolhaString, out escolha);

                if (escolhaVálida == true)
                {
                    if (escolha > 0 && escolha <= 3)
                    {
                        switch (escolha)
                        {
                            case 1:
                                funcionario.Disponibilidade = Funcionario.TipologiaDisponibilidade.Laboral;
                                break;
                            case 2:
                                funcionario.Disponibilidade = Funcionario.TipologiaDisponibilidade.PosLaboral;
                                break;
                            case 3:
                                funcionario.Disponibilidade = Funcionario.TipologiaDisponibilidade.Ambas;
                                break;
                        }
                    }
                    else
                    {
                        //Erro!
                        escolhaVálida = false;

                        Console.WriteLine("Escolha uma opção/número entre 1-3!");
                        Console.ReadLine();
                    }
                }
                else
                {
                    //Erro!
                    Console.WriteLine("Escolha inválida! Digite um valor númerico!");
                    Console.ReadLine();
                }
            } while (escolhaVálida == false);

            return funcionario;
        }

        public static void MostrarDetalhesEmpresa()
        {
            Console.Clear();

            string detalhesDaEmpresa = Metodos.CriarConteudo();
            detalhesDaEmpresa += "\nClique qualquer butão para continuar!";

            Console.WriteLine(detalhesDaEmpresa);
            Console.ReadLine();

            Console.Clear();
        }

        public static void MostrarListaFuncionários()
        {
            Console.Clear();

            Console.WriteLine("Lista de empregados:");

            foreach(var funcionário in Empresa.funcionarios) //a lista de funcionarios é uma propriedade estatica da classe empresa!
            {
                Console.WriteLine($"Funcionário Nº{funcionário.Id}, Nome: {funcionário.Nome}, Salario (por hora): {funcionário.SalárioPorHora}, Turno: {funcionário.Turno}, Salario Mensal: {funcionário.SalárioMensal}");
            }
        }

        public static void CriarNovoFuncionário()
        {
            Funcionario novoFuncionário = new Funcionario()
            {
                Id = Empresa.funcionarios.LastOrDefault().Id + 1,
            };

            //Nome
            Console.WriteLine("Escreva o nome do novo funcionário");
            novoFuncionário.Nome = Console.ReadLine();

            //Morada
            Console.WriteLine("Escreva a morada do novo funcionário");
            novoFuncionário.Nome = Console.ReadLine();

            //Salário por Hora
            bool salárioPorHoraVálido;
            do
            {
                Console.WriteLine("Digite o valor do salário por hora do novo funcionário:");
                string salárioPorHoraString = Console.ReadLine();
                salárioPorHoraVálido = decimal.TryParse(salárioPorHoraString, out decimal salárioPorHora);

                if (salárioPorHoraVálido != true)
                {
                    Console.WriteLine("Digite um valor válido para o salário!");
                }
                else
                {
                    novoFuncionário.SalárioPorHora = salárioPorHora;
                }
            } while (salárioPorHoraVálido == false);

            //Data de registo criminal
            DateTime data;
            bool dataVálida;
            do
            {
                Console.WriteLine("Escreva a data de registo criminal do novo funcionário (dd/MM/yyyy):");
                string dataString = Console.ReadLine();

                (dataVálida, data) = VerificarValidadeDaData(dataString);

                novoFuncionário.DataDeRegistoCriminal = data;

                if(dataVálida == false)
                {
                    Console.WriteLine("Data inválida! Digite uma data no formato indicado!");
                    Console.ReadLine();
                }

            } while (dataVálida == false);

            //Carro da empresa
            bool carroEmpresaVálido;
            bool carroEmpresaEscolha;

            do
            {
                Console.WriteLine("Define se funcionário tem direito a carro da empresa. Digite 1 (Sim) ou 2 (Não): ");
                string escolhaString = Console.ReadLine();

                (carroEmpresaVálido, carroEmpresaEscolha) = TrueOrFalseInput(escolhaString);

                if(carroEmpresaVálido == true)
                {
                    novoFuncionário.CarroDaEmpresa = carroEmpresaEscolha;
                }

            } while (carroEmpresaVálido == false);

            //Disponibilidade de horário
            novoFuncionário = DefinirDisponibilidadeDeHorário(novoFuncionário);

            novoFuncionário.Turno = Funcionario.TipologiaHorário.NãoDefinido; //O turno do funcionário é definido em alocar Horário.

            Empresa.funcionarios.Add(novoFuncionário);

            Console.WriteLine("Funcionário criado com sucesso!");
            Console.ReadLine();
            Console.Clear();
        }

        //(validação, input)
        public static (bool, bool) TrueOrFalseInput(string inputString)
        {
            bool escolha = false;
            int input;

            bool escolhaVálida = int.TryParse(inputString, out input);

            if(input == 1 || input == 2)
            {
                switch (input)
                {
                    case 1:
                        escolha = true;
                        break;
                    case 2:
                        escolha = false;
                        break;
                }
            }
            else
            {
                escolhaVálida = false;

                Console.WriteLine("Input inválido! Digite o número: 1 (Sim) ou 2 (Não)!");
                Console.ReadLine();
            }

            return (escolhaVálida, escolha);
        }

        public static (bool, DateTime) VerificarValidadeDaData(string input)
        {
            DateTime data;
            bool dataVálida;

            dataVálida = DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);

            return (dataVálida, data);
        }

        public static Funcionario EscolherFuncionárioPorID()
        {
            bool escolhaVálida;
            int id;
            Funcionario funcionarioEscolhido = null;

            do
            {
                MostrarListaFuncionários();

                Console.WriteLine("\nDigite o Id do funcionário para o selecionar:");
                string escolhaString = Console.ReadLine();

                (escolhaVálida, id) = Metodos.ValidarIdDoFuncionário(escolhaString);

                if (escolhaVálida == true)
                {
                    funcionarioEscolhido = Empresa.funcionarios.Where(func => func.Id == id).FirstOrDefault();
                }
            } while (escolhaVálida == false);

            return funcionarioEscolhido;
        }

        public static void RemoverFuncionário(Funcionario funcionarioParaRemover)
        {
            funcionarioParaRemover.FimDeContrato = DateTime.Now;

            Empresa.funcionarios.Remove(funcionarioParaRemover);

            Empresa.antigosFuncionários.Add(funcionarioParaRemover);
        }
    }
}
