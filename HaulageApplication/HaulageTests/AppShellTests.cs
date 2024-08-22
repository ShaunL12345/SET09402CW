using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage;
using Haulage.BaseClasses.Accounting;
using Moq;
using Microsoft.Maui.Controls;

namespace HaulageTests
{
    public class AppShellTests
    {
        [Fact]
        public void AppShell_ShouldInitializeWithoutErrors()
        {
            // Arrange & Act
            var exception = Record.Exception(() => new AppShell());

            // Assert
            Assert.Null(exception);
        }
    }
}
