using Sales108.Web.Data.Entities;

namespace Sales108.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;


        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                AddProduct("IPhone XII");
                AddProduct("Camisola SCP");
                AddProduct("IWatch SE");
                AddProduct("IPad Pro");

                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),

            });
        }
    }
}
