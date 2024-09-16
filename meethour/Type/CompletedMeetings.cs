public class CompletedMeetings
{
    public int? Limit { get; set; }
    public int? Page { get; set; }
    public int? ShowAll { get; set; }

    public CompletedMeetings(
        int? limit = null, 
        int? page = null, 
        int? showall = null)
    {
        Limit = limit;
        Page = page;
        ShowAll = showall;
    }
    public object Prepare()
    {
        return new
        {
            limit = Limit,
            page = Page,
            show_all = ShowAll
        };
    }
}
