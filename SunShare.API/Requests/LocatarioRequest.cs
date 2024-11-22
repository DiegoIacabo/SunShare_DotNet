﻿namespace SunShare.API.Requests
{
    public class LocatarioRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PowerCompany { get; set; }
        public int AverageUsage { get; set; }
    }
}