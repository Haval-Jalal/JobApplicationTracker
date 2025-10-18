using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicationTracker
{

    //Skapar enum för att senare kunna använda den i klassen JobApplication    
    public enum Status
    {
        Applied,
        Interview,
        Offer,
        Rejected
    }
    public class JobApplication
    {
        public string CompanyName { get; set; }
        public string PositionTitle { get; set; }
        public Status Status { get; set; } // Använder enum här för att kunna sätta status på ansökan. Eftersom en av statusen alltid måste vara aktiv.
        public DateTime ApplicationDate { get; set; }
        public DateTime? ResponseDate { get; set; } // Sättter ? eftersom svaret kan komma senare, vilket betyder att det inte finns något värde än och kan därför vara null under den tiden.
        public int SalaryExpectation { get; set; } // 


        // Skapar min första metod som returnerar antalet dagar sedan ansökan skickades in.
        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }


        // Skapar min andra metod som returnerar en sammanfattning av ansökan.

        public string GetSummary()
        {
            
            return $"Company: {CompanyName}, Position: {PositionTitle}, Status: {Status}, Applied On: {ApplicationDate.ToShortDateString()}, Response On: {ResponseDate?.ToShortDateString()}, Days since application: {GetDaysSinceApplied()} days, Salary Expectation: {SalaryExpectation} SEK";
        }
      
    }



}
