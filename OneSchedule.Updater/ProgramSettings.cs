namespace OneSchedule.Updater
{
    public class ProgramSettings
    {
        public string ApiKey { get; set; }

        public string Uri { get; set; }

        public ProgramSettings(string apiKey, string uri)
        {
            ApiKey = apiKey;
            Uri = uri;
        }
    }
}
