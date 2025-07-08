namespace FawryRiseUpTask2
{
    public class EBook : Book

    {
        public string FileType { get; set; } 

        public override string DisplayDetails()
        {
            return $"EBook - Title: {title}, ISBN: {ISBN}, Year: {PublishYear}, Price: {Price:C}, FileType: {FileType}";
        }

        public override bool CanBeSold()
        {
            return true;
        }

        public override void ProcessPurchase(int quantity, string email, string address)
        {
            Console.WriteLine($"Sending EBook '{title}' to {email}");
            MailService.Send(email, $"{title} (ISBN: {ISBN}, Type: {FileType})");
        }
    }
}
