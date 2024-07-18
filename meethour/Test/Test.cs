using System;
using System.Threading.Tasks;
using static Login;
using static Contact; 
using static AddContact;
using static EditContact;
using static ScheduleMeeting;
using static CompletedMeetings;
using static EditMeeting;
using static GenerateJwt;
using static MissedMeetings;
using static ArchiveMeetings;
using static UpcomingMeetings;
using static ViewMeeting;
using static RecordingsList;
using static RefreshToken;
using static TimeZone;
using static UserDetails;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        
        // Create a LoginType object with your developer details
        var loginObject = new Login("CLIENT_ID", "CLIENT_SECRET", "password", "EMAIL", "EMAIL_PASWORD");
        // Create an instance of the MHApiService
        var apiService = new MHApiService();
        var response = await apiService.Login<Login>(loginObject);
        var token = response.access_token;
        Console.WriteLine($"access_token: {token}");
        Console.ReadKey();
        
        // Create an AddContactType object with the contact details you want to add
        var addContactObject = new AddContact("FIRST_NAME", "EMAIL", "LAST_NAME", "PHONE", "COUNTRY_CODE",  null, true);
        var addContactresponse = await apiService.AddContact<AddContacResponse>(token, addContactObject);
        if (addContactresponse.success == "true")
            Console.WriteLine($"AddContact Success Response value: data: {addContactresponse.data}");
        else
            Console.WriteLine($"AddContact Error Response Code:{addContactresponse.code} and Message: {addContactresponse.message}");
        Console.ReadKey();
        
        // Create ContactsType object
        var contactsObject = new Contact(0, 0, 0);
        Console.WriteLine($"addContactObject data : {contactsObject.Prepare()}");
        var contactsResponse = await apiService.Contact<ContactResponse>(token, contactsObject);
        if (contactsResponse.success == true)
            Console.WriteLine($"List of Contact Success Response value: total_pages: {contactsResponse.total_pages} and total_records: {contactsResponse.total_records} and contacts: {contactsResponse.contacts}");
        else
            Console.WriteLine($"List of Contact Error Response Code:{contactsResponse.code} and Message: {contactsResponse.message}");
        Console.ReadKey();
        
        // Create EditContactType object
        var editContactObject = new EditContact("ID", "COUNTRY_CODE", "EMAIL", "krishnaveni", "NAME", true, "PHONE", null);
        var editContactResponse = await apiService.EditContact<EditContactResponse>(token, editContactObject);
        if (editContactResponse.success == true)
            Console.WriteLine($"Edit Contact Success Response value: data: {editContactResponse.data}");
        else
            Console.WriteLine($"Edit Contact Error Response Code:{editContactResponse.code} and Message: {editContactResponse.message}");
        Console.ReadKey();
        
        // Create GenerateJwtType object
        var generateJwtObject = new GenerateJwt("MEETING_ID"); 
        var generateJwtResponse = await apiService.GenerateJwt<GenerateJwtResponse>(token, generateJwtObject);
        if (generateJwtResponse.success == true)
            Console.WriteLine($"Generate Jwt Success Response value: Jwt Token: {generateJwtResponse.jwt}");
        else
            Console.WriteLine($"Generate Jwt Error Response Message: Something went worng!");
        Console.ReadKey();
        
        // Create EditMeetingType object
        var editMeetingObject = new EditMeeting("MEETING_ID", "MEEETING_NAME", "DATE","TIME","TIME_MERIDIAN", "PASSWORD", "Local");
        var editMeetingResponse = await apiService.EditMeeting<EditMeetingResponse>(token, editMeetingObject);
        if (editMeetingResponse.success == true)
            Console.WriteLine($"Edit Meeting Success Response value: data: {editMeetingResponse.data}");
        else
            Console.WriteLine($"Edit Meeting Error Response Message: {editMeetingResponse.message}");
        Console.ReadKey();
         
        // Create ScheduleMeetingType object
        var scheduleMeetingObject = new ScheduleMeeting("MEETING_NAME", "PASSWORD", "LOCATION", "DATE", "TIME","TIME_MERIDIAN",1,true, "Local");
        var scheduleMeetingResponse = await apiService.ScheduleMeeting<ScheduleMeetingResponse>(token, scheduleMeetingObject);
        if (scheduleMeetingResponse.success == true)
            Console.WriteLine($"Schedule Meeting Success Response value: data: {scheduleMeetingResponse.data}");
        else
            Console.WriteLine($"Schedule Meeting Error Response Code:{scheduleMeetingResponse.code} and Message: {scheduleMeetingResponse.message}");
        Console.ReadKey();
        
        // Create CompletedMeetingsType object
        var completedMeetingsObject = new CompletedMeetings();
        var completedMeetingsResponse = await apiService.CompletedMeetings<CompletedMeetingsResponse>(token, completedMeetingsObject);
        if (completedMeetingsResponse.success == true)
            Console.WriteLine($"Complete Meetings List Success Response value: total_pages: {completedMeetingsResponse.total_pages} and total_records: {completedMeetingsResponse.total_records} and Meetings: {completedMeetingsResponse.meetings}");
        else
            Console.WriteLine($"Complete Meetings List Error Response Message: {completedMeetingsResponse.message}");
        Console.ReadKey();
        
        // Create MissedMeeting object
        var missedMeetingsObject = new MissedMeetings();
        var missedMeetingsResponse = await apiService.MissedMeetings<MissedMeetingsResponse>(token, missedMeetingsObject);
        if (missedMeetingsResponse.success == true)
            Console.WriteLine($"Complete Meetings List Success Response value: total_pages: {missedMeetingsResponse.total_pages} and total_records: {missedMeetingsResponse.total_records} and Meetings: {missedMeetingsResponse.meetings}");
        else
            Console.WriteLine($"Complete Meetings List Error Response Message: {missedMeetingsResponse.message}");
        Console.ReadKey(); 
        
        // Create ArchiveMeeting object
        var archiveMeetingsObject = new ArchiveMeetings();
        var archiveMeetingsResponse = await apiService.ArchiveMeetings<ArchiveMeetingsResponse>(token, archiveMeetingsObject);
        if (archiveMeetingsResponse.success == true)
            Console.WriteLine($"Archive Meetings Success Response value: Message: {archiveMeetingsResponse.message}");
        else
            Console.WriteLine($"Archive Meetings Error Response Message: {archiveMeetingsResponse.message}");
        Console.ReadKey();
        
        // Create UpcomingMeetings object
        var upcomingMeetingsObject = new UpcomingMeetings();
        var upcomingMeetingsResponse = await apiService.UpcomingMeetings<UpcomingMeetingsResponse>(token, upcomingMeetingsObject);
        if (upcomingMeetingsResponse.success == true)
            Console.WriteLine($"Upcoming Meetings Response Success Response value: total_pages: {upcomingMeetingsResponse.total_pages} and total_records: {upcomingMeetingsResponse.total_records} and Meetings: {upcomingMeetingsResponse.meetings}");
        else
            Console.WriteLine($"Upcoming Meetings Error Response Message: {upcomingMeetingsResponse.message}");
        Console.ReadKey();
        
        // Create ViewMeetings object
        var viewMeetingsObject = new ViewMeeting("MEETING_ID");
        var viewMeetingsResponse = await apiService.ViewMeeting<ViewMeetingResponse>(token, viewMeetingsObject);
        if (viewMeetingsResponse.success == true)
            Console.WriteLine($"View Meetings Response Success Response value: Meeting: {viewMeetingsResponse.meeting}, Occurrences: {viewMeetingsResponse.occurrences} and Meeting_attendees: {viewMeetingsResponse.meeting_attendees},  Meeting_groups: {viewMeetingsResponse.meeting_groups},and Organizer: {viewMeetingsResponse.organizer}");
        else
            Console.WriteLine($"View Meetings Error Response Message: {viewMeetingsResponse.message}");
        Console.ReadKey();

        
        // Create RecordingsList object
        var recordingsListObject = new RecordingsList("Local"); // 'Dropbox'/'Local'/'Custom'
        var recordingsListResponse = await apiService.RecordingsList<RecordingsListResponse>(token, recordingsListObject);
        if (recordingsListResponse.success == true)
            Console.WriteLine($"Recording List Success Response value: dropbox_recordings: {recordingsListResponse.dropbox_recordings}, meethour_recordings: {recordingsListResponse.meethour_recordings}, custom_recordings: {recordingsListResponse.custom_recordings}, total_pages: {recordingsListResponse.total_pages} and total_records: {recordingsListResponse.total_records}");
        else
            Console.WriteLine($"Recording List Error Response Code:{recordingsListResponse.code} and Message: {recordingsListResponse.message}");
        Console.ReadKey();
        
        // Create time_zone object
        var timeZoneObject = new TimeZone();
        var timeZoneResponse = await apiService.TimeZone<TimeZoneResponse>(token, timeZoneObject);
        if (timeZoneResponse.success == true)
            Console.WriteLine($"TimeZone Response Success Response value: Timezones: {timeZoneResponse.timezones}");
        else
            Console.WriteLine($"TimeZone Response Error Response Message: {timeZoneResponse.message}");
        Console.ReadKey();
        
        // Create user_details object
        var userDetailsObject = new UserDetails();
        var userDetailsResponse = await apiService.UserDetails<UserDetailsResponse>(token, userDetailsObject);
        if (userDetailsResponse.success == true)
            Console.WriteLine($"User Details Success Response value: data: {userDetailsResponse.data}");
        else
            Console.WriteLine($"User Details Error Response Code:{userDetailsResponse.code} and Message: {userDetailsResponse.message}");
        Console.ReadKey();
    }
    
}
