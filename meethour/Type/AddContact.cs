public class AddContact
    {   
        public string firstname { get; set; }
        public string email { get; set; }
        public string? lastname { get; set; }
        public string? phone { get; set; }
        public string? country_code { get; set; }
        public string? image { get; set; }
        public bool? is_show_portal { get; set; }
        public string? AddContactResponse { get; set; }

    public AddContact(string firstname1, string email1, string? lastname1 = null, string? phone1 = null, string? country_code1 = null, string? image1 = null, bool? is_show_portal1 = null)
        {
            firstname = firstname1;
            lastname = lastname1;
            email = email1;
            phone = phone1;
            country_code = country_code1;
            image = image1;
            is_show_portal = is_show_portal1;
        }
        public object Prepare()
        {
       
        return new
            {
                firstname = firstname,
                email = email,
                lastname = lastname,
                phone = phone,
                country_code = country_code,
                image = image,
                is_show_portal = is_show_portal
            };
        }
    }
    