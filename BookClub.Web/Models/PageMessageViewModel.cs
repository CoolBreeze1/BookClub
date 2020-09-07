using System;


namespace BookClub.Web.Models
{
    public class PageMessage
    {
        public PageMessage()
        {
            AllowClose = true;
        }

        public PageMessage(string message, PageMessageType type)
        {
            Message = message;
            Type = type;
        }
        public PageMessage(string message, PageMessageType type, bool allowClose)
        {
            Message = message;
            Type = type;
            AllowClose = allowClose;
        }
        public PageMessage(string title, string message, PageMessageType type)
        {
            Title = title;
            Message = message;
            Type = type;
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public PageMessageType Type { get; set; }
        public bool AllowClose { get; set; }
    }

    public enum PageMessageType
    {
        Success = 0,
        Info = 1,
        Error = 2,
        Warning = 3
    }
}
