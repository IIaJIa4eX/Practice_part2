using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson1_ex1_console_async
{
    //updated to pullreq
    class Program
    {

        static string path = @"C:\Users\Alexander\Desktop\result_test.txt";

        static readonly HttpClient client = new HttpClient();
        static FileStream fileStream;

        public static void Main(string[] args)
        {

            fileStream = File.OpenWrite(path);

            List<Task> ss = new List<Task>();
            for (int id = 4; id < 14; id++)
                {
                    ss.Add(GetAsync(client, id, path, fileStream));

                }

           _ = Task.WhenAll(ss).ContinueWith(EndStream);

           Console.WriteLine("12345_test");
           Console.ReadLine();
           
        }

        public static void EndStream(Task t)
        {
            fileStream.Close();
        }

        public static async Task GetAsync(HttpClient client, int id, string path, FileStream file)
        {
             await Task.Run(() => GetInfoById(client, id, path, fileStream));
        }

        public static async Task GetInfoById(HttpClient client, int id, string path, FileStream file)
        {
            
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");

                var responseBody = await response.Content.ReadAsStreamAsync();
             
                var result = await JsonSerializer.DeserializeAsync<DataHolder>(
                    responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                byte[] buffer = Encoding.UTF8.GetBytes($"{result.userId}\n{result.id}\n{result.title}\n{result.body}\n\n");

                await file.WriteAsync(buffer, 0, buffer.Length);

            }
            catch (Exception e)
            {

                    Console.WriteLine("Id:{0}\nMessage :{1} ", id, e.Message);
            }


            
        }

        private class DataHolder
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }

        }
    }
}
