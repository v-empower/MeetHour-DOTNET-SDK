using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class MHApiService
{
    private const string BASE_URL = "https://api.meethour.io";
    private const string API_VERSION = "v1.2";

    private readonly HttpClient httpClient;

    public MHApiService()
    {
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private string GetApiEndpointUrl(string endpoint)
    {
        string base_url = BASE_URL;
        string version = API_VERSION;

        switch (endpoint)
        {
            case "login":
                return $"{base_url}/oauth/token";
            case "add_contact":
                return $"{base_url}/api/{version}/customer/addcontact";
            case "contacts":
                return $"{base_url}/api/{version}/customer/contacts";
            case "edit_contact":
                return $"{base_url}/api/{version}/customer/editcontact";
            case "edit_meeting":
                return $"{base_url}/api/{version}/meeting/editmeeting";
            case "generate_jwt":
                return $"{base_url}/api/{version}/getjwt";
            case "schedule_meeting":
                return $"{base_url}/api/{version}/meeting/schedulemeeting";
            case "completed_meetings":
                return $"{base_url}/api/{version}/meeting/completedmeetings";
            case "missed_meetings":
                return $"{base_url}/api/{version}/meeting/missedmeetings";
            case "archive_meetings":
                return $"{base_url}/api/{version}/meeting/archivemeeting";
            case "upcoming_meetings":
                return $"{base_url}/api/{version}/meeting/upcomingmeetings";
            case "view_meetings":
                return $"{base_url}/api/{version}/meeting/viewmeeting";
            case "recordings_list":
                return $"{base_url}/api/{version}/customer/videorecordinglist";
            case "time_zone":
                return $"{base_url}/api/{version}/getTimezone";
            case "user_details":
                return $"{base_url}/api/{version}/customer/user_details";
            case "refresh_token":
                return $"{base_url}/oauth/token";
            case "ContactSearch":
                return $"{base_url}/meeting/getContactSearch";
            default:
                throw new ArgumentException("Invalid endpoint");
        }
    }

    private string SubstitutePathParameter(string endpoint, string pathParam)
    {
        if (pathParam == null)
        {
            return endpoint;
        }
        else
        {
            return $"{endpoint}/{pathParam}";
        }
    }

    private HttpRequestHeaders GetHeaders(string token)
    {
        HttpRequestHeaders headers = httpClient.DefaultRequestHeaders;

        if (!string.IsNullOrEmpty(token))
        {
            headers.Add("Content-Type", "application/json");
            headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        else
        {
            headers.Add("Content-Type", "application/json");
        }

        return headers;
    }

    private async Task<T> PostFetch<T>(string token, string endpoint, object body, string pathParam = null)
    {
        string constructedUrl = SubstitutePathParameter(GetApiEndpointUrl(endpoint), pathParam);

        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, constructedUrl);
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            HttpResponseMessage response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();
            T result = System.Text.Json.JsonSerializer.Deserialize<T>(responseContent);

            return result;
        }
        catch (HttpRequestException error)
        {
            Console.WriteLine(error.Message);
            return default(T);
        }
    }

    // Methods for different API endpoints
    // Implement as needed...

    // Example method for logging in
    public async Task<T> Login<T>(Login loginObject)
    {
        object body = loginObject.Prepare();
        return await PostFetch<T>(string.Empty, "login", body);
    }

    public async Task<T> AddContact<T>(string token, AddContact addContactObject)
    {
        object body = addContactObject.Prepare();
        return await PostFetch<T>(token, "add_contact", body);
    }


    public async Task<T> Contact<T>(string token, Contact contactsObject)
    {
        object body = contactsObject.Prepare();
        return await PostFetch<T>(token, "contacts", body);
    }

    public async Task<T> EditContact<T>(string token, EditContact editContactObject)
    {
        object body = editContactObject.Prepare();
        return await PostFetch<T>(token, "edit_contact", body);
    }

    public async Task<T> EditMeeting<T>(string token, EditMeeting editMeetingObject)
    {
        object body = editMeetingObject.Prepare();
        return await PostFetch<T>(token, "edit_meeting", body);
    }

    public async Task<T> GenerateJwt<T>(string token, GenerateJwt generateJwtObject)
    {
        object body = generateJwtObject.Prepare();
        return await PostFetch<T>(token, "generate_jwt", body);
    }

    public async Task<T> ScheduleMeeting<T>(string token, ScheduleMeeting scheduleMeetingObject)
    {
        object body = scheduleMeetingObject.Prepare();
        Console.WriteLine($"ScheduleMeeting body value: {body}");
        return await PostFetch<T>(token, "schedule_meeting", body);
    }

    public async Task<T> CompletedMeetings<T>(string token, CompletedMeetings completedMeetingsObject)
    {
        object body = completedMeetingsObject.Prepare();
        return await PostFetch<T>(token, "completed_meetings", body);
    }

    public async Task<T> MissedMeetings<T>(string token, MissedMeetings missedMeetingsObject)
    {
        object body = missedMeetingsObject.Prepare();
        return await PostFetch<T>(token, "missed_meetings", body);
    }

    public async Task<T> ArchiveMeetings<T>(string token, ArchiveMeetings archiveMeetingsObject)
    {
        object body = archiveMeetingsObject.Prepare();
        return await PostFetch<T>(token, "archive_meetings", body);
    }

    public async Task<T> UpcomingMeetings<T>(string token, UpcomingMeetings upcomingMeetingsObject)
    {
        object body = upcomingMeetingsObject.Prepare();
        return await PostFetch<T>(token, "upcoming_meetings", body);
    }

    public async Task<T> ViewMeeting<T>(string token, ViewMeeting viewMeetingsObject)
    {
        object body = viewMeetingsObject.Prepare();
        return await PostFetch<T>(token, "view_meetings", body);
    }

    public async Task<T> RecordingsList<T>(string token, RecordingsList recordingsListObject)
    {
        object body = recordingsListObject.Prepare();
        return await PostFetch<T>(token, "recordings_list", body);
    }

    public async Task<T> RefreshToken<T>(string token, RefreshToken refreshTokenObject)
    {
        object body = refreshTokenObject.Prepare();
        return await PostFetch<T>(token, "refresh_token", body);
    }

    public async Task<T> TimeZone<T>(string token, TimeZone timezoneObject)
    {
        object body = timezoneObject.Prepare();
        return await PostFetch<T>(token, "time_zone", body);
    }

    public async Task<T> UserDetails<T>(string token, UserDetails userdetailsObject)
    {
        object body = userdetailsObject.Prepare();
        return await PostFetch<T>(token, "user_details", body);
    }
}
