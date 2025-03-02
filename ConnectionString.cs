namespace CRUD_ADO
{
    public class ConnectionString
    {
        private static string cs = "Server=;Database=CRUD_ADO;Trusted_Connection=True;TrustServerCertificate=True;";
        public static string dbcs { get => cs; }
    }
}
