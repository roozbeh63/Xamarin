using System;
using System.Collections.Generic;
using System.Text;

namespace BenchTest.Services
{
    public interface INotification
    {
        void NotifyWarning(string text);
        void NotifyError(string text);
    }
}
