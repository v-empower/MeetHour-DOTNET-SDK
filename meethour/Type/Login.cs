public class Login
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string access_token { get; set; }

    public Login(string clientId, string clientSecret, string grantType, string username, string password)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            GrantType = grantType;
            Username = username;
            Password = password;
        }
        public object Prepare()
        {
            return new
            {
                client_id = ClientId,
                client_secret = ClientSecret,
                grant_type = GrantType,
                password = Password,
                username = Username
            };
        }
    }