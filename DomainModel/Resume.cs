using System;

namespace DomainModel
{
    public class Resume
    {
        public long Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Header { get; set; }
        public string Url { get; set; }
    }
}
