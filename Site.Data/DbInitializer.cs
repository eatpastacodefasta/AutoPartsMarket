using Site.Data.Models;

namespace Site.Data;

public class DbInitializer
{
    public static void Initialize(ApplicationContext context)
    {
        context.Database.EnsureCreated();

        if (context.Stores.Any())
        {
            return;
        }

        var stores = new Store[]
        {
            new Store{ Id=7028, Name="C-West Tokyo",Address="1 Chome-13-17 Kamezawa, Sumida City, Tokyo 130-0014, Japan"},
            new Store{ Id=8374, Name="Top Secret",Address="3 Chome-6-11 Nishiazabu, Minato City, Tokyo 106-0031, Japan"},
            new Store{ Id=2946, Name="TRUST / GReddy Performance",Address="9 Chome-5-11 Higashi Gotanda, Shinagawa City, Tokyo 141-0022, Japan"},
            new Store{ Id=5063, Name="HKS Tokyo",Address="4 Chome-2-9 Fujimi, Chiyoda City, Tokyo 102-0071, Japan"},
            new Store{ Id=6198, Name="Garage G-Force",Address="1 Chome-25-8 Higashishinkoiwa, Katsushika City, Tokyo 124-0023, Japan"},
            new Store{ Id=2457, Name="Sun Line Racing Tokyo",Address="1 Chome-5-17 Okubo, Shinjuku City, Tokyo 169-0072, Japan"},
            new Store{ Id=3701, Name="Garage Defend",Address="1 Chome-8-10 Nishikamata, Ota City, Tokyo 144-0051, Japan"},
            new Store{ Id=8546, Name="Phoenix's Power Tokyo",Address="3 Chome-7-2 Sakae, Tachikawa, Tokyo 190-0022, Japan"},
            new Store{ Id=9260, Name="Pro Shop Diversion Tokyo",Address="4 Chome-28-7 Nishikoiwa, Edogawa City, Tokyo 133-0057, Japan"},
            new Store{ Id=4310, Name="Tomei Powered Tokyo",Address="1 Chome-25-1 Higashi Nippori, Arakawa City, Tokyo 116-0014, Japan"}
        };

        foreach (Store s in stores)
        {
            context.Stores.Add(s);
        }

        var products = new Product[]
        {
            new Product{Id=3728,Name="HKS Super Hybrid Air Filter", Category="Air Filter", Make="HKS", Price=70.00m},
            new Product{Id=9193,Name="Fujitsubo Exhaust System", Category="Exhaust System", Make="Fujitsubo", Price=900.00m},
            new Product{Id=5467,Name="Tein Coilovers", Category="Suspension", Make="Tein", Price=1200.00m},
            new Product{Id=2085,Name="Greddy Blow Off Valve", Category="Blow Off Valve", Make="Greddy", Price=250.00m},
            new Product{Id=6319,Name="AEM Cold Air Intake", Category="Air Intake", Make="AEM", Price=300.00m},
            new Product{Id=7542,Name="Tomei Expreme Exhaust Manifold", Category="Exhaust Manifold", Make="Tomei", Price=800.00m},
            new Product{Id=4281,Name="Blitz Turbo Timer", Category="Electronics", Make="Blitz", Price=100.00m},
            new Product{Id=1650,Name="HKS Racing Suction Reloaded", Category="Air Intake", Make="HKS", Price=250.00m},
            new Product{Id=8024,Name="Apexi Power FC", Category="Engine Management", Make="Apexi", Price=700.00m},
            new Product{Id=3796,Name="Cusco Front Strut Bar", Category="Chassis Bracing", Make="Cusco", Price=150.00m},
            new Product{Id=5830,Name="Tanabe Sustec Front Sway Bar", Category="Suspension", Make="Tanabe", Price=200.00m},
            new Product{Id=2674,Name="Spoon Sports Shift Knob", Category="Interior", Make="Spoon", Price=50.00m},
            new Product{Id=9147,Name="Trust/Greddy Intercooler Kit", Category="Intercooler", Make="Trust/Greddy", Price=800.00m},
            new Product{Id=7358,Name="HKS Super Sequential Blow Off Valve", Category="Blow Off Valve", Make="HKS", Price=300.00m},
            new Product{Id=6129,Name="AEM Wideband O2 Sensor", Category="Electronics", Make="AEM", Price=150.00m},
            new Product{Id=4906,Name="Tomei Titanium Exhaust", Category="Exhaust System", Make="Tomei", Price=1500.00m},
            new Product{Id=3487,Name="Apexi N1 Evolution Coilovers", Category="Suspension", Make="Apexi", Price=1500.00m},
            new Product{Id=8012,Name="Cusco Roll Cage", Category="Chassis Bracing", Make="Cusco", Price=800.00m},
            new Product{Id=5493,Name="Blitz Turbo Kit", Category="Turbo Kit", Make="Blitz", Price=3000.00m},
            new Product{Id=1729,Name="HKS GT Supercharger Kit", Category="Supercharger Kit", Make="HKS", Price=4000.00m},
            new Product{Id=6952,Name="Trust/Greddy Oil Cooler Kit", Category="Oil Cooler", Make="Trust/Greddy", Price=500.00m},
            new Product{Id=8304,Name="Fujitsubo Legalis R Exhaust", Category="Exhaust System", Make="Fujitsubo", Price=700.00m},
            new Product{Id=2076,Name="Tein EDFC Active Pro", Category="Suspension", Make="Tein", Price=600.00m},
            new Product{Id=4159,Name="Spoon Sports Sports Damper Kit", Category="Suspension", Make="Spoon", Price=1000.00m},
            new Product{Id=9831,Name="HKS F-Con V Pro", Category="Engine Management", Make="HKS", Price=1500.00m},
            new Product{Id=6384,Name="Blitz Dual SBC Boost Controller", Category="Electronics", Make="Blitz", Price=300.00m},
            new Product{Id=4012,Name="Cusco Front Lower Arm Bar", Category="Chassis Bracing", Make="Cusco", Price=100.00m},
            new Product{Id=5706,Name="Tomei Turbo Outlet Pipe", Category="Turbo Accessories", Make="Tomei", Price=200.00m},
            new Product{Id=1267,Name="Apexi Power Intake", Category="Air Intake", Make="Apexi", Price=200.00m},
            new Product{Id=7490,Name="Greddy Oil Catch Can", Category="Engine Accessories", Make="Greddy", Price=150.00m}
        };

        foreach (Product s in products)
        {
            context.Products.Add(s);
        }

        var suppliers = new Supplier[]
        {
            new Supplier{ Id = 3287, Company = "Nagoya Auto Parts", FirstName="Satoshi", LastName="Suzuki", Address="1 Chome-1-2 Nihonbashi, Chuo City, Tokyo 103-0027, Japan", Telephone="+81 3-1234-5678" },
            new Supplier{ Id = 5610, Company = "Tokyo Auto Style", FirstName="Takashi", LastName="Tanaka", Address="3 Chome-18-8 Higashinakano, Nakano City, Tokyo 164-0003, Japan", Telephone="+81 3-2345-6789" },
            new Supplier{ Id = 8942, Company = "Speedworks Tokyo", FirstName="Masaru", LastName="Yamamoto", Address="2 Chome-12-10 Kitazawa, Setagaya City, Tokyo 155-0031, Japan", Telephone="+81 3-3456-7890" },
            new Supplier{ Id = 6473, Company = "Mugen Tokyo", FirstName="Hiroshi", LastName="Nakamura", Address="2 Chome-2-1 Daiba, Minato City, Tokyo 135-0091, Japan", Telephone="+81 3-4567-8901" },
            new Supplier{ Id = 1794, Company = "HKS Tokyo Outlet", FirstName="Toshiro", LastName="Sato", Address="3 Chome-4-1 Takadanobaba, Shinjuku City, Tokyo 169-0075, Japan", Telephone="+81 3-5678-9012" },
            new Supplier{ Id = 9026, Company = "J's Racing Tokyo", FirstName="Keisuke", LastName="Yamada", Address="1 Chome-9-10 Kotobuki, Taito City, Tokyo 111-0042, Japan", Telephone="+81 3-6789-0123" },
            new Supplier{ Id = 4356, Company = "Toda Racing Tokyo", FirstName="Naoki", LastName="Suzuki", Address="4 Chome-3-8 Ogawa, Katsushika City, Tokyo 124-0012, Japan", Telephone="+81 3-7890-1234" },
            new Supplier{ Id = 7631, Company = "Tom's Racing Tokyo", FirstName="Yukihiro", LastName="Tanaka", Address="2 Chome-4-1 Yoyogi, Shibuya City, Tokyo 151-0053, Japan", Telephone="+81 3-8901-2345" },
            new Supplier{ Id = 5082, Company = "Varis Tokyo", FirstName="Kazuo", LastName="Nakamura", Address="2 Chome-1-5 Kitamukaihara, Itabashi City, Tokyo 175-0091, Japan", Telephone="+81 3-9012-3456" },
            new Supplier{ Id = 2864, Company = "Apexi Tokyo", FirstName="Daisuke", LastName="Suzuki", Address="3 Chome-12-1 Higashikojiya, Suginami City, Tokyo 167-0042, Japan", Telephone="+81 3-0123-4567" },
            new Supplier{ Id = 9413, Company = "Garage Vary Tokyo", FirstName="Masahiro", LastName="Yamaguchi", Address="3 Chome-11-12 Nishikoyama, Shinagawa City, Tokyo 142-0065, Japan", Telephone="+81 3-1234-5678" },
            new Supplier{ Id = 7205, Company = "Cusco Tokyo", FirstName="Takeshi", LastName="Suzuki", Address="1 Chome-12-3 Okubo, Shinjuku City, Tokyo 169-0072, Japan", Telephone="+81 3-2345-6789" },
            new Supplier{ Id = 3849, Company = "Spoon Sports Tokyo", FirstName="Nobuhiro", LastName="Honda", Address="4 Chome-6-9 Totsukacho, Taito City, Tokyo 111-0051, Japan", Telephone="+81 3-3456-7890" },
            new Supplier{ Id = 1597, Company = "ARC Tokyo", FirstName="Yoshihiro", LastName="Tanaka", Address="2 Chome-2-2 Kaminakazato, Kita City, Tokyo 114-0016, Japan", Telephone="+81 3-4567-8901" },
            new Supplier{ Id = 6732, Company = "Tommy Kaira Tokyo", FirstName="Takashi", LastName="Sato", Address="1 Chome-3-7 Tsukiji, Chuo City, Tokyo 104-0045, Japan", Telephone="+81 3-5678-9012" }
        };

        foreach (Supplier s in suppliers)
        {
            context.Suppliers.Add(s);
        }

        var supplierProducts = new SupplierProduct[]
        {
            new SupplierProduct { SupplierId = suppliers[0].Id, ProductId = products[0].Id, SupplierPrice = 60.00m },
            new SupplierProduct { SupplierId = suppliers[0].Id, ProductId = products[1].Id, SupplierPrice = 850.00m },
            new SupplierProduct { SupplierId = suppliers[0].Id, ProductId = products[2].Id, SupplierPrice = 1100.00m },
            new SupplierProduct { SupplierId = suppliers[0].Id, ProductId = products[3].Id, SupplierPrice = 200.00m },
            new SupplierProduct { SupplierId = suppliers[0].Id, ProductId = products[4].Id, SupplierPrice = 300.00m },
            new SupplierProduct { SupplierId = suppliers[1].Id, ProductId = products[5].Id, SupplierPrice = 230.00m },
            new SupplierProduct { SupplierId = suppliers[1].Id, ProductId = products[6].Id, SupplierPrice = 280.00m },
            new SupplierProduct { SupplierId = suppliers[1].Id, ProductId = products[7].Id, SupplierPrice = 150.00m },
            new SupplierProduct { SupplierId = suppliers[1].Id, ProductId = products[8].Id, SupplierPrice = 500.00m },
            new SupplierProduct { SupplierId = suppliers[1].Id, ProductId = products[9].Id, SupplierPrice = 400.00m },
            new SupplierProduct { SupplierId = suppliers[2].Id, ProductId = products[10].Id, SupplierPrice = 90.00m },
            new SupplierProduct { SupplierId = suppliers[2].Id, ProductId = products[11].Id, SupplierPrice = 220.00m },
            new SupplierProduct { SupplierId = suppliers[2].Id, ProductId = products[12].Id, SupplierPrice = 650.00m },
            new SupplierProduct { SupplierId = suppliers[2].Id, ProductId = products[13].Id, SupplierPrice = 300.00m },
            new SupplierProduct { SupplierId = suppliers[2].Id, ProductId = products[14].Id, SupplierPrice = 250.00m },
            new SupplierProduct { SupplierId = suppliers[3].Id, ProductId = products[15].Id, SupplierPrice = 130.00m },
            new SupplierProduct { SupplierId = suppliers[3].Id, ProductId = products[16].Id, SupplierPrice = 180.00m },
            new SupplierProduct { SupplierId = suppliers[3].Id, ProductId = products[17].Id, SupplierPrice = 520.00m },
            new SupplierProduct { SupplierId = suppliers[3].Id, ProductId = products[18].Id, SupplierPrice = 110.00m },
            new SupplierProduct { SupplierId = suppliers[3].Id, ProductId = products[19].Id, SupplierPrice = 600.00m },
            new SupplierProduct { SupplierId = suppliers[4].Id, ProductId = products[20].Id, SupplierPrice = 250.00m },
            new SupplierProduct { SupplierId = suppliers[4].Id, ProductId = products[21].Id, SupplierPrice = 320.00m },
            new SupplierProduct { SupplierId = suppliers[4].Id, ProductId = products[22].Id, SupplierPrice = 700.00m },
            new SupplierProduct { SupplierId = suppliers[4].Id, ProductId = products[23].Id, SupplierPrice = 90.00m },
            new SupplierProduct { SupplierId = suppliers[4].Id, ProductId = products[24].Id, SupplierPrice = 75.00m },
            new SupplierProduct { SupplierId = suppliers[5].Id, ProductId = products[25].Id, SupplierPrice = 170.00m },
            new SupplierProduct { SupplierId = suppliers[5].Id, ProductId = products[26].Id, SupplierPrice = 200.00m },
            new SupplierProduct { SupplierId = suppliers[5].Id, ProductId = products[27].Id, SupplierPrice = 480.00m },
            new SupplierProduct { SupplierId = suppliers[5].Id, ProductId = products[28].Id, SupplierPrice = 60.00m },
            new SupplierProduct { SupplierId = suppliers[5].Id, ProductId = products[29].Id, SupplierPrice = 180.00m },
            new SupplierProduct { SupplierId = suppliers[6].Id, ProductId = products[0].Id, SupplierPrice = 50.00m },
            new SupplierProduct { SupplierId = suppliers[6].Id, ProductId = products[1].Id, SupplierPrice = 95.00m },
            new SupplierProduct { SupplierId = suppliers[6].Id, ProductId = products[2].Id, SupplierPrice = 800.00m },
            new SupplierProduct { SupplierId = suppliers[6].Id, ProductId = products[3].Id, SupplierPrice = 200.00m },
            new SupplierProduct { SupplierId = suppliers[6].Id, ProductId = products[4].Id, SupplierPrice = 350.00m },
            new SupplierProduct { SupplierId = suppliers[7].Id, ProductId = products[5].Id, SupplierPrice = 110.00m },
            new SupplierProduct { SupplierId = suppliers[7].Id, ProductId = products[6].Id, SupplierPrice = 240.00m },
            new SupplierProduct { SupplierId = suppliers[7].Id, ProductId = products[7].Id, SupplierPrice = 520.00m },
            new SupplierProduct { SupplierId = suppliers[7].Id, ProductId = products[8].Id, SupplierPrice = 100.00m },
            new SupplierProduct { SupplierId = suppliers[7].Id, ProductId = products[9].Id, SupplierPrice = 220.00m },
            new SupplierProduct { SupplierId = suppliers[8].Id, ProductId = products[10].Id, SupplierPrice = 75.00m },
            new SupplierProduct { SupplierId = suppliers[8].Id, ProductId = products[11].Id, SupplierPrice = 160.00m },
            new SupplierProduct { SupplierId = suppliers[8].Id, ProductId = products[12].Id, SupplierPrice = 400.00m },
            new SupplierProduct { SupplierId = suppliers[8].Id, ProductId = products[13].Id, SupplierPrice = 80.00m },
            new SupplierProduct { SupplierId = suppliers[8].Id, ProductId = products[14].Id, SupplierPrice = 150.00m },
            new SupplierProduct { SupplierId = suppliers[9].Id, ProductId = products[15].Id, SupplierPrice = 80.00m },
            new SupplierProduct { SupplierId = suppliers[9].Id, ProductId = products[16].Id, SupplierPrice = 190.00m },
            new SupplierProduct { SupplierId = suppliers[9].Id, ProductId = products[17].Id, SupplierPrice = 450.00m },
            new SupplierProduct { SupplierId = suppliers[9].Id, ProductId = products[18].Id, SupplierPrice = 150.00m },
            new SupplierProduct { SupplierId = suppliers[9].Id, ProductId = products[19].Id, SupplierPrice = 300.00m },
            new SupplierProduct { SupplierId = suppliers[10].Id, ProductId = products[20].Id, SupplierPrice = 60.00m },
            new SupplierProduct { SupplierId = suppliers[10].Id, ProductId = products[21].Id, SupplierPrice = 140.00m },
            new SupplierProduct { SupplierId = suppliers[10].Id, ProductId = products[22].Id, SupplierPrice = 320.00m },
            new SupplierProduct { SupplierId = suppliers[10].Id, ProductId = products[23].Id, SupplierPrice = 70.00m },
            new SupplierProduct { SupplierId = suppliers[10].Id, ProductId = products[24].Id, SupplierPrice = 110.00m },
            new SupplierProduct { SupplierId = suppliers[11].Id, ProductId = products[25].Id, SupplierPrice = 70.00m },
            new SupplierProduct { SupplierId = suppliers[11].Id, ProductId = products[26].Id, SupplierPrice = 180.00m },
            new SupplierProduct { SupplierId = suppliers[11].Id, ProductId = products[27].Id, SupplierPrice = 380.00m },
            new SupplierProduct { SupplierId = suppliers[11].Id, ProductId = products[28].Id, SupplierPrice = 90.00m },
            new SupplierProduct { SupplierId = suppliers[11].Id, ProductId = products[29].Id, SupplierPrice = 160.00m },
            new SupplierProduct { SupplierId = suppliers[12].Id, ProductId = products[0].Id, SupplierPrice = 40.00m },
            new SupplierProduct { SupplierId = suppliers[12].Id, ProductId = products[1].Id, SupplierPrice = 75.00m },
            new SupplierProduct { SupplierId = suppliers[12].Id, ProductId = products[2].Id, SupplierPrice = 220.00m },
            new SupplierProduct { SupplierId = suppliers[12].Id, ProductId = products[3].Id, SupplierPrice = 60.00m },
            new SupplierProduct { SupplierId = suppliers[12].Id, ProductId = products[4].Id, SupplierPrice = 100.00m },
            new SupplierProduct { SupplierId = suppliers[13].Id, ProductId = products[5].Id, SupplierPrice = 55.00m },
            new SupplierProduct { SupplierId = suppliers[13].Id, ProductId = products[6].Id, SupplierPrice = 95.00m },
            new SupplierProduct { SupplierId = suppliers[13].Id, ProductId = products[7].Id, SupplierPrice = 180.00m },
            new SupplierProduct { SupplierId = suppliers[13].Id, ProductId = products[8].Id, SupplierPrice = 40.00m },
            new SupplierProduct { SupplierId = suppliers[13].Id, ProductId = products[9].Id, SupplierPrice = 90.00m },
            new SupplierProduct { SupplierId = suppliers[14].Id, ProductId = products[10].Id, SupplierPrice = 45.00m },
            new SupplierProduct { SupplierId = suppliers[14].Id, ProductId = products[11].Id, SupplierPrice = 85.00m },
            new SupplierProduct { SupplierId = suppliers[14].Id, ProductId = products[12].Id, SupplierPrice = 200.00m },
            new SupplierProduct { SupplierId = suppliers[14].Id, ProductId = products[13].Id, SupplierPrice = 50.00m },
            new SupplierProduct { SupplierId = suppliers[14].Id, ProductId = products[14].Id, SupplierPrice = 110.00m }
        };

        foreach (SupplierProduct s in supplierProducts)
        {
            context.SupplierProducts.Add(s);
        }

        var storeProducts = new StoreProduct[]
        {
            new StoreProduct { StoreId = 7028, ProductId = 3728, AvailableStock = 20, MinimumStock = 10, SalesCount = 5 },
            new StoreProduct { StoreId = 7028, ProductId = 9193, AvailableStock = 15, MinimumStock = 8, SalesCount = 3 },
            new StoreProduct { StoreId = 7028, ProductId = 5467, AvailableStock = 10, MinimumStock = 5, SalesCount = 2 },
            new StoreProduct { StoreId = 8374, ProductId = 2085, AvailableStock = 25, MinimumStock = 15, SalesCount = 8 },
            new StoreProduct { StoreId = 8374, ProductId = 6319, AvailableStock = 30, MinimumStock = 20, SalesCount = 10 },
            new StoreProduct { StoreId = 8374, ProductId = 7542, AvailableStock = 18, MinimumStock = 10, SalesCount = 6 },
            new StoreProduct { StoreId = 2946, ProductId = 4281, AvailableStock = 22, MinimumStock = 12, SalesCount = 7 },
            new StoreProduct { StoreId = 2946, ProductId = 1650, AvailableStock = 12, MinimumStock = 8, SalesCount = 4 },
            new StoreProduct { StoreId = 2946, ProductId = 8024, AvailableStock = 8, MinimumStock = 5, SalesCount = 3 },
            new StoreProduct { StoreId = 5063, ProductId = 3796, AvailableStock = 14, MinimumStock = 10, SalesCount = 5 },
            new StoreProduct { StoreId = 5063, ProductId = 5830, AvailableStock = 16, MinimumStock = 12, SalesCount = 6 },
            new StoreProduct { StoreId = 5063, ProductId = 2674, AvailableStock = 10, MinimumStock = 7, SalesCount = 3 },
            new StoreProduct { StoreId = 6198, ProductId = 9147, AvailableStock = 20, MinimumStock = 15, SalesCount = 7 },
            new StoreProduct { StoreId = 6198, ProductId = 7358, AvailableStock = 25, MinimumStock = 18, SalesCount = 9 },
            new StoreProduct { StoreId = 6198, ProductId = 6129, AvailableStock = 18, MinimumStock = 12, SalesCount = 6 },
            new StoreProduct { StoreId = 2457, ProductId = 4906, AvailableStock = 30, MinimumStock = 20, SalesCount = 10 },
            new StoreProduct { StoreId = 2457, ProductId = 3487, AvailableStock = 25, MinimumStock = 18, SalesCount = 8 },
            new StoreProduct { StoreId = 2457, ProductId = 8012, AvailableStock = 20, MinimumStock = 15, SalesCount = 6 },
            new StoreProduct { StoreId = 3701, ProductId = 5493, AvailableStock = 10, MinimumStock = 5, SalesCount = 3 },
            new StoreProduct { StoreId = 3701, ProductId = 1729, AvailableStock = 8, MinimumStock = 4, SalesCount = 2 },
            new StoreProduct { StoreId = 3701, ProductId = 6952, AvailableStock = 5, MinimumStock = 3, SalesCount = 1 },
            new StoreProduct { StoreId = 8546, ProductId = 8304, AvailableStock = 15, MinimumStock = 10, SalesCount = 5 },
            new StoreProduct { StoreId = 8546, ProductId = 2076, AvailableStock = 18, MinimumStock = 12, SalesCount = 6 },
            new StoreProduct { StoreId = 8546, ProductId = 4159, AvailableStock = 12, MinimumStock = 8, SalesCount = 4 },
            new StoreProduct { StoreId = 9260, ProductId = 9831, AvailableStock = 20, MinimumStock = 15, SalesCount = 7 },
            new StoreProduct { StoreId = 9260, ProductId = 6384, AvailableStock = 25, MinimumStock = 18, SalesCount = 9 },
            new StoreProduct { StoreId = 9260, ProductId = 4012, AvailableStock = 18, MinimumStock = 12, SalesCount = 6 },
            new StoreProduct { StoreId = 4310, ProductId = 5706, AvailableStock = 30, MinimumStock = 20, SalesCount = 10 },
            new StoreProduct { StoreId = 4310, ProductId = 1267, AvailableStock = 25, MinimumStock = 18, SalesCount = 8 },
            new StoreProduct { StoreId = 4310, ProductId = 7490, AvailableStock = 20, MinimumStock = 15, SalesCount = 6 }
        };

        foreach (StoreProduct s in storeProducts)
        {
            context.StoreProducts.Add(s);
        }

        context.SaveChanges();
    }
}
