using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace task6
{

    public class FileLines : IEnumerable
    {

        private class FileEnumerator : IEnumerator
        {
            private StreamReader _reader;
            private string _current = null;

            public FileEnumerator(StreamReader reader)
            {
                this._reader = reader;
            }

            public bool MoveNext()
            {
                if (_reader is null)
                {
                    return false;
                }
                _current = this._reader.ReadLine();
                if (_current is null)
                {
                    this.Reset();
                }
                return !(_current is null);
            }

            public void Reset()
            {
                if (!(_reader is null))
                {
                    _reader.BaseStream.Position = 0;
                }
            }

            public object Current => _current;

        }
        
        private StreamReader _reader;
        private string _fileName;

        public FileLines(string fileName)
        {
            this._fileName = fileName;
            this._reader = new StreamReader(fileName);
        }

        ~FileLines()
        {
            this._reader?.Close();
        }

        public IEnumerator GetEnumerator()
        {
            return new FileEnumerator(this._reader);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                FileLines obj = new FileLines("test.txt");
                foreach (var el in obj)
                {
                    Console.WriteLine(el);
                }

                Console.WriteLine();
                foreach (var el in obj)
                {
                    Console.WriteLine(el);
                }


            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}