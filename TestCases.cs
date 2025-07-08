namespace FawryRiseUpTask2
{
    public class TestCases
    {
            public static void Main(string[] args)
            {
            QuantumBookStore bookstore = new QuantumBookStore();

            Console.WriteLine("\n--- Test 1: Adding Books ---");
            PaperBook paperBook1 = new PaperBook
            {
                ISBN = "978-0134685991",
                title = "Clean Code",
                PublishYear = 2008,
                Price = 45.50m,
                Stock = 5
            };
            bookstore.AddBook(paperBook1);

            EBook eBook1 = new EBook
            {
                ISBN = "978-1491957668",
                title = "Designing Data-Intensive Applications",
                PublishYear = 2017,
                Price = 30.00m,
                FileType = "PDF"
            };
            bookstore.AddBook(eBook1);

            ShowCaseBook demoBook1 = new ShowCaseBook
            {
                ISBN = "DEMO-001",
                title = "Quantum Physics for Dummies",
                PublishYear = 2023,
                Price = 0.00m
            };
            bookstore.AddBook(demoBook1);

            PaperBook paperBook2 = new PaperBook
            {
                ISBN = "978-0321765723",
                title = "The Pragmatic Programmer",
                PublishYear = 1999,
                Price = 38.00m,
                Stock = 2
            };
            bookstore.AddBook(paperBook2);

            EBook eBook2 = new EBook
            {
                ISBN = "978-1617290653",
                title = "Cracking the Coding Interview",
                PublishYear = 2015,
                Price = 25.00m,
                FileType = "EPUB"
            };
            bookstore.AddBook(eBook2);

            bookstore.DisplayInventory();

            Console.WriteLine("\n--- Test 2: Removing Books ---");
            Console.WriteLine("\nAttempting to remove 'Clean Code' by ISBN:");
            bookstore.RemoveBookByISBN("978-0134685991");
            bookstore.DisplayInventory();

            Console.WriteLine("\nAttempting to remove a non-existent book:");
            bookstore.RemoveBookByISBN("NON-EXISTENT-ISBN");
            bookstore.DisplayInventory();

            Console.WriteLine("\n--- Test 3: Buying Books (Success Cases) ---");
            try
            {
                Console.WriteLine("\nAttempting to buy 1 'The Pragmatic Programmer' paper book:");
                decimal paid1 = bookstore.BuyBook("978-0321765723", 1, "customer@example.com", "123 Main St, Anytown");
                Console.WriteLine($"Transaction successful. Paid: {paid1:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during purchase: {ex.Message}");
            }
            bookstore.DisplayInventory();

            try
            {
                Console.WriteLine("\nAttempting to buy 'Cracking the Coding Interview' eBook:");
                decimal paid2 = bookstore.BuyBook("978-1617290653", 1, "e-reader@example.com", "");
                Console.WriteLine($"Transaction successful. Paid: {paid2:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during purchase: {ex.Message}");
            }
            bookstore.DisplayInventory();


            Console.WriteLine("\n--- Test 4: Buying Books (Error Cases) ---");

            // Case 1: Book not found
            try
            {
                Console.WriteLine("\nAttempting to buy a non-existent book:");
                bookstore.BuyBook("NON-EXISTENT", 1, "test@example.com", "Nowhere");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            // Case 2: Insufficient stock for PaperBook
            try
            {
                Console.WriteLine("\nAttempting to buy too many 'The Pragmatic Programmer' paper books (should fail):");
                bookstore.BuyBook("978-0321765723", 5, "customer@example.com", "123 Main St"); 
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            bookstore.DisplayInventory();

            // Case 3: Buying a Showcase Book
            try
            {
                Console.WriteLine("\nAttempting to buy a 'Showcase Book' (should fail):");
                bookstore.BuyBook("DEMO-001", 1, "no-email@example.com", "No Address");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            // Case 4: Buying with negative quantity
            try
            {
                Console.WriteLine("\nBuying Book with ISNB of 978-1617290653");
                bookstore.BuyBook("978-1617290653", -1, "customer@example.com", "123 Main St");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            bookstore.DisplayInventory();

            Console.WriteLine("\n--- Thank you for your time ---");
        }
        }
    } 

