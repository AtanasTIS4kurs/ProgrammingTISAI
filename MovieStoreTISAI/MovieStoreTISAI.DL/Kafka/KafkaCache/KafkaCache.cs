using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using MovieStoreB.Models.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreTISAI.DL.Kafka.KafkaCache
{
    public class KafkaCache<TKey, TValue> : BackgroundService
    {
        private readonly ConsumerConfig _config;

        public KafkaCache()
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = "kafka-193981-0.cloudclusters.net:10300",
                GroupId = $"KafkaChat-{Guid.NewGuid}",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.Plain,
                SaslUsername = "admin",
                SaslPassword = "CPxpKSRD"
            };
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var consumer = new ConsumerBuilder<TKey, TValue>(_config)
               .SetValueDeserializer(new MessagePackDeserializer<TValue>())
               .Build())
            {
                consumer.Subscribe("movies_cache");

                while (!stoppingToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume();

                    if (consumeResult.IsPartitionEOF)
                    {
                        continue;
                    }

                    if (consumeResult != null)
                    {
                        // Handle the error
                        Console.WriteLine($"Error: {consumeResult.Message.Key}");
                    }

                }

            }

            return Task.CompletedTask;
        }
    }
}
