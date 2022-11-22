using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



public class apiRequest
{
    public static string Get(string url)
    {

        var request = (HttpWebRequest)WebRequest.Create(url);

        var response = (HttpWebResponse)request.GetResponse();

        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

        return responseString;

    }
}


internal class Program
{
    static void Main(string[] args)
    {
        string url = "https://www.bartosek.cz/shared/testEnv/OFD-API-ESP8266/var.txt";
        String state;


        Console.WriteLine($"" +
            $"Optic fiber detector - End user command line interface\n" +
            $"\nFor more visit github/Will-Bee" +
            $"\n" +
            $"\nReading at url: {url}");

        Console.WriteLine("\nSTATE:");


        while (true)
        {
            state = apiRequest.Get(url);

            if (state == "True")
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rON ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\rOFF");
                Console.ForegroundColor = ConsoleColor.Green;
            }

        }


    }
}