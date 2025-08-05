namespace Management.Partners.Infrastructure.Configurations;

public class DbConnectionConfiguration
{
    public const string SectionName = nameof(DbConnectionConfiguration);

    public string Server { get; set; }

    public int Port { get; set; }

    public string Database { get; set; }

    public string User { get; set; }

    public string Password { get; set; }

    public string ConnectionString => $"server={Server},{Port};Database={Database};Integrated Security=False;MultipleActiveResultSets=true;User Id={User};Password={Password};";
}
