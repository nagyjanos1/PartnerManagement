namespace Management.Partners.Application.Queries
{
    public record IdQuery
    {
        public string Id { get; init; }

        internal Guid GetId()
        {
            return Guid.TryParse(Id, out var id) ? id : Guid.Empty;
        }
    }
}
