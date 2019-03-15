using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.WpfApi
{
    public static class TaskExtension
    {
        public static bool IsTaskFree(this Task task)
        {
            return task != null && (task.IsCanceled || task.IsCompleted || task.IsFaulted);
        }

        public static bool IsTaskBusy(this Task task)
        {
            return task != null && !task.IsCanceled && !task.IsCompleted && !task.IsFaulted;
        }
    }
}
