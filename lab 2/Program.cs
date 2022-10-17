using System.Collections.Generic;
using System;

namespace Singleton
{

    interface ILogger {
        void Clear() { }
        void saveErr() { }
        void FormatError() { }
    }
    class Logger : ILogger {
        private static Logger _instance = null;
        private string filename;
        private StreamWriter stream;

        public Logger(string filename)
        {
            this.filename = filename;
            this.stream = new StreamWriter(filename, true);
        }


        public static Logger getInstance(string filename = "log.txt")
        {
            if (_instance == null)
            {
                _instance = new Logger(filename);
            }

            return _instance;
        }

        public void saveErr(string message, int code)
        {

            this.stream.WriteLine($"{code} {DateTime.Now} : {message}");
            this.stream.Flush();
        }

        public void ShowLog()
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
                Console.WriteLine(line);
        }
        public void Clear() {
            stream.Dispose();
            File.Delete(filename);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Logger logger = Logger.getInstance();
            Logger logger2 = Logger.getInstance();
            logger.Clear();
            logger2.Clear();
            logger.saveErr(message: "error", code: 404);
            logger.Clear();
            logger2.saveErr(message: "error2", code: 404);
            logger.saveErr(message: "error", code: 404);
            logger.ShowLog();
            logger2.ShowLog();
            Console.ReadLine();
        }
    }
}