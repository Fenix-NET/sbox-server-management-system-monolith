using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Application.Interfaces.Infrastructure
{
    public interface ITaskSchedulerService
    {
        void FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
