using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreTISAI.Models.Configuration.KafkaCache
{
    public abstract class BaseKafkaCacheConfig
    {
        public string BootstrapServer { get; set; } = string.Empty;

        public string Topic { get; set; }
    }
}
