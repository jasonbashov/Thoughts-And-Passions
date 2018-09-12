using System;
using System.IO;

namespace VeryImportantLibrary
{
    public class VeryImportantClass
    {
        private StreamWriter _writer;

        public VeryImportantClass()
        {
            this._writer = new StreamWriter("important.txt");
        }

        public void WriteText(string text)
        {
            using (this._writer)
            {
                this._writer.Write(text);
            }
        }
    }
}
