public class ViewMeetingResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public object meeting { get; set; }
    public object occurrences { get; set; }
    public object meeting_attendees { get; set; }
    public object meeting_groups { get; set; }
    public object organizer { get; set; }
} 