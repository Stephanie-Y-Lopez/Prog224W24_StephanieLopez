namespace Prog224W24_StephanieLopez
{
    internal class Program
    {
        //Stephanie Lopez
        // 3/19/24

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            // Load inventory data from JSON file!
            inventory.LoadFromJson("inventory.json");

            //Display for menu options
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the affordable starbucks dupe app! :D");
                Console.WriteLine("1. Display Products");
                Console.WriteLine("2. Add Product");
                Console.WriteLine("3. Ring Up Customer");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice please: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts(inventory);
                        break;
                    case "2":
                        AddProduct(inventory);
                        break;
                    case "3":
                        RingUpCustomer(inventory);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option. Thank you!");
                        break;
                }
            }
            // Saves inventory data the JSON file before exiting.
            inventory.SaveToJson("inventory.json");
        }

        static void DisplayProducts(Inventory inventory)
        {
            Console.WriteLine("Available Products:");
            foreach (var product in inventory.Products)
            {
                Console.WriteLine(product);
            }
        }

        static void AddProduct(Inventory inventory)
        {
            Console.WriteLine("Adding a product");
            Console.Write("Enter product name please: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Select product type please:");
            Console.WriteLine("1. Beverage");
            Console.WriteLine("2. Food");
            Console.WriteLine("3. Merchandise");
            Console.Write("Enter your choice please: ");
            int choice = int.Parse(Console.ReadLine());

            Product product;
            switch (choice)
            {
                case 1:
                    Console.Write("Enter beverage size please: ");
                    string size = Console.ReadLine();
                    product = new Beverage { name_ = name, price_ = price, size_ = size };
                    break;
                case 2:
                    Console.Write("Enter expiration date (yyyy-mm-dd): ");
                    DateTime expirationDate = DateTime.Parse(Console.ReadLine());
                    product = new Food { name_ = name, price_ = price, ExpirationDate = expirationDate };
                    break;
                case 3:
                    Console.Write("Enter category: ");
                    string category = Console.ReadLine();
                    product = new Merchandise { name_ = name, price_ = price, category_ = category };
                    break;
                default:
                    Console.WriteLine("Invalid choice :c .");
                    return;
            }

            inventory.AddProduct(product);
            Console.WriteLine("Product added successfully! :D");
        }

        static void RingUpCustomer(Inventory inventory)
        {
            Order order = new Order();

            Console.WriteLine("Creating an order");
            bool addMore = true;
            do
            {
                DisplayProducts(inventory);
                Console.Write("Enter product number: ");
                int productNumber = int.Parse(Console.ReadLine());

                if (productNumber < 1 || productNumber > inventory.Products.Count)
                {
                    Console.WriteLine("Invalid product number.");
                    continue;
                }

                Product selectedProduct = inventory.Products[productNumber - 1];
                order.AddProduct(selectedProduct);
                Console.WriteLine("Product added to the order.");

                Console.Write("Do you want to add more products to the order? (yes/no): ");
                string addMoreInput = Console.ReadLine().ToLower();
                addMore = addMoreInput == "yes";
            } while (addMore);

            double totalPrice = order.CalculateTotalPrice();
            Console.WriteLine($"Total price of the order: ${totalPrice}");

            Receipt receipt = new Receipt { order_ = order, totalprice_ = totalPrice };
            Console.WriteLine("Receipt:");
            Console.WriteLine(receipt);
        }
    }
}
