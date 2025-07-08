namespace FawryRiseUpTask2
{
    public class PaperBook : Book
    {
        public int Stock { get; set; }

        public override string DisplayDetails()
        {
            return $"Paper Book - Title: {title}, ISBN: {ISBN}, Year: {PublishYear}, Price: {Price:C}, Stock: {Stock}";
        }

        public override bool CanBeSold() {
            return true;
        }

        public override void ProcessPurchase(int quantity, string email, string address)
        {
            base.ProcessPurchase(quantity, email, address); 

            if (Stock < quantity)
            {
                Console.WriteLine($"Error: Insufficient stock for '{title}'. Available: {Stock}, Requested: {quantity}");
            }
            else
            {
                Stock -= quantity;
                Console.WriteLine($"Sending paper book '{title}' to {address}");
                ShippingService.Send(address, $"{title} (ISBN: {ISBN})");

            }
        }

    }
}
