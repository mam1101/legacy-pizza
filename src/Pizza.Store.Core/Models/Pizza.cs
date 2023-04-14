using Pizza.Store.Core.Interfaces;

namespace Pizza.Store.Core.Models;

public class Pizza : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}