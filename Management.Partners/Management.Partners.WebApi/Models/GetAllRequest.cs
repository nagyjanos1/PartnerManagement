namespace Management.Partners.WebApi.Models;

public interface IPaginator
{
    int Skip { get; set; }
    int Take { get; set; }
}

public interface IOrdered
{
    string OrderBy {  get; set; }
    bool IsDescending { get; set; }
}

public record GetAllRequest : IPaginator, IOrdered
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 15;

    public string OrderBy { get; set; }
    public bool IsDescending { get; set; } = false;
}
