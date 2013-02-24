using System;
using System.Text.RegularExpressions;

namespace WundergroundAPI_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            TideRequest request = new TideRequest(Environment.CurrentDirectory + "/cache");

            try
            {
                request.Query.setZipCode("45069");
                TideData data = request.GetParsedAPIResponse();
                Console.WriteLine(data);
            }
            catch (AmbiguousLocationException ex)
            {
                foreach (AmbiguousLocation l in ex.Locations)
                    Console.WriteLine(l);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
