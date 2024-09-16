public class TimeZone
{
	public bool? Success { get; set; }
	public string? Message { get; set; }
	public object? TimeZoneName { get; set; }

	public TimeZone(bool? success1 = null, string? message1 = null, object? timeZoneName1 = null)
	{
		Success = success1;
		Message = message1;
		TimeZoneName = timeZoneName1;
	}
    public object Prepare()
    {
        return new
        {
            success = Success,
            message = Message,
            timezones = TimeZoneName
        };
    }
}
