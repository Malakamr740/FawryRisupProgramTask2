namespace FawryRiseUpTask2
{
    public class MailService
    {
        public static void Send(string email, string itemDetails)
        {
            Console.WriteLine($"Preparing to send {itemDetails} to email: {email}");
            Console.WriteLine($"{itemDetails} has been sent to {email}");
        }
    }
}
