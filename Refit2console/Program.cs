using Newtonsoft.Json;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit2Lib;

namespace Refit2console
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Go.Task();
            var datatask = Go.DataUSA();

            Bored bored;
            DataUSA datausa;

            bored = task.Result;
            datausa = datatask.Result;

            Console.WriteLine("Bored API: https://boredapi.com/api/activity");
            Console.WriteLine("Participants: " + bored.participants);
            Console.WriteLine(datausa.data);
            Console.WriteLine(datausa.source);
            Console.WriteLine("DataUSA API: ");
            datausa.source.ForEach(c => Console.WriteLine($"{c.name}"));
            datausa.data.ForEach(c => Console.WriteLine($"{c.nation}"));
        }
        
    }
}
