namespace AtecTrabalhoGrupo1
{
    internal class Funcionario
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public decimal Salário { get; set; }
        public int FimDeContrato { get; set; } // mudar para datetime mais tarde
        public int DataDeRegistoCriminal { get; set; } // mudar para datetime mais tarde

        public bool IsençaoDeBonus { get; set; }
        public bool BonusMensal {  get; set; }
        public bool CarroDaEmpresa { get; set; }

        public string Chefe {  get; set; }
        public string Area { get; set; }

        public TipologiaDisponibilidade Disponibilidade { get; set; }

        public Horário[] HorárioSemanal { get; set; } = new Horário[5];

        public enum TipologiaDisponibilidade
        {
            PosLaboral,
            Laboral,
            Ambas
        }
    }
}
