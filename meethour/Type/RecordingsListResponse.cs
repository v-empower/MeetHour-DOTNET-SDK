public class RecordingsListResponse
{
    public bool success { get; set; }
    public int code { get; set; }
    public string message { get; set; }
    public object dropbox_recordings { get; set; }
    public object meethour_recordings { get; set; }
    public object custom_recordings { get; set; }
    public int total_pages { get; set; }
    public int total_records { get; set; }
}