namespace FawryRiseUpTask2
{
    public class ShippingService
    {
        public static void Send(string address, string itemDetails)
        {
            Console.WriteLine($"Preparing to ship {itemDetails} to address: {address}");
            Console.WriteLine($"{itemDetails} has been released to {address}");
        }
    }
}
