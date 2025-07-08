namespace FawryRiseUpTask2
{
    public abstract class Book
    {
        public  string ISBN { get; set; }
        public string title { get; set; }
        public int PublishYear { get; set; }
         
        public decimal Price { get; set; }
        
        public abstract string DisplayDetails();
        public abstract bool CanBeSold();
        public virtual void ProcessPurchase(int quantity, string email, string address)
        {
            if (!CanBeSold())
            {
                Console.WriteLine($" Error: Book '{title}' (ISBN: {ISBN}) is not for sale.");
            }
        }
    }
}
