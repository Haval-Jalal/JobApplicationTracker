using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public static class MenuHelper
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Job Application Tracker Menu:");
            Console.WriteLine("1. Add Job Application");
            Console.WriteLine("2. Update Job Application Status");
            Console.WriteLine("3. View All Job Applications");
            Console.WriteLine("4. Delete job Applications");
            Console.WriteLine("5. Exit");
            Console.Write("Please select an option (1-5): ");
        }
    }
}
