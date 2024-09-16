public class ViewMeeting
{
    public string MeetingId { get; set; }

    public ViewMeeting(
        string meetingid)
    {
        MeetingId = meetingid;
    }
    public object Prepare()
    {
        return new
        {
            meeting_id = MeetingId
        };
    }
}
