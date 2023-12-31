
namespace AtecTrabalhoGrupo1
{
    internal class Empresa
    {
        //Propriedades
        public static string nome = "ADOSMELHORES";

        public static List<Funcionario> funcionarios = CriarListaDeFuncionáriosInicial();
        public static List<Funcionario> antigosFuncionários = new List<Funcionario>();

        //Funções
        public static List<Funcionario> CriarListaDeFuncionáriosInicial()
        {
            List<Funcionario> funcionarios = new List<Funcionario>()
            {
                new Funcionario
                {
                    Id = 1,
                    Nome = "João",
                    Morada = "Rua das Arnelas, Nº520; Canedo",
                    DataDeRegistoCriminal = new DateTime(2023, 1, 15, 14, 30, 0),
                    CarroDaEmpresa = true,
                    SalárioPorHora = 7,
                    Disponibilidade = Funcionario.TipologiaDisponibilidade.PosLaboral,
                    Turno = Funcionario.TipologiaHorário.PosLaboral,
                    SalárioMensal = Metodos.CalcularSalarioMensal(7, Funcionario.TipologiaHorário.PosLaboral),
                    ÈChefe = false,
                    Area = Funcionario.Areas.IT,
                    SupervisorId = 2, 
                },
                new Funcionario
                {
                    Id = 2,
                    Nome = "Ana",
                    Morada = "Rua da Fontainha, Nº210; Arnelas",
                    DataDeRegistoCriminal = new DateTime(2023, 5, 20, 14, 30, 0),
                    CarroDaEmpresa = true,
                    SalárioPorHora = 9,
                    Disponibilidade = Funcionario.TipologiaDisponibilidade.Laboral,
                    Turno = Funcionario.TipologiaHorário.Laboral,
                    SalárioMensal = Metodos.CalcularSalarioMensal(7, Funcionario.TipologiaHorário.Laboral),
                    ÈChefe = true,
                    Area = Funcionario.Areas.IT
                },
                new Funcionario
                {
                    Id = 3,
                    Nome = "Miguel",
                    Morada = "Rua das Ruas, Nº110; Canelas",
                    DataDeRegistoCriminal = new DateTime(2023, 8, 20, 14, 30, 0),
                    CarroDaEmpresa = true,
                    SalárioPorHora = 8,
                    Disponibilidade = Funcionario.TipologiaDisponibilidade.Ambas,
                    Turno = Funcionario.TipologiaHorário.NãoDefinido,
                    //SalárioMensal só é calculado depois de turno/horario ser definido!
                    ÈChefe = false,
                    Area = Funcionario.Areas.IT,
                    SupervisorId = 2,
                }

            };

            return funcionarios;
        }

        public static int ObterNúmeroTotalDeFuncionários(List<Funcionario> funcionarios)
        {
            int totalFuncionários = funcionarios.Count;
            return totalFuncionários;
        }

        public static decimal DespesaSalários(List<Funcionario> funcionarios)
        {
            decimal total = 0;

            foreach (var funcionario in funcionarios)
            {
                total += funcionario.SalárioMensal;
            }

            return total;
        }
    }
}
