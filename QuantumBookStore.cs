namespace FawryRiseUpTask2
{
    public class QuantumBookStore
    {
        private Dictionary<string, Book> inventory;
        public QuantumBookStore()
        {
            inventory = new Dictionary<string, Book>();
            Console.WriteLine("Initializing bookstore......");
        }

        public void AddBook(Book book)
        {
            if (inventory.ContainsKey(book.ISBN))
            {
                Console.WriteLine($"!ALERT! Book with ISBN '{book.ISBN}' already exists.");
                inventory[book.ISBN] = book; 
            }
            else
            {
                inventory.Add(book.ISBN, book);
            }
            Console.WriteLine($"Added book '{book.title}' (ISBN: {book.ISBN}).");
        }
        public string FindISBNByTitle(string title)
        {
            foreach (var entry in inventory)
            {
                if (entry.Value.title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found ISBN '{entry.Key}' for title '{title}'.");
                    return entry.Key; 
                }
            }
            Console.WriteLine($" No book found with title: '{title}'.");
            return null; 
        }

        public Book RemoveBookByISBN(string isbn)
        {
            if (inventory.TryGetValue(isbn, out Book bookToRemove))
            {
                inventory.Remove(isbn);
                Console.WriteLine($"Quantum book store: Removed book '{bookToRemove.title}' (ISBN: {isbn}) by ISBN.");
                return bookToRemove;
            }
            else
            {
                Console.WriteLine($"Quantum book store: Book with ISBN '{isbn}' not found in inventory. No book removed.");
                return null;
            }
        }

        public decimal BuyBook(string isbn, int quantity, string email, string address)
        {
            if (quantity <= 0)
            {
                Console.WriteLine("Error: Quantity must be positive.");
            }

            if (!inventory.TryGetValue(isbn, out Book book))
            {
                Console.WriteLine($" Error: Book with ISBN '{isbn}' not found in inventory.");
            }

            try
            {
                book.ProcessPurchase(quantity, email, address);
                decimal paidAmount = book.Price * quantity;
                Console.WriteLine($"Successfully purchased {quantity} x '{book.title}'. Total Paid: {paidAmount:C}.");
                return paidAmount;
            }
            catch (InvalidOperationException ex)
            {
                
                throw ex;
            }
            catch (Exception ex)
            {
               
                throw new InvalidOperationException($"error occurred during purchase of '{book.title}': {ex.Message}");
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("--- Current Inventory ---");
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }
            foreach (var book in inventory.Values)
            {
                Console.WriteLine(book.DisplayDetails());
            }
            Console.WriteLine("-----------------------");
        }
    }
}
