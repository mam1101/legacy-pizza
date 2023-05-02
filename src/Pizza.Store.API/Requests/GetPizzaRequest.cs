namespace Pizza.Store.API.Requests;

public class GetPizzaRequest
{
    public GetPizzaRequest(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}