using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tasks
{
    public static class TaskExtension
    {
        ///https://stackoverflow.com/a/17224745/2583946
        /// <summary> 
        /// Runs the Task in a concurrent thread without waiting for it to complete. This will start the task if it is not already running. 
        /// </summary> 
        /// <param name="task">The task to run.</param> 
        /// <remarks>This is usually used to avoid warning messages about not waiting for the task to complete.</remarks> 
        public static void RunAsync(this Task task)
        {
            if (task == null)
                throw new ArgumentNullException("task", "task is null.");


            if (task.Status == TaskStatus.Created)
                task.Start();
        }
    }
}
