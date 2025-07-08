namespace FawryRiseUpTask2
{
    public class ShowCaseBook : Book
    {
        public override string DisplayDetails()
        {
            return $"Showcase Book - Title: {title}, ISBN: {ISBN}, Year: {PublishYear}, Not for Sale";
        }
        public override bool CanBeSold() { return false;  }
    }
}
