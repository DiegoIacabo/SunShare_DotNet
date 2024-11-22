namespace SunShare.Database.Models
{
    public class Locatario
    {
        public Locatario(string name, string email, string cpf, string phoneNumber, string powerCompany, int averageUsage)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
            PhoneNumber = phoneNumber;
            PowerCompany = powerCompany;
            AverageUsage = averageUsage;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PowerCompany { get; set; }
        public int AverageUsage { get; set; }


    }
}
