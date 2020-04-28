using System.Collections.Generic;

namespace dapper_tutorial.Repository
{
    public interface ICoffeeRepository
    {
        IEnumerable<CoffeeDBO> SelectAllCoffees();
        void InsertOneCoffee(CoffeeDBO model);
    }
}
