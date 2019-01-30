using Common.StringDecorators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class FileLogger : BaseLogger
    {
        public string PathToFile { get; protected set; }
        private static object locker = new object();
        protected IStringDecorator[] stringDecorators;
        public FileLogger(string pathToFile, params IStringDecorator[] stringDecorators)
        {
            var directory = Path.GetDirectoryName(pathToFile);
            Directory.CreateDirectory(directory);

            PathToFile = pathToFile;
            this.stringDecorators = stringDecorators;
        }
        public override ILogger Log(string message, params object[] args)
        {
            message = string.Format(message, args);
            message = stringDecorators.Process(message);

            lock (locker)
            {
                using (var writer = File.AppendText(PathToFile))
                {
                    writer.Write(message);
                }
            }
            return this;
        }
    }
}
