public class RecordingsList
{
    public string FilterBy { get; set; }
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public string? MeetingId { get; set; }

    public RecordingsList(
        string filterby,
        int? limit1 = null,
        int? page1 = null,
        string? meetingid = null)
    {
        FilterBy = filterby;
        Limit = limit1;
        Page = page1;
        MeetingId = meetingid;
    }
    public object Prepare()
    {
        return new
        {
            filter_by = FilterBy,
            limit = Limit,
            page = Page,
            meeting_id = MeetingId
        };
    }



}
