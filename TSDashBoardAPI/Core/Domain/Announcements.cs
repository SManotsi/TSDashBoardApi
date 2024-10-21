using System;

namespace TSDashBoardApi.Core.Domain
{
    public class Announcements
    {
        public  int Id { get; set; }
        public required string Message { get; set; }
        public required DateTime CreatedDate { get; set; }

    }
}
