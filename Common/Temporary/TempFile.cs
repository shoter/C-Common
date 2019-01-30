using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Temporary
{
    public class TempFile : IDisposable
    {
        public readonly string Path;
        public TempFile(string path)
        {
            Path = path;
        }



        public void LoadTo(Stream stream)
        {
            using (var fs = File.OpenRead(Path))
                fs.CopyTo(stream);
        }

        /// <param name="stream">Stream to write</param>
        /// <returns></returns>
        public void Save(Stream stream)
        {
            using (var fs = File.OpenWrite(Path))
                stream.CopyTo(fs);

        }

        public void Save(string str)
        {
            File.WriteAllText(Path, str);
        }

        public string Load()
        {
            return File.ReadAllText(Path);
        }

        private bool isDisposed = false;
        public void Dispose()
        {
            //it is safe to call Dispose more than once

            if (isDisposed == false)
            {
                File.Delete(Path);
            }

            isDisposed = true;
        }
    }
}
