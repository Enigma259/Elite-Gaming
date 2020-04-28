using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_API.RabbitMQ
{
    /// <summary>
    /// This is the class RMQ_Receiver.
    /// </summary>
    public sealed class RMQ_Receiver
    {
        private static volatile RMQ_Receiver _instance;
        private static readonly object syncRoot = new Object(); 
        
        private string[] arguments;
        private string username;
        private string password;
        private string host_name;
        private int port;
        private TimeSpan network_recovery_interval;
        private TimeSpan requested_connection_timeout; // in milliseconds.
        private TimeSpan requested_heartbeat; // in seconds.
        private string virtual_host;
        private string channel_exchane;
        private string channel_type;
        private bool durable;
        private bool auto_delete;
        private bool auto_acknowledge;

        /// <summary>
        /// This is the constructor for the class RMQ_Receiver.
        /// <param name="arguments"></param>
        /// </summary>
        private RMQ_Receiver(string[] arguments)
        {
            SetArguments(arguments);
            SetUsername("guest");
            SetPassword("guest");
            SetHostName("localhost");
            SetPort(5672);
            SetNetworkRecoveryInterval(new TimeSpan(0, 0, 5));
            SetRequestedConnectionTimeout(new TimeSpan(0, 0, 2));
            SetRequestedHeartbeat(new TimeSpan(0, 0, 10));
            SetVirtualHost("/");
            SetChannelExchane("direct_logs");
            SetChannelType("calculation");
            SetDurable(true);
            SetAutoDelete(true);
            SetAutoAcknowledge(true);
        }

        /// <summary>
        /// This is a multi threaded singleton for the class RMQ_Receiver.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>_instance</returns>
        public static RMQ_Receiver GetInstance(string[] arguments)
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new RMQ_Receiver(arguments);
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// This method changes the value of the instance arguments.
        /// </summary>
        /// <param name="arguments"></param>
        public void SetArguments(string[] arguments)
        {
            this.arguments = arguments;
        }

        /// <summary>
        /// This method changes the value of the instance username.
        /// </summary>
        /// <param name="username"></param>
        public void SetUsername(string username)
        {
            this.username = username;
        }

        /// <summary>
        /// This method changes the value of the instance password.
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            this.password = password;
        }

        /// <summary>
        /// This method changes the value of the instance host_name.
        /// </summary>
        /// <param name="host_name"></param>
        public void SetHostName(string host_name)
        {
            this.host_name = host_name;
        }

        /// <summary>
        /// This method changes the value of the instance port.
        /// </summary>
        /// <param name="port"></param>
        public void SetPort(int port)
        {
            this.port = port;
        }

        /// <summary>
        /// This method changes the value of the instance network_recovery_interval.
        /// </summary>
        /// <param name="network_recovery_interval"></param>
        public void SetNetworkRecoveryInterval(TimeSpan network_recovery_interval)
        {
            this.network_recovery_interval = network_recovery_interval;
        }

        /// <summary>
        /// This method changes the value of the instance requested_connection_timeout.
        /// </summary>
        /// <param name="requested_connection_timeout"></param>
        public void SetRequestedConnectionTimeout(TimeSpan requested_connection_timeout)
        {
            this.requested_connection_timeout = requested_connection_timeout;
        }

        /// <summary>
        /// This method changes the value of the instance requested_heartbeat.
        /// </summary>
        /// <param name="requested_heartbeat"></param>
        public void SetRequestedHeartbeat(TimeSpan requested_heartbeat)
        {
            this.requested_heartbeat = requested_heartbeat;
        }

        /// <summary>
        /// This method changes the value of the instance virtual_host.
        /// </summary>
        /// <param name="virtual_host"></param>
        public void SetVirtualHost(string virtual_host)
        {
            this.virtual_host = virtual_host;
        }

        /// <summary>
        /// This method changes the value of the instance channel_exchane.
        /// </summary>
        /// <param name="channel_exchane"></param>
        public void SetChannelExchane(string channel_exchane)
        {
            this.channel_exchane = channel_exchane;
        }

        /// <summary>
        /// This method changes the value of the instance channel_type.
        /// </summary>
        /// <param name="channel_type"></param>
        public void SetChannelType(string channel_type)
        {
            this.channel_type = channel_type;
        }

        /// <summary>
        /// This method changes the value of the instance durable.
        /// </summary>
        /// <param name="durable"></param>
        public void SetDurable(bool durable)
        {
            this.durable = durable;
        }

        /// <summary>
        /// This method changes the value of the instance auto_delete.
        /// </summary>
        /// <param name="auto_delete"></param>
        public void SetAutoDelete(bool auto_delete)
        {
            this.auto_delete = auto_delete;
        }

        /// <summary>
        /// This method changes the value of the instance auto_acknowledge.
        /// </summary>
        /// <param name="auto_acknowledge"></param>
        public void SetAutoAcknowledge(bool auto_acknowledge)
        {
            this.auto_acknowledge = auto_acknowledge;
        }

        /// <summary>
        /// This method returns the value of the instance arguments.
        /// </summary>
        /// <returns>string[]</returns>
        public string[] GetArguments()
        {
            return arguments;
        }

        /// <summary>
        /// This method returns the value of the instance username.
        /// </summary>
        /// <returns>string</returns>
        public string GetUsername()
        {
            return username;
        }

        /// <summary>
        /// This method returns the value of the instance password.
        /// </summary>
        /// <returns>string</returns>
        public string GetPassword()
        {
            return password;
        }

        /// <summary>
        /// This method returns the value of the instance host_name.
        /// </summary>
        /// <returns>string</returns>
        public string GetHostName()
        {
            return host_name;
        }

        /// <summary>
        /// This method returns the value of the instance port.
        /// </summary>
        /// <returns>int</returns>
        public int GetPort()
        {
            return port;
        }

        /// <summary>
        /// This method returns the value of the instance network_recovery_interval.
        /// </summary>
        /// <returns>TimeSpan</returns>
        public TimeSpan GetNetworkRecoveryInterval()
        {
            return network_recovery_interval;
        }

        /// <summary>
        /// This method returns the value of the instance requested_connection_timeout.
        /// </summary>
        /// <returns>TimeSpan</returns>
        public TimeSpan GetRequestedConnectionTimeout()
        {
            return requested_connection_timeout;
        }

        /// <summary>
        /// This method returns the value of the instance requested_heartbeat.
        /// </summary>
        /// <returns>ushort</returns>
        public TimeSpan GetRequestedHeartbeat()
        {
            return requested_heartbeat;
        }

        /// <summary>
        /// This method returns the value of the instance virtual_host.
        /// </summary>
        /// <returns>string</returns>
        public string GetVirtualHost()
        {
            return virtual_host;
        }

        /// <summary>
        /// This method returns the value of the instance channel_exchane.
        /// </summary>
        /// <returns>string</returns>
        public string GetChannelExchane()
        {
            return channel_exchane;
        }

        /// <summary>
        /// This method returns the value of the instance channel_type.
        /// </summary>
        /// <returns>string</returns>
        public string GetChannelType()
        {
            return channel_type;
        }

        /// <summary>
        /// This method returns the value of the instance durable.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetDurable()
        {
            return durable;
        }

        /// <summary>
        /// This method returns the value of the instance auto_delete.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetAutoDelete()
        {
            return auto_delete;
        }

        /// <summary>
        /// This method returns the value of the instance auto_acknowledge.
        /// </summary>
        /// <returns>bool</returns>
        public bool GetAutoAcknowledge()
        {
            return auto_acknowledge;
        }

        /// <summary>
        /// This medthod recieves message from a message queue.
        /// </summary>
        public string ReceiveMessage()
        {
            string result = null;

            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = GetHostName(),
                    UserName = GetUsername(),
                    Password = GetPassword(),
                    Port = GetPort(),
                    NetworkRecoveryInterval = GetNetworkRecoveryInterval(),
                    RequestedConnectionTimeout = GetRequestedConnectionTimeout(),
                    RequestedHeartbeat = GetRequestedHeartbeat(),
                    VirtualHost = GetVirtualHost()
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: GetChannelExchane(), type: GetChannelType(), durable: GetDurable(), autoDelete: GetAutoDelete());
                    var queueName = channel.QueueDeclare().QueueName;

                    if (GetArguments().Length < 1)
                    {
                        Console.Error.WriteLine("Usage: {0} [info] [warning] [error]", Environment.GetCommandLineArgs()[0]);
                        Environment.ExitCode = 1;
                        result = "Failed";
                    }

                    if(result.Equals(null))
                    {
                        foreach (var severity in GetArguments())
                        {
                            channel.QueueBind(queue: queueName, exchange: GetChannelExchane(), routingKey: severity);
                        }

                        Console.WriteLine(" [*] Waiting for messages.");

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body[]);
                            var routingKey = ea.RoutingKey;
                            Console.WriteLine(" [x] Received '{0}':'{1}'", routingKey, message);
                        };
                        channel.BasicConsume(queue: queueName, autoAck: GetAutoAcknowledge(), consumer: consumer);

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                        result = "Exit";
                    }
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                result = "Failed";
            }

            return result;
        }
    }
}
