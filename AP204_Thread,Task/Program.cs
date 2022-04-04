using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AP204_Thread_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(delegate ()
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Console.Write(0);
            //    }
            //});

            //Thread thread1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Console.Write(1);
            //    }
            //});

            //Thread thread = new Thread(Write0);
            //Thread thread1 = new Thread(Write1);

            //thread.Start();
            //thread1.Start();

            //Task task = Task.Run(() =>
            //{
            //    Console.WriteLine("Hello AP204");
            //    Thread.Sleep(5000);
            //    Console.WriteLine("Hello again");


            //    Thread.Sleep(5000);

            //    Console.WriteLine("Goodbye");
            //});
            //Console.WriteLine("Waiting");
            //Console.WriteLine("Test1");
            //Console.WriteLine("Test2");
            //Console.WriteLine("Test3");

            //task.Wait();

            //Console.WriteLine("Finished");

            //Console.ReadLine();

            //IO bound operations
            //CPU bound operations

            //string code = "";
            //var task = getSource().ContinueWith(t=> {
            //    code = t.Result;
            //    Console.WriteLine(code);
            //    Thread.Sleep(1000);
            //    Console.WriteLine(code.Contains("body"));

            //});

            //Console.WriteLine(task.Result);


            //Console.WriteLine(code.Contains("body"));


            //Console.WriteLine("Any process 1");

            //for (int i = 1; i <= 20; i++)
            //{
            //    Console.WriteLine("Test "+i);
            //}
            //Console.WriteLine("Any process 2" );
            //Console.WriteLine("Any process 3");
            //Console.WriteLine("Any process 4");

            //var task = getSourceCodeAsync().ContinueWith(t =>
            //{
            //    Console.WriteLine(t.Result);
            //    Console.WriteLine(t.Result.Contains("google"));

            //});
            //Console.WriteLine("Any process");

            var task = getSourceCodeAsync();

            Console.Write("Loading");
            int count = 0;
            while (!task.IsCompleted)
            {
                count++;
                if (count <= 3)
                {
                    Thread.Sleep(200);
                    Console.Write(".");
                }
                else
                {
                    count = 0;
                    Console.Clear();
                    Console.Write("Loading");
                }
            }
            Console.Clear();

            Console.WriteLine(task.Result);
            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        public static Task<string> getSource()
        {
            HttpClient httpClient = new HttpClient();

            var task = Task.Run(() =>
            {
                return httpClient.GetStringAsync("https://www.google.com");
            });



            return task;
        }

        public static async Task<string> getGoogleSourceAsync()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync("https://www.google.com");
        }

        public static async Task<string> getShazamSourceAsync()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync("https://www.shazam.com");
        }

        public static async Task<string> getYoutubeSourceAsync()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync("https://www.youtube.com");
        }

        public static async Task<string> getSourceCodeAsync()
        {
            var googleCode = await getGoogleSourceAsync();
            var shazamCode = await getShazamSourceAsync();
            var ytCode = await getYoutubeSourceAsync();

            bool result = googleCode.Contains("google") && shazamCode.Contains("shazam") && ytCode.Contains("youtube");
            //Console.WriteLine(result);

            string codes = googleCode + shazamCode + ytCode;
            return codes;
        }




        //public static void Write0()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Thread.Sleep(20);
        //        Console.Write(0);
        //    }
        //}

        //public static void Write1()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Thread.Sleep(20);
        //        Console.Write(1);
        //    }
        //}

    }
}
