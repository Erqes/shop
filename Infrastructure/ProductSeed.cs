using Application;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure;

public class ProductSeed : IProductSeed
{
    private readonly ShopDbContext _dbContext;

    public ProductSeed(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Products.Any())
            {
                var products = GetProducts();
                _dbContext.Products.AddRange(products);
                _dbContext.SaveChanges();
            }

            
        }
    }
    
    private IEnumerable<Product> GetProducts()
    {
        var products = new List<Product>()
        {
            new Product()
            {
                ProductName = "S21",
                Brand = Brand.Samsung,
                ProductType = ProductType.Smartphones,
                Processor = "Qualcomm",
                Camera = "14",
                DiagonalScreenSize = "6.1",
                Color = "Silver",
                Display = "LCD",
                Quantity = 5,
                Price = 4000
            },
            new Product()
            {
                ProductName = "S20",
                Brand = Brand.Samsung,
                ProductType = ProductType.Smartphones,
                Processor = "Qualcomm",
                Camera = "50",
                DiagonalScreenSize = "6.4",
                Color = "Silver",
                Display = "LCD",
                Quantity = 10,
                Price = 1999
            },
            new Product()
            {
                ProductName = "S20",
                Brand = Brand.Samsung,
                ProductType = ProductType.Smartphones,
                Processor = "Qualcomm",
                Camera = "50",
                DiagonalScreenSize = "6.4",
                Color = "Gold",
                Display = "LCD",
                Quantity = 4,
                Price = 2399
            },
            new Product()
            {
                ProductName = "Iphone 15",
                Brand = Brand.Apple,
                ProductType = ProductType.Smartphones,
                Processor = "Apple A15 Bionic",
                Camera = "50",
                DiagonalScreenSize = "6.1",
                Color = "Silver",
                Display = "OLED",
                Quantity = 3,
                Price = 3110
            },
            new Product()
            {
                ProductName = "Iphone 15",
                Brand = Brand.Apple,
                ProductType = ProductType.Smartphones,
                Processor = "Apple A15 Bionic",
                Camera = "50",
                DiagonalScreenSize = "6.1",
                Color = "Brown",
                Display = "OLED",
                Quantity = 3,
                Price = 3199
            },
            new Product()
            {
                ProductName = "Game X 1",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA RTX 3080",
                PowerSupply = "Corsair 750W",
                Processor = "Intel Core i9",
                Price = 2500,
                Quantity = 3
            },
            new Product()
            {
                ProductName = "Game X 2",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "AMD Radeon RX 6700 XT",
                PowerSupply = "EVGA 650W",
                Processor = "AMD Ryzen 7",
                Price = 2200,
                Quantity = 5
            },
            new Product()
            {
                ProductName = "Game X 3",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA GTX 1660",
                PowerSupply = "Cooler Master 550W",
                Processor = "Intel Core i7",
                Price = 1800,
                Quantity = 2
            },
            new Product()
            {
                ProductName = "Game X 4",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "AMD Radeon RX 580",
                PowerSupply = "Seasonic 600W",
                Processor = "AMD Ryzen 5",
                Price = 1600,
                Quantity = 4
            },
            new Product()
            {
                ProductName = "Game X 5",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA RTX 3060",
                PowerSupply = "Thermaltake 700W",
                Processor = "Intel Core i5",
                Price = 2000,
                Quantity = 3
            },
            new Product()
            {
                ProductName = "Game X 6",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "AMD Radeon RX 5700",
                PowerSupply = "EVGA 650W",
                Processor = "AMD Ryzen 9",
                Price = 2400,
                Quantity = 1
            },
            new Product()
            {
                ProductName = "Game X 7",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA RTX 3070",
                PowerSupply = "Corsair 800W",
                Processor = "Intel Core i9",
                Price = 2700,
                Quantity = 6
            },
            new Product()
            {
                ProductName = "Game X 8",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "AMD Radeon RX 6900 XT",
                PowerSupply = "Seasonic 850W",
                Processor = "AMD Ryzen 7",
                Price = 2900,
                Quantity = 4
            },
            new Product()
            {
                ProductName = "Game X 9",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA GTX 1650",
                PowerSupply = "Cooler Master 500W",
                Processor = "Intel Core i5",
                Price = 1500,
                Quantity = 8
            },
            new Product()
            {
                ProductName = "Game X 10",
                Brand = Brand.Shop,
                ProductType = ProductType.Computers,
                Gpu = "NVIDIA RTX 3090",
                PowerSupply = "Thermaltake 900W",
                Processor = "Intel Core i9",
                Price = 3500,
                Quantity = 2
            }



        };
        return products;
    }

}