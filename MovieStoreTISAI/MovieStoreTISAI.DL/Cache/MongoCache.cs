using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreTISAI.Models.Cache
{
    public class MongoCache<T>
    {
        public string Id { get; set; } = string.Empty;
        public T? Data { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddMinutes(5);
        public bool IsExpired => DateTime.UtcNow > ExpirationDate;
    }
}
