public class RefreshToken
{
    public string GrantType { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Refreshtoken { get; set; }

    public RefreshToken(
        string granttype,
        string clientid,
        string clientsecret,
        string refreshtoken)
    {
        GrantType = granttype;
        ClientId = clientid;
        ClientSecret = clientsecret;
        Refreshtoken = refreshtoken;
    }
    public object Prepare()
    {
        return new
        {
            grant_type = GrantType,
            client_id = ClientId,
            client_secret = ClientSecret,
            refresh_token = Refreshtoken
        };
    }

}
