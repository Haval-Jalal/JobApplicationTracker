using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JobApplicationTracker
{
    public class JobManager
    {
        //Börjar med att skapa en lista av JobApplication klassen i min JobManager klass.
        public List<JobApplication> Application = new List<JobApplication>();

        //Skapar min första metod som lägger till en ny ansökan
        public void AddJob()
        {
            
            Console.WriteLine("Company");
            string companyName = Console.ReadLine();
            Console.WriteLine("Position");
            string positionTitle = Console.ReadLine();
            Console.WriteLine("Status (0: Applied, 1: Interviewing, 2: Offer, 3: Rejected)");
            int jobStatus = int.Parse(Console.ReadLine());
            Status status = (Status)jobStatus;
            Console.WriteLine("Application Date (yyyy-mm-dd)");
            DateTime applicationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Response Date (yyyy-mm-dd) or leave blank");
            DateTime responseDateInput = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Salary Expectation");
            int salaryExpectation = int.Parse(Console.ReadLine());

            JobApplication jobApp = new JobApplication
            {
                CompanyName = companyName,
                PositionTitle = positionTitle,
                Status = status,
                ApplicationDate = applicationDate,
                ResponseDate = responseDateInput,
                SalaryExpectation = salaryExpectation,

            };
                Application.Add(jobApp);
            
        }

        //Skapar min andra metod som ändrar status på en befintlig ansökan
        public void UpdateStatus(string companyName, Status newStatus, DateTime? responseDate = null)
        {
            // Hitta första ansökan som matchar företagsnamnet
            var job = Application.FirstOrDefault(a => a.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (job == null)
            {
                Console.WriteLine("Company not found.");
                return;
            }

            job.Status = newStatus;
            job.ResponseDate = responseDate;

            Console.WriteLine($"Status updated for {job.CompanyName} to {job.Status}.");
        }


        //Skapar min tredje metod som visar alla ansökningar
        public void ShowAll()
        {
            if (Application.Count == 0)
            {
                Console.WriteLine("No applications to show.");
                return;
            }

            var sorted = Application.OrderBy(a => a.ApplicationDate);
            Console.WriteLine("Applications sorted by date (oldest first):");

            Console.WriteLine("All job applications:");
            foreach (var app in Application)
            {
                Console.WriteLine(app.GetSummary());
                Console.WriteLine($"{app.GetDaysSinceApplied()} days have passed since application.");
            }
        }


        //Skapar min fjärde metod som filtrerar ansökningar efter status, använder mig av LINQ 

        public void ShowByStatus(Status status)
        {
            var filtered = Application.Where(a => a.Status == status);

            if (filtered.Any())
            {
                Console.WriteLine($"Applications with status: {status}");
                filtered.Select(app => app.GetSummary()).ToList().ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine($"No applications found with status: {status}");
            }
        }



        //Skapar min femte metod som visar statistik med LINQ (Count, Average, OrderBy, Where)

        public void ShowStatistics()
        {
            Console.WriteLine("Job Application Statistics:");
            
            Console.WriteLine($"Total applications: {Application.Count}");

            
            foreach (Status s in Enum.GetValues(typeof(Status)))
            {
                int count = Application.Count(a => a.Status == s);
                Console.WriteLine($" - {s}: {count}");
            }
          
            var responded = Application.Where(a => a.ResponseDate.HasValue);

            if (responded.Any())
            {
                double avgDays = responded.Average(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);
                Console.WriteLine($"Average response time: {avgDays} days");
            }
            else
            {
                Console.WriteLine("No responses yet to calculate average response time.");
            }
        }


        public void DeleteJob(string companyName)
        {
            var job = Application.FirstOrDefault(a => a.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));

            if (job == null)
            {
                Console.WriteLine("Company not found.");
                return;
            }

            Application.Remove(job);
            Console.WriteLine($"Application for {companyName} removed.");
        }
    }
}





    

