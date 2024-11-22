namespace SunShare.API.Configuration
{
    public class ApiConfiguration
    {
        public SwaggerInfo Swagger { get; set; }

        public OracleServiceConnection OracleDb { get; set; }


        public class SwaggerInfo
        {
            public string Title { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }


        public class OracleServiceConnection
        {
            public string Host { get; set; }

            public string UserID { get; set; }

            public string Password { get; set; }

            public int Port { get; set; }

            public string SID { get; set; }


            public string ConnectionString
            {
                get { return $"Data Source={Host}:{Port}/{SID};User ID={UserID};Password={Password};"; }
            }

        }

    }    
}
