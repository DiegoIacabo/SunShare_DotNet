namespace SunShare.API.Requests
{
    public class ContratoRequest
    {
        public int LocadorId { get; set; }
        public int LocatarioId { get; set; }
        public int Duration { get; set; }
        public int AmountOfEnergy { get; set; }
        public float Price { get; set; }
        public string TermsAndConditions { get; set; }
    }
}
