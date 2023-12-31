namespace AtecTrabalhoGrupo1
{
    internal class Funcionario
    {
        public int Id {  get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public decimal SalárioPorHora { get; set; }
        public decimal SalárioMensal { get; set; }
        public DateTime FimDeContrato { get; set; } //só é definido quando termina o contrato (quando removemos o empregado).
        public DateTime DataDeRegistoCriminal { get; set; }

        public bool IsençaoDeBonus { get; set; }
        public bool BonusMensal {  get; set; }
        public bool CarroDaEmpresa { get; set; }

        public bool ÈChefe {  get; set; }
        public int SupervisorId {  get; set; } //funcionário supervisor identificado pelo seu ID de funcionário.
        public Areas Area { get; set; }

        public TipologiaDisponibilidade Disponibilidade { get; set; }
        public TipologiaHorário Turno {  get; set; }
        public Horário[] HorárioSemanal { get; set; } = new Horário[5]; //5 dias da semana (Seg-Sex).

        public enum TipologiaDisponibilidade
        {
            PosLaboral,
            Laboral,
            Ambas
        }
        public enum TipologiaHorário
        {
            PosLaboral,
            Laboral,
            NãoDefinido,
        }
        public enum Areas
        {
            Financeira,
            IT,
            RH,
        }
    }
}
