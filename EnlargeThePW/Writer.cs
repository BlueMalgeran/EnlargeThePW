using System;
using System.IO;
using System.Text;

namespace EnlargeThePW
{
    class Writer
    {
        public string FilePath { get; set; }

        public void AppendToFile(string textToAppend)
        {
            object obj = Writer.locker;
            lock (obj)
            {
                using (FileStream fileStream = new FileStream(this.FilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode))
                    {
                        streamWriter.WriteLine(textToAppend);
                    }
                }
            }
        }
        private static readonly object locker = new object();
    }
}
