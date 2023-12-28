
namespace AtecTrabalhoGrupo1
{
    internal class Empresa
    {
        //Propriedades
        public static string nome = "ADOSMELHORES";

        public static List<Funcionario> funcionarios = CriarListaDeFuncionáriosInicial();

        //Funções
        public static List<Funcionario> CriarListaDeFuncionáriosInicial()
        {
            List<Funcionario> funcionarios = new List<Funcionario>()
            {
                new Funcionario // definir empregado
                {
                    Id = 1,
                    Nome = "João",
                    Morada = "Rua das Costouras",
                    FimDeContrato = 2021,
                    DataDeRegistoCriminal = 2023,
                    IsençaoDeBonus = true,
                    BonusMensal = true,
                    CarroDaEmpresa = true,
                    Salário = 1000,
                },
                new Funcionario // definir empregado
                {
                    Id = 2,
                    Nome = "ANA",
                    Morada = "Rua das Costouras",
                    FimDeContrato = 2021,
                    DataDeRegistoCriminal = 2023,
                    IsençaoDeBonus = true,
                    BonusMensal = true,
                    CarroDaEmpresa = true,
                    Salário = 1000,
                }

            };

            return funcionarios;
        }


        public static int ObterNúmeroTotalDeFuncionários(List<Funcionario> funcionarios)
        {
            int totalFuncionários = funcionarios.Count;
            return totalFuncionários;
        }



        //MetodoRodrigo
        public void calcularSalario(Funcionario funcionario, Funcionario.Disponibilidade preferenciaHorario = Funcionario.Disponibilidade.Laboral)
        {
            if (funcionario.Disp == Funcionario.Disponibilidade.Laboral)
            {
                decimal salarioMensal = (funcionario.ValorHora * 8) * 23;   //Calculo valor mensal
                funcionario.ValorMensal = salarioMensal;    //Guarda o valor mensal do funcionario
            }

            else if (funcionario.Disp == Funcionario.Disponibilidade.PosLaboral)
            {
                decimal salarioMensal = (funcionario.ValorHora * 5) * 23;
                funcionario.ValorMensal = salarioMensal;
            }

            else
            {
                if (preferenciaHorario == Funcionario.Disponibilidade.Laboral)
                {
                    foreach (var dia in funcionario.HorariosSemanal)
                    {
                        decimal salarioMensal = (funcionario.ValorHora * 8) * 23;
                        funcionario.ValorMensal = salarioMensal;
                    }
                }

                else if (preferenciaHorario == Funcionario.Disponibilidade.PosLaboral)
                {
                    foreach (var dia in funcionario.HorariosSemanal)
                    {
                        decimal salarioMensal = (funcionario.ValorHora * 5) * 23;
                        funcionario.ValorMensal = salarioMensal;
                    }
                }
            }
        }
        //metodo


        public static decimal DespesaSalários(List<Funcionario> funcionarios)
        {
            decimal total = 0;

            foreach (var funcionario in funcionarios)
            {
                total += funcionario.Salário;
            }

            return total;
        }
    }
}
