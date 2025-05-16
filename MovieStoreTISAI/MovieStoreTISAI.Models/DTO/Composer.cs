using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreTISAI.Models.DTO
{
    public record Composer : ICacheItem<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime DateInserted { get; set; }

        public int GetKey()
        {
            return Id;
        }
    }

    public record Operator : ICacheItem<Guid>
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateInserted { get; set; }

        public Guid GetKey()
        {
            return Id;
        }
    }
}
