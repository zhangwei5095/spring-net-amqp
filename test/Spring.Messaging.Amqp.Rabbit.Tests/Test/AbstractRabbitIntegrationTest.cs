﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Spring.Messaging.Amqp.Rabbit.Admin;

namespace Spring.Messaging.Amqp.Rabbit.Test
{
    /// <summary>
    /// A base class for integration tests, to ensure that the broker is started, and that it is shut down after the test is done.
    /// </summary>
    /// <remarks></remarks>
    public abstract class AbstractRabbitIntegrationTest
    {
        /// <summary>
        /// Determines if the broker is running.
        /// </summary>
        protected BrokerRunning brokerIsRunning = BrokerRunning.IsRunning();

        /// <summary>
        /// Ensures that RabbitMQ is running.
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            this.BeforeFixtureSetUp();
            
            // Eventually add some kind of logic here to start up the broker if it is not running.
            this.AfterFixtureSetUp();

            if (!this.brokerIsRunning.Apply())
            {
                Assert.Ignore("Rabbit broker is not running. Ignoring integration test fixture.");
            }
        }

        /// <summary>
        /// Fixtures the tear down.
        /// </summary>
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            this.BeforeFixtureTearDown();
            // var brokerAdmin = new RabbitBrokerAdmin();
            // brokerAdmin.StopBrokerApplication();
            // brokerAdmin.StopNode();
            this.AfterFixtureTearDown();
        }

        /// <summary>
        /// Code to execute before fixture setup.
        /// </summary>
        public abstract void BeforeFixtureSetUp();

        /// <summary>
        /// Code to execute before fixture teardown.
        /// </summary>
        public abstract void BeforeFixtureTearDown();

        /// <summary>
        /// Code to execute after fixture setup.
        /// </summary>
        public abstract void AfterFixtureSetUp();

        /// <summary>
        /// Code to execute after fixture teardown.
        /// </summary>
        public abstract void AfterFixtureTearDown();
    }
}
