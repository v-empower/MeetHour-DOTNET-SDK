public class ContactResponse
{
    public bool success { get; set; }
    public int code { get; set; }
    public string message { get; set; }
    public int total_pages { get; set; }
    public int total_records { get; set; }
    public object contacts { get; set; }
} 