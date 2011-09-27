﻿
using Spring.Messaging.Amqp.Rabbit.Connection;
using Spring.Messaging.Amqp.Rabbit.Test;

namespace Spring.Messaging.Amqp.Rabbit.Listener
{
    using NUnit.Framework;

    /// <summary>
    /// Message listener recovery single connection integration tests.
    /// </summary>
    /// <remarks></remarks>
    [TestFixture]
    [Category(TestCategory.Integration)]
    public class MessageListenerRecoverySingleConnectionIntegrationTests : MessageListenerRecoveryCachingConnectionIntegrationTests
    {
        /// <summary>
        /// Creates the connection factory.
        /// </summary>
        /// <returns>The connection factory.</returns>
        /// <remarks></remarks>
        protected IConnectionFactory CreateConnectionFactory()
        {
            var connectionFactory = new SingleConnectionFactory();
            connectionFactory.Port = BrokerTestUtils.GetPort();
            return connectionFactory;
        }
    }
}
