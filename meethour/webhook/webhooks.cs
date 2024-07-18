using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


namespace meethour.webhook 
{
    public class WebhookHandler
    {
        private readonly string secret;

        public WebhookHandler(string secret)
        {
            this.secret = secret;
        }

        public Dictionary<string, object> HandleRequest(string requestBody, Dictionary<string, string> headers)
        {
            var payload = requestBody;
            headers.TryGetValue("HTTP_MEETHOUR_SIGNATURE", out var signature);

            if (signature != null && ValidateSignature(payload, signature))
            {
                try
                {
                    var data = JsonSerializer.Deserialize<Dictionary<string, object>>(payload);
                    return ProcessEvent(data, payload);
                }
                catch (JsonException)
                {
                    return GenerateResponse(false, 400, "Invalid JSON payload.", null);
                }
            }
            else
            {
                return GenerateResponse(false, 400, "Invalid signature or signature missing.", null);
            }
        }

        private bool ValidateSignature(string payload, string signature)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                var expectedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return string.Equals(expectedSignature, signature, StringComparison.OrdinalIgnoreCase);
            }
        }

        private Dictionary<string, object> ProcessEvent(Dictionary<string, object> data, string payload)
        {
            if (data.TryGetValue("event_type", out var eventTypeObj) && eventTypeObj is string eventType)
            {
                return eventType switch
                {
                    "join_meeting" => HandleJoinMeeting(data),
                    "exit_meeting" => HandleExitMeeting(data),
                    "save_meeting_recording" => HandleSaveMeetingRecording(data),
                    _ => GenerateResponse(false, 400, "Unknown event type: " + eventType, data),
                };
            }
            return GenerateResponse(false, 400, "Event type missing.", data);
        }

        private Dictionary<string, object> HandleJoinMeeting(Dictionary<string, object> data)
        {
            return GenerateResponse(true, 200, "Join meeting event processed", data);
        }

        private Dictionary<string, object> HandleExitMeeting(Dictionary<string, object> data)
        {
            return GenerateResponse(true, 200, "Exit meeting event processed", data);
        }

        private Dictionary<string, object> HandleSaveMeetingRecording(Dictionary<string, object> data)
        {
            return GenerateResponse(true, 200, "Save meeting recording event processed", data);
        }

        private Dictionary<string, object> GenerateResponse(bool status, int code, string message, Dictionary<string, object> data)
        {
            var response = new Dictionary<string, object>
            {
                { "status", status },
                { "code", code },
                { "message", message }
            };

            if (data != null)
            {
                if (data.TryGetValue("event_type", out var eventType))
                {
                    response["event_type"] = eventType;
                }

                if (data.TryGetValue("event_id", out var eventId))
                {
                    response["event_id"] = eventId;
                }

                if (data.TryGetValue("timestamp", out var timestamp))
                {
                    response["timestamp"] = timestamp;
                }

                response["data"] = data;
            }

            return response;
        }
    }
}
