public class EditMeeting
{
    public string MeetingId { get; set; }
    public string MeetingName { get; set; }
    public string MeetingDate { get; set; }
    public string MeetingTime { get; set; }
    public string MeetingMeridiem { get; set; }
    public string PassCode { get; set; }
    public string DefaultRecordingStorage { get; set; }
    public string? Agenda { get; set; }
    public int? DurationHr { get; set; }
    public int? DurationMin { get; set; }
    public string? TimeZone { get; set; }
    public int? IsRecurring { get; set; }
    public string? RecurringType { get; set; }
    public int? RepeatInterval { get; set; }
    public int? WeeklyWeekDays { get; set; }
    public string? MonthlyBy { get; set; }
    public string? MonthlyByDay { get; set; }
    public string? MonthlyByWeekdayIndex { get; set; }
    public string? MonthlyByWeekday { get; set; }
    public string? EndBy { get; set; }
    public string? EndDateTime { get; set; }
    public string? Instructions { get; set; }
    public int? IsShowPortal { get; set; }
    public int? EnablePreRegistration { get; set; }
    public string? MeetingTopic { get; set; }
    public string? MeetingAgenda { get; set; }
    public object? Options { get; set; }
    public int? OldAttend { get; set; }
    public object? Attend { get; set; }
    public int? Groups { get; set; }
    public object? HostUsers { get; set; }
    public object? LiveStreamSettings { get; set; }

    public EditMeeting(string Meetingid, string Meetingname = null, string Meetingdate = null, string Meetingtime = null, string Meetingmeridiem = null, string Passcode = null, string defaultrecordingstorage = null, string? agenda = null, int? Durationhr = null, int? Durationmin = null, string? Timezone = null, int? Isrecurring = null, string? Recurringtype = null, int? Repeatinterval = null, int? weeklyweekdays = null, string? monthlyby = null, string? monthlybyday = null, string? monthlybyweekdayindex = null, string? monthlybyweekday = null, string? endby = null, string? enddatetime = null, string? instructions = null, int? isshowportal = null, int? enablepre_registration = null, string? meetingtopic = null, string? meetingagenda = null, object? options = null, int? oldattend = null, object? attend = null, int? groups = null, object? hostusers = null, object? livestreamsettings = null)
        {
            MeetingId = Meetingid;
            MeetingName = Meetingname;
            MeetingDate = Meetingdate;
            MeetingTime = Meetingtime;
            MeetingMeridiem = Meetingmeridiem;
            PassCode = Passcode;
            DefaultRecordingStorage = defaultrecordingstorage;
            Agenda = agenda;
            DurationHr = Durationhr;
            DurationMin = Durationmin;
            TimeZone = Timezone;
            IsRecurring = Isrecurring;
            RecurringType = Recurringtype;
            RepeatInterval = Repeatinterval;
            WeeklyWeekDays = weeklyweekdays;
            MonthlyBy = monthlyby;
            MonthlyByDay = monthlybyday;
            MonthlyByWeekdayIndex = monthlybyweekdayindex;
            MonthlyByWeekday = monthlybyweekday;
            EndBy = EndBy;
            EndDateTime = enddatetime;
            Instructions = instructions;
            IsShowPortal = isshowportal;
            EnablePreRegistration = enablepre_registration;
            MeetingTopic = meetingtopic;
            MeetingAgenda = meetingagenda;
            Options = options;
            OldAttend = oldattend;
            Attend = attend;
            Groups = groups;
            HostUsers = hostusers;
            
            LiveStreamSettings = livestreamsettings;
        }
        public object Prepare()
            {
                return new
                {
                    meeting_id = MeetingId,
                    meeting_name = MeetingName,
                    meeting_date = MeetingDate,
                    meeting_time = MeetingTime,
                    meeting_meridiem = MeetingMeridiem,
                    passcode = PassCode,
                    default_recording_storage = DefaultRecordingStorage,
                    agenda = Agenda,
                    duration_hr = DurationHr,
                    duration_min = DurationMin,
                    timezone = TimeZone,
                    is_recurring = IsRecurring,
                    recurring_type = RecurringType,
                    repeat_interval = RepeatInterval,
                    weeklyWeekDays = WeeklyWeekDays,
                    monthlyBy = MonthlyBy,
                    monthlyByDay = MonthlyByDay,
                    monthlyByWeekdayIndex = MonthlyByWeekdayIndex,
                    monthlyByWeekday = MonthlyByWeekday,
                    endBy = EndBy,
                    end_date_time = EndDateTime,
                    instructions = Instructions,
                    is_show_portal = IsShowPortal,
                    enable_pre_registration = EnablePreRegistration,
                    meeting_topic = MeetingTopic,
                    meeting_agenda = MeetingAgenda,
                    options = Options,
                    old_attend = OldAttend,
                    attend = Attend,
                    groups = Groups,
                    hostusers = HostUsers,
                    live_stream_settings = LiveStreamSettings
                };
            }
    }
