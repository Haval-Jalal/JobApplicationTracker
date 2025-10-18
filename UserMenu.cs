using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{
    public static class UserMenu
    {
        public static void UserChoise(JobManager jobManager)
        {
            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                MenuHelper.DisplayMenu();
                Console.ResetColor();

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Green;
                        jobManager.AddJob();
                        Console.ResetColor();
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter Company Name to update:");
                        Console.ResetColor();
                        string companyName = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter new Status (0: Applied, 1: Interview, 2: Offer, 3: Rejected):");
                        Console.ResetColor();
                        int statusInput = int.Parse(Console.ReadLine());
                        Status newStatus = (Status)statusInput;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter Response Date (yyyy-mm-dd) or leave blank:");
                        Console.ResetColor();
                        string responseDateStr = Console.ReadLine();
                        DateTime? responseDate = string.IsNullOrWhiteSpace(responseDateStr) ? null : DateTime.Parse(responseDateStr);

                        // Här: visa status i färg innan uppdatering
                        Console.Write("Updating status to: ");
                        switch (newStatus)
                        {
                            case Status.Applied:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case Status.Interview:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case Status.Offer:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case Status.Rejected:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                        }
                        Console.WriteLine(newStatus);
                        Console.ResetColor();

                        jobManager.UpdateStatus(companyName, newStatus, responseDate);
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        jobManager.ShowAll();
                        Console.ResetColor();
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter Company Name to delete:");
                        Console.ResetColor();
                        string delCompanyName = Console.ReadLine();
                        jobManager.DeleteJob(delCompanyName);
                        break;

                    case "5":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Exiting application...");
                        Console.ResetColor();
                        running = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
