public class GenerateJwt
    {
        public string MeetingId { get; set; }
        public int? ContactId { get; set; }
        public object? UiConfig { get; set; }
        public object? Config { get; set; }
    
    public GenerateJwt (string meetingId, int? contactId = null, object? uiConfig = null, object? config = null)
        {
            MeetingId = meetingId;
            ContactId = contactId;
            UiConfig = uiConfig;
            Config = config;
        }
    public object Prepare()
    {
        return new
        {
            meeting_id = MeetingId,
            contact_id = ContactId,
            ui_config = UiConfig,
            config = Config
        };
    }


}