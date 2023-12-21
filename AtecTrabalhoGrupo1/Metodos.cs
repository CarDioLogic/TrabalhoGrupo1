
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
        

        //metodo recebe 2 argumentos: 1 funcionario e 1 preferencia horario que tem como default a tipologia Laboral
        public void AlocarHorário(Funcionario funcionario, Funcionario.TipologiaDisponibilidade preferênciaHorário = Funcionario.TipologiaDisponibilidade.Laboral)
        {
            if(funcionario != null)
            {
                //para horário laboral
                if (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Laboral || 
                    (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Ambas && preferênciaHorário == Funcionario.TipologiaDisponibilidade.Laboral))
                {
                    foreach(var day in funcionario.HorárioSemanal)
                    {
                        day.InicioTurno = DateTime.MinValue + new TimeSpan(10, 0, 0); //hh, mm, ss
                        day.FimTurno = DateTime.MinValue + new TimeSpan(18, 0, 0);
                    };
                }

                //para horário pós-laboral
                if (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.PosLaboral ||
                (funcionario.Disponibilidade == Funcionario.TipologiaDisponibilidade.Ambas && preferênciaHorário == Funcionario.TipologiaDisponibilidade.PosLaboral))
                {
                    foreach (var day in funcionario.HorárioSemanal)
                    {
                        day.InicioTurno = DateTime.MinValue + new TimeSpan(18, 0, 0);
                        day.FimTurno = DateTime.MinValue + new TimeSpan(00, 0, 0);
                    };
                }
            }
        }

        //TESTAR ESTE METODO!!!!! IMPORTANTE!!!
        public List<Funcionario> FuncionariosSemHorário(List<Funcionario> funcionarios)
        {
            List<Funcionario> funcionáriosSemHorário = new List<Funcionario>();

            foreach(var funcionario in funcionarios)
            {
                //|| funcionario.HorárioSemanal == default(DateTime) || horario.FimTurno == default(DateTime)
                if (funcionario.HorárioSemanal == null )
                {
                    funcionáriosSemHorário.Add(funcionario);
                }
            }

            return funcionarios;
        }


        public string CriarConteudo(string empresaNome, int numFuncionários, decimal despesaSalários)
        {
            string conteudo = "";
            conteudo = "Secção Empresa:\n" +
                $"Nome da Empresa: {empresaNome}\n" +
                $"Nº de Funcionários: {numFuncionários}" +
                $"Despesas saláriais: {despesaSalários}";

            //Talvez uma secção para escrever a lista de funcionários!

            return conteudo;
        }

        public void GuardarDados(string conteudo, string filePath)
        {
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

        static string LerFicheiro(string filePath)
        {
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
