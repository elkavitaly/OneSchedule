namespace OneScheduleEntities
{
    public class Chat
    {
        public int Id { get; set; }
        public bool IsBot { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string LanguageCode { get; set; }
        public bool CanJoinGroups { get; set; }
        public bool CanReadAllGroupMessages { get; set; }
        public bool SupportsInlineQueries { get; set; }
        
    }
}
