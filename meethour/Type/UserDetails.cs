public class UserDetails
{
    public bool? Success { get; set; }
    public int? Code { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }

    public UserDetails(
        bool? Success1 = null,
        int? Code1 = null,
        string? Message1 = null,
        object? Data1 = null)
    {
        Success = Success1;
        Code = Code1;
        Message = Message1;
        Data = Data1;
    }
    public object Prepare()
    {
        return new
        {
            success = Success,
            code = Code,
            message = Message,
            data = Data
        };
    }

}
