namespace AtecTrabalhoGrupo1
{
    internal class Interface
    {
        //UI principal
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
                    7 - Sair da aplicação." +
                    "\nEscolhe uma opção:");

                string escolhaString = Console.ReadLine();
                escolhaVálida = int.TryParse(escolhaString, out escolha);

                if (escolhaVálida == true)
                {
                    if (escolha > 0 && escolha <= 7)
                    {
                        //switch statements - talvez criar um metodo para processar escolha!
                        switch (escolha)
                        {
                            case 1:
                                MostrarDetalhesEmpresa();
                                break;
                            case 2:
                                MostrarListaFuncionários();

                                Console.WriteLine("\nClique qualquer butão para continuar!");
                                Console.ReadLine();
                                Console.Clear();

                                break;
                            case 3:
                                CriarNovoFuncionário();
                                break;
                            case 4:
                                RemoverFuncionário();
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                Console.WriteLine("A sair da aplicação...");
                                Console.ReadLine();
                                break;
                        }
                    }
                    else
                    {
                        //Erro!
                        escolhaVálida = false;

                        Console.WriteLine("Escolha uma opção/número entre 1-7!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    //Erro!
                    Console.WriteLine("Escolha inválida! Digite um valor númerico!");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while(escolhaVálida == false || escolha != 7);
        }

        //Funções interface
        public static void MostrarDetalhesEmpresa()
        {
            Console.Clear();

            string nomeDaEmpresa = Empresa.nome;
            int totalFuncionários = Empresa.ObterNúmeroTotalDeFuncionários(Empresa.funcionarios); // testar para ver se funciona!!!!
            decimal despesasSaláriais = Empresa.DespesaSalários(Empresa.funcionarios);

            Console.WriteLine("Detalhes da Empresa:\n" +
                $"Nome: {nomeDaEmpresa}\n" +
                $"Nº de Funcionários: {totalFuncionários}\n" +
                $"Despesas saláriais totais: {despesasSaláriais}\n\n" +
                "Clique qualquer butão para continuar!");
            Console.ReadLine();

            Console.Clear();
        }

        public static void MostrarListaFuncionários()
        {
            Console.Clear();

            Console.WriteLine("Lista de empregados:");

            foreach(var funcionário in Empresa.funcionarios) //a lista de funcionarios é uma propriedade estatica da classe empresa!
            {
                Console.WriteLine($"Funcionário Nº{funcionário.Id}, Nome: {funcionário.Nome}, Salario: {funcionário.Salário}"); //Mostrar mais propriedades? Usar libraria para tabela??
            }
        }

        public static void CriarNovoFuncionário()
        {
            Funcionario teste = new Funcionario() //Addionar funcionalidade para deixar o usuario por data de cada Funcionário
            {
                Id = Empresa.funcionarios.LastOrDefault().Id + 1, //Verificar o id do ultimo empregado na lista (id mais alto) e adicionar 1, para criar empregado com proximo id!
                Nome = "teste",
                Salário = 1200,
            };

            Empresa.funcionarios.Add(teste);

            Console.WriteLine("Funcionário criado com sucesso!");
            Console.ReadLine();
            Console.Clear();
        }

        public static void RemoverFuncionário()
        {
            bool escolhaVálida;
            int id;

            do
            {
                MostrarListaFuncionários();

                Console.WriteLine("\nDigite o Id do funcionário para remover:");

                string escolhaString = Console.ReadLine();
                escolhaVálida = int.TryParse(escolhaString, out id);

                if(escolhaVálida == false)
                {
                    //Erro!
                    Console.WriteLine("Escolha inválida! Digite um valor númerico!");
                    Console.ReadLine();
                }
                else if(!Empresa.funcionarios.Any(func => func.Id == id))
                {
                    //Erro!
                    escolhaVálida = false;

                    Console.WriteLine("Id escolhido não existe!");
                    Console.ReadLine();
                }
                else 
                {
                    Funcionario funcionarioParaRemover = Empresa.funcionarios.Where(func => func.Id == id).FirstOrDefault();
                    Empresa.funcionarios.Remove(funcionarioParaRemover);
                }

            } while (escolhaVálida == false);
        }
    }
}
