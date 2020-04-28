using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace dapper_tutorial.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private string _connectionString = "Data Source = DESKTOP-JGEHS55; Initial Catalog = CoffeeShop; Integrated Security=True";

        public void InsertOneCoffee(CoffeeDBO model)
        {
            string sql = @"INSERT INTO Coffee (Name, Description, Price)
                           VALUES (@Name , @Description, @Price);";

            using (var connection = new SqlConnection(_connectionString))
            {
                var coffees = connection.Execute(sql, model);
            }
        }

        public void UpdateSelectedCoffee(CoffeeDBO model)
        {
            string sql = @"UPDATE Coffee
                            SET 
	                            Name = @Name, 
	                            Description = @Description, 
	                            Price = @Price
                            WHERE ID = @ID; ";

            using (var connection = new SqlConnection(_connectionString))
            {
                var coffees = connection.Execute(sql, model);
            }
        }

        public void DeleteSelectedCoffee(int id)
        {
            string sql = @"DELETE FROM Coffee 
                            WHERE ID = @ID;";

            using (var connection = new SqlConnection(_connectionString))
            {
                var coffees = connection.Execute(sql, new DeleteCoffe { ID = id });
            }
        }

        public IEnumerable<CoffeeDBO> SelectAllCoffees()
        {
            string sql = "SELECT * FROM Coffee";

            using (var connection = new SqlConnection(_connectionString))
            {
                var coffees = connection.Query<CoffeeDBO>(sql);

                return coffees;
            }
        }
    }

    public class DeleteCoffe 
    {
        public int ID { get; set; }
    }
}
