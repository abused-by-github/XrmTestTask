using System.Collections.Generic;

namespace DomainModel
{
    public class Page<T>
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }
    }
}
