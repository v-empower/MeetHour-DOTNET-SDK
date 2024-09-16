public class ArchiveMeetings
{
    public int? Id { get; set; }

    public ArchiveMeetings(
        int? id1 = null)
    {
        Id = id1;
    }
    public object Prepare()
    {
        return new
        {
            id = Id
        };
    }

}
