namespace Management.Partners.Infrastructure.Configurations
{
    internal record DbConnectionConfiguration
    {
        public string Server { get; init; } = string.Empty;

        public string Port { get; init; } = string.Empty;

        public string Database { get; init; } = string.Empty;

        public string User { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;

        public string ConnectionString => $"server={Server},{Port};Database={Database};Integrated Security=False;MultipleActiveResultSets=true;User Id={User};Password={Password};";
    }
}
