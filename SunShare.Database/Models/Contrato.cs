namespace SunShare.Database.Models
{
    public class Contrato
    {
        public Contrato(int locadorId, int locatarioId, int duration, float price, int amountOfEnergy, string termsAndConditions)
        {
            LocadorId = locadorId;
            LocatarioId = locatarioId;
            Duration = duration;
            Price = price;
            AmountOfEnergy = amountOfEnergy;
            TermsAndConditions = termsAndConditions;
        }

        public int Id { get; set; }
        public int LocadorId { get; set; }
        public int LocatarioId { get; set; }
        public int Duration { get; set; }
        public int AmountOfEnergy { get; set; }
        public float Price { get; set; }
        public string TermsAndConditions { get; set; }
    }
}
