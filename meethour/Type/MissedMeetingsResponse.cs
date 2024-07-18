public class MissedMeetingsResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public int total_pages { get; set; }
    public int total_records { get; set; }
    public object meetings { get; set; }
} 