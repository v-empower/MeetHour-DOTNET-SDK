public class EditContact
{
    public string ContactId { get; set; }
    public string CountryCode { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsShowPortal { get; set; }
    public string Phone { get; set; }
    public string? Image { get; set; }

    public EditContact(string contact_id, string country_code, string email, 
        string firstname, string lastname, bool isshowportal, string phone, string? image = null)
    {
        ContactId = contact_id;
        CountryCode = country_code;
        Email = email;
        FirstName = firstname;
        LastName = lastname;
        IsShowPortal = isshowportal;
        Phone = phone;
        Image = image;
    }
    public object Prepare()
    {
        return new
        {
            contact_id = ContactId,
            country_code = CountryCode,
            email = Email,
            firstname = FirstName,
            lastname = LastName,
            isshowportal = IsShowPortal,
            phone = Phone,
            image = Image
        };
    }
}
