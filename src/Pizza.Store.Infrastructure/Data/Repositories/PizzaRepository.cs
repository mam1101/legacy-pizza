using Pizza.Store.Core.Interfaces;
using Pizza.Store.Migrations;

namespace Pizza.Store.Infrastructure.Data.Repositories;

public class PizzaRepository: IPizzaRepsitory, IDisposable
{
    private readonly PizzaContext _context;

    public PizzaRepository(PizzaContext context)
    {
        _context = context;
    }
    
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}