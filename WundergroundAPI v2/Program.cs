using System;

namespace WundergroundAPI_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlannerRequest request = new PlannerRequest(Environment.CurrentDirectory + "/cache");

            try
            {
                request.Query.setZipCode("45069");
                PlannerData data = request.MakeRequest();
                Console.WriteLine(data);
                System.Diagnostics.Trace.WriteLine(data);
            }
            catch(AmbiguousLocationException ex)
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
