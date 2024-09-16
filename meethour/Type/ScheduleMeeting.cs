public class ScheduleMeeting
{
    public string MeetingName { get; set; }
    public string Passcode { get; set; }
    public string Timezone { get; set; }
    public string MeetingDate { get; set; }
    public string MeetingTime { get; set; }
    public string MeetingMeridiem { get; set; }
    public int SendCalendarInvite { get; set; }
    public bool IsShowPortal { get; set; }
    public string DefaultRecordingStorage { get; set; }
    public string? Agenda { get; set; }
    public object? Attend { get; set; }
    public int? DurationHr { get; set; }
    public int? DurationMin { get; set; }
    public int? EnablePreRegistration { get; set; }
    public string? EndBy { get; set; }
    public string? EndDateTime { get; set; }
    public int? EndTimes { get; set; }
    public object? Groups { get; set; }
    public object? HostUsers { get; set; }
    public string? IsRecurring { get; set; }
    public string? MeetingAgenda { get; set; }
    public string? MeetingTopic { get; set; }
    public string? MonthlyBy { get; set; }
    public string? MonthlyByDay { get; set; }
    public string? MonthlyByWeekday { get; set; }
    public string? MonthlyByWeekdayIndex { get; set; }
    public object? Options { get; set; }
    public string? RecurringType { get; set; }
    public int? RepeatInterval { get; set; }
    public int? WeeklyWeekDays { get; set; }

    public ScheduleMeeting(string meetingName,string passcode,string timezone,string meetingDate,string meetingTime,string meetingMeridiem,int sendCalendarInvite,bool isShowPortal, string defaultRecordingStorage, string? agenda = null, object? attend = null, int? durationHr = null,int? durationMin = null, int? enablePreRegistration = null, string? endBy = null, string? endDateTime = null, int? endTimes = null, object? groups = null, object? hostUsers = null, string? isRecurring = null, string? meetingAgenda = null, string? meetingTopic = null, string? monthlyBy = null, string? monthlyByDay = null, string? monthlyByWeekday = null, string? monthlyByWeekdayIndex = null, object? options = null, string? recurringType = null, int? repeatInterval = null, int? weeklyWeekDays = null)
    {
        MeetingName  = meetingName;
        Passcode  = passcode;
        Timezone = timezone;
        MeetingDate  = meetingDate;
        MeetingTime  = meetingTime;
        MeetingMeridiem  = meetingMeridiem;
        SendCalendarInvite  = sendCalendarInvite;
        IsShowPortal = isShowPortal;
        DefaultRecordingStorage = defaultRecordingStorage;
        Agenda = agenda;
        Attend = attend;
        DurationHr = durationHr;
        DurationMin = durationMin;
        EnablePreRegistration = enablePreRegistration;
        EndBy = endBy;
        EndDateTime = endDateTime;
        EndTimes = endTimes;
        Groups = groups;
        HostUsers = hostUsers;
        IsRecurring = isRecurring;
        MeetingAgenda = meetingAgenda;
        MeetingTopic = meetingTopic;
        MonthlyBy = monthlyBy;
        MonthlyByDay = monthlyByDay;
        MonthlyByWeekday = monthlyByWeekday;
        MonthlyByWeekdayIndex = monthlyByWeekdayIndex;
        Options = options;
        RecurringType = recurringType;
        RepeatInterval = repeatInterval;
        WeeklyWeekDays = weeklyWeekDays;
    }
    public object Prepare()
    {
        return new
        {
            meeting_name = MeetingName,
            passcode = Passcode,
            timezone = Timezone,
            meeting_date = MeetingDate,
            meeting_time = MeetingTime,
            meeting_meridiem = MeetingMeridiem,
            send_calendar_invite = SendCalendarInvite,
            is_show_portal = IsShowPortal,
            default_recording_storage = DefaultRecordingStorage,
            agenda = Agenda,
            attend = Attend,
            duration_hr = DurationHr,
            duration_min = DurationMin,
            enable_pre_registration = EnablePreRegistration,
            endBy = EndBy,
            end_date_time = EndDateTime,
            end_times = EndTimes,
            groups = Groups,
            hostusers = HostUsers,
            is_recurring = IsRecurring,
            meeting_agenda = MeetingAgenda,
            meeting_topic = MeetingTopic,
            monthlyBy = MonthlyBy,
            monthlyByDay = MonthlyByDay,
            monthlyByWeekday = MonthlyByWeekday,
            monthlyByWeekdayIndex = MonthlyByWeekdayIndex,
            options = Options,
            recurring_type = RecurringType,
            repeat_interval = RepeatInterval,
            weeklyWeekDays = WeeklyWeekDays
        };
    }
}
