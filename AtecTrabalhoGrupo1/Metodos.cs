
namespace AtecTrabalhoGrupo1
{
    internal class Metodos
    {
        public void ImprimirListaFuncionários(List<Funcionario> funcionarios)
        {
            Console.WriteLine("Lista de Funcionários");

            foreach(var funcionario in funcionarios)
            {
                Console.WriteLine($@"Id: {funcionario.Id}; Nome: {funcionario.Nome}");
            }

            Console.ReadLine();
        }
        
        public static Funcionario AlocarHorário(Funcionario funcionario)
        {
            if(funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Ambas)
            {
                bool escolhaVálida;
                int escolha;

                do
                {
                    Console.WriteLine("O funcionário tem disponibilade para ambos horários! Qual a preferência de horário - 1 (Laboral) ou 2 (Pós-Laboral):");
                    string escolhaString = Console.ReadLine();
                    escolhaVálida = int.TryParse(escolhaString, out escolha);

                    if (escolhaVálida == true)
                    {
                        if (escolha == 1 || escolha == 2)
                        {
                            switch (escolha)
                            {
                                case 1:
                                    funcionario.Turno = Funcionario.TipologiaHorário.Laboral;
                                    break;
                                case 2:
                                    funcionario.Turno = Funcionario.TipologiaHorário.PosLaboral;
                                    break;
                            }
                        }
                        else
                        {
                            //Erro!
                            escolhaVálida = false;

                            Console.WriteLine("Escolha uma opção/número entre 1-2!");
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
            }

            //Alocar Horário semanal em array para cronograma
            if(funcionario != null)
            {
                if (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Laboral || 
                    (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Ambas && funcionario.Turno == Funcionario.TipologiaHorário.Laboral))
                {
                    for (int i = 0; i < funcionario.HorárioSemanal.Length; i++)
                    {
                        funcionario.HorárioSemanal[i] = new Horário();

                        funcionario.HorárioSemanal[i].InicioTurno = DateTime.MinValue + new TimeSpan(10, 0, 0);
                        funcionario.HorárioSemanal[i].FimTurno = DateTime.MinValue + new TimeSpan(18, 0, 0);
                    }
                }
                if (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.PosLaboral ||
                (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Ambas && funcionario.Turno == Funcionario.TipologiaHorário.PosLaboral))
                {
                    for (int i = 0; i < funcionario.HorárioSemanal.Length; i++)
                    {
                        funcionario.HorárioSemanal[i] = new Horário();

                        funcionario.HorárioSemanal[i].InicioTurno = DateTime.MinValue + new TimeSpan(18, 0, 0);
                        funcionario.HorárioSemanal[i].FimTurno = DateTime.MinValue + new TimeSpan(00, 0, 0);
                    }
                }  
            }

            return funcionario;
        }

        public static decimal CalcularSalarioMensal(decimal salarioPorHora, Funcionario.TipologiaHorário turno)
        {
            if (turno == Funcionario.TipologiaHorário.Laboral)
            {
                decimal salarioMensal = (salarioPorHora * 8) * 23;
                return salarioMensal;
            }
            else if (turno == Funcionario.TipologiaHorário.PosLaboral)
            {
                decimal salarioMensal = (salarioPorHora * 5) * 23;
                return salarioMensal;
            }

            return 0;
        }

        public static List<Funcionario> FuncionariosSemHorário()
        {
            List<Funcionario> funcionarios = Empresa.funcionarios;
            List<Funcionario> funcionáriosSemHorário = new List<Funcionario>();

            foreach(var funcionario in funcionarios)
            {
                if (funcionario.Turno == Funcionario.TipologiaHorário.NãoDefinido )
                {
                    funcionáriosSemHorário.Add(funcionario);
                }
            }
            if(funcionáriosSemHorário.Count == 0)
            {
                Console.WriteLine("Não existem funcionários sem horário!");
            }

            return funcionáriosSemHorário;
        }

        public static decimal PagamentoPorFuncionário()
        {
            bool escolhaVálida;
            int id;

            decimal salárioAPagar = 0;
            decimal bonusMensal = 100;

            do
            {
                Interface.MostrarListaFuncionários();

                Console.WriteLine("\nDigite o Id do funcionário para fazer pagamento:");
                string escolhaString = Console.ReadLine();

                (escolhaVálida, id) = ValidarIdDoFuncionário(escolhaString);

                if(escolhaVálida == true)
                {
                    Funcionario funcionario = Empresa.funcionarios.Where(f => f.Id == id).FirstOrDefault();
                    salárioAPagar = funcionario.SalárioMensal;

                    if(funcionario.BonusMensal == true)
                    {
                        salárioAPagar += bonusMensal;
                    }
                }
            } while (escolhaVálida == false);

            return salárioAPagar;
        }

        //Metódo para validar inputs de ID de funcionários na lista
        public static (bool, int) ValidarIdDoFuncionário(string escolhaString)
        {
            int idInput = -1;
            bool escolhaVálida = int.TryParse(escolhaString, out idInput);

            if (escolhaVálida == false)
            {
                //Erro!
                Console.WriteLine("Escolha inválida! Digite um valor númerico!");
                Console.ReadLine();
            }
            else if (!Empresa.funcionarios.Any(func => func.Id == idInput))
            {
                //Erro!
                escolhaVálida = false;

                Console.WriteLine("Id escolhido não existe!");
                Console.ReadLine();
            }

            return (escolhaVálida, idInput);
        }

        public static string CriarConteudo()
        {
            string nomeDaEmpresa = Empresa.nome;
            int totalFuncionários = Empresa.ObterNúmeroTotalDeFuncionários(Empresa.funcionarios);
            decimal despesasSaláriais = Empresa.DespesaSalários(Empresa.funcionarios);

            string conteudo = "";

            conteudo = "Secção Empresa:\n" +
                $"Nome da Empresa: {nomeDaEmpresa}\n" +
                $"Nº de Funcionários: {totalFuncionários}\n" +
                $"Despesas saláriais: {despesasSaláriais}\n";

            return conteudo;
        }

        public static void GuardarDados(string conteudo)
        {
            conteudo += $"\nDados guardados a: {DateTime.Now}";

            Console.WriteLine("Escreva o directorio do ficheiro onde pretende guardar os detalhes da empresa");
            string filePath = Console.ReadLine();

            try
            {
                File.WriteAllText(filePath, conteudo);

                Console.WriteLine($"Os dados foram guardados em {filePath}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao guardar: {ex.Message}");
            }

            Console.ReadLine();
        }

        public static string LerFicheiro()
        {
            Console.WriteLine("Escreva o directorio do ficheiro de onde pretende ler os detalhes da empresa");
            string filePath = Console.ReadLine();

            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler ficheiro: {ex.Message}");
                Console.ReadLine();

                return string.Empty;
            }
        }
    }
}
