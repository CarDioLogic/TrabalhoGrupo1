
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
                total += funcionario.Salário;
            }

            return total;

        }
    }
}
