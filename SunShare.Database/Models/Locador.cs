namespace SunShare.Database.Models
{
    public class Locador
    {
        public Locador(string name, string email, string cpf, string phoneNumber, string powerCompany, int averageProduction, int availableEnergy)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            PhoneNumber = phoneNumber;
            PowerCompany = powerCompany;
            AverageProduction = averageProduction;
            AvailableEnergy = availableEnergy;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PowerCompany { get; set; }
        public int AverageProduction { get; set; }
        public int AvailableEnergy { get; set; }
    }
}
