namespace akabutbetter.Models
{
    public class ShortlinkRequest
    {
        public string PrettyName { get; set; }
        public string DestinationUri { get; set; }
        public string[] Owners { get; set; }

        public override string ToString()
        {
            return "{ "
                   + $"PrettyName: {PrettyName}, DestinationUri: {DestinationUri}"
                 //  + $", Owners: [{string.Join(",", Owners)}]"
                   + " }";
        }
    }
}