namespace JobApplicationTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Börjar med att skapa 2 klasser direkt, En klass som heter JobApplication där jag ska har en enum, 6 attributer och 2 metoder.
            //Den andra klassen ska heta JobManager som ska ha 1 attribut som sedan ska göras till en lista samt 5 metoder.


            //Efter att jag skapat klassen JobApplication så skapar jag en instans av den i min Main.
            //Testar så att allt fungerar som det ska. 

            JobApplication job1 = new JobApplication();

            Console.WriteLine("Name");
            job1.CompanyName = Console.ReadLine();
            Console.WriteLine("Position");
            job1.PositionTitle = Console.ReadLine();
            Console.WriteLine("Status (0: Applied, 1: Interviewing, 2: Offer, 3: Rejected)");
            job1.Status = (Status)int.Parse(Console.ReadLine());
            Console.WriteLine("Application Date (yyyy-mm-dd)");
            job1.ApplicationDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Response Date (yyyy-mm-dd) or leave blank"); 
            string responseDateInput = Console.ReadLine();
            Console.WriteLine("Salary Expectation");
            job1.SalaryExpectation = int.Parse(Console.ReadLine());

            Console.WriteLine(job1.GetDaysSinceApplied());
            Console.WriteLine(job1.GetSummary());


            //Allt fungerar som det är tänkt.
            //Dags att gå vidare till nästa klass som heter JobManager.
            //Jobmanager ska ha en lista av JobApplication och 5 metoder.
            //Det den ska göra är att kunna lägga till en ansökan, ta bort en ansökan, uppdatera statusen på en ansökan, visa alla ansökningar och söka efter en ansökan baserat på företagsnamn eller positionstitel.


        }
    }
}
