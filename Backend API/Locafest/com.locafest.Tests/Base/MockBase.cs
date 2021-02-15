using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Tests.Base
{
    internal class MockBase<TInterface, TAdapter> where TInterface : class where TAdapter : new()
    {
        protected readonly Mock<TInterface> mock = new Mock<TInterface>();

        public static TAdapter Instancia()
        {
            return new TAdapter();
        }

        public Mock<TInterface> Mock()
        {
            return mock;
        }

    }
}
