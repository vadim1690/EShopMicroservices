using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
            {
                return;
            }

            // Marten UPSERT will creaet
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
                new Product()
                {
                    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = new List<string> { "White Appliances" }
                },
                new Product()
                {
                    Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = new List<string> { "White Appliances" }
                },
                new Product()
                {
                    Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
                    Name = "LG G7 ThinQ",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = new List<string> { "Home Kitchen" }
                },
                new Product()
                {
                    Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
                    Name = "Panasonic Lumix",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = new List<string> { "Camera" }
                },
                new Product
                {
                    Id = new Guid("b7b4d12a-d6f7-4f56-9f9e-8404c9e40a33"),
                    Name = "Sony PlayStation 5",
                    Description = "Experience lightning-fast loading, deeper immersion, and an all-new generation of incredible PlayStation games.",
                    ImageFile = "product-ps5.png",
                    Price = 499.99M,
                    Category = new List<string> { "Gaming Consoles" }
                },
                new Product
                {
                    Id = new Guid("83ac65a3-24f1-4f37-a621-56a2a3eb8372"),
                    Name = "Nintendo Switch",
                    Description = "Enjoy gaming anytime, anywhere with this versatile hybrid console.",
                    ImageFile = "product-switch.png",
                    Price = 299.99M,
                    Category = new List<string> { "Gaming Consoles" }
                },
                new Product
                {
                    Id = new Guid("e08b0f6e-150f-47f0-aa3b-879bca032f7a"),
                    Name = "Dell XPS 13",
                    Description = "Maximize productivity with this ultra-portable laptop featuring a stunning InfinityEdge display.",
                    ImageFile = "product-xps13.png",
                    Price = 1099.99M,
                    Category = new List<string> { "Laptops" }
                },
                new Product
                {
                    Id = new Guid("5fd8d47a-9d0e-4ff9-b27a-79e8baff14bc"),
                    Name = "Amazon Echo Dot (4th Gen)",
                    Description = "Meet the all-new Echo Dot with clock – Our most popular smart speaker with Alexa.",
                    ImageFile = "product-echodot.png",
                    Price = 59.99M,
                    Category = new List<string> { "Smart Home Devices" }
                },
                new Product
                {
                    Id = new Guid("e410a9dc-2f49-48e4-b944-9dc3c8a3c8f4"),
                    Name = "Apple Watch Series 7",
                    Description = "Stay connected, active, and healthy with the latest Apple Watch featuring an Always-On Retina display.",
                    ImageFile = "product-watch.png",
                    Price = 399.00M,
                    Category = new List<string> { "Wearable Technology" }
                },
                new Product
                {
                    Id = new Guid("a9a7a71c-0478-4e99-aa6c-738e4de43d46"),
                    Name = "Canon EOS Rebel T7i",
                    Description = "Capture stunning photos and videos with this versatile DSLR camera.",
                    ImageFile = "product-canon.png",
                    Price = 749.99M,
                    Category = new List<string> { "Camera" }
                },
                new Product
                {
                    Id = new Guid("fc42ec1c-b7e0-4e24-9d33-06327a30db1e"),
                    Name = "Bose SoundLink Revolve+",
                    Description = "Experience deep, loud, and immersive sound with this portable Bluetooth speaker.",
                    ImageFile = "product-bose.png",
                    Price = 299.00M,
                    Category = new List<string> { "Audio" }
                },
                new Product
                {
                    Id = new Guid("c15fcff9-10d6-448b-9871-10e34d00ff31"),
                    Name = "Samsung 55-inch QLED TV",
                    Description = "Immerse yourself in breathtaking 4K picture quality with this QLED Smart TV.",
                    ImageFile = "product-tv.png",
                    Price = 1499.99M,
                    Category = new List<string> { "Televisions" }
                },
                new Product
                {
                    Id = new Guid("d5a3d396-816f-42fb-bf26-60967eeb268e"),
                    Name = "KitchenAid Stand Mixer",
                    Description = "Make baking and cooking a breeze with this iconic stand mixer.",
                    ImageFile = "product-mixer.png",
                    Price = 399.99M,
                    Category = new List<string> { "Kitchen Appliances" }
                },
                new Product
                {
                    Id = new Guid("825e0f45-0468-4386-960f-c92a63b42dc8"),
                    Name = "Fitbit Versa 3",
                    Description = "Achieve your fitness goals with this advanced health and fitness smartwatch.",
                    ImageFile = "product-fitbit.png",
                    Price = 229.95M,
                    Category = new List<string> { "Wearable Technology" }
                }

        };
    }
}
