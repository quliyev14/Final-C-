using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using FINALPROYEKT_1;

namespace FINALPROYEKT_1;


internal class Program
{
    private static void Main(string[] args)
    {
        // her bir sey .log a yazilir run.log json a yazilir ve oxunur 
        // employerin  gmaile mesaj gonderilir  Cv-i

        List<Worker> workers = new();

        List<Employer> employers = new();

        List<Cv> cvs = new();

        SyStem system = new();

        string logFilePath = "run.log";

        using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
        {
            writer.WriteLine($"{DateTime.Now}: Run verildi sistem ise dusdu");
        }

        while (true)
        {
            string? FileNameWorker = "ws.json";
            string? FileNameEmployer = "emplo.json";


            var jsonWorker = File.ReadAllText(FileNameWorker);
            var jsonWorkerList = JsonSerializer.Deserialize<List<Worker>>(jsonWorker);

            var jsonEmployer = File.ReadAllText(FileNameEmployer);
            var jsonEmployerList = JsonSerializer.Deserialize<List<Employer>>(jsonEmployer);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Employer");
            Console.WriteLine("2. Worker");
            Console.Write("Choose: ");

            string? Choose = Console.ReadLine();

            if (Choose != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
            }

            if (Choose == "1")
            {
                Console.Clear();

                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Sign up");

                Console.Write("Choose:  ");
                string? makeChoice = Console.ReadLine();
                Console.Clear();

                if (makeChoice == "1")
                {
                    Console.Write("Username: ");
                    string? Username = Console.ReadLine();
                    Console.Write("Password: ");
                    string? Password = Console.ReadLine();
                    Console.Clear();

                    var employer = jsonEmployerList!.FirstOrDefault(item => (item.Name == Username && item.Password == Password));

                    if (employer != null)
                    {
                        string openEmployerFilePath = "run.log";

                        using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                        {
                            writer.WriteLine($"{DateTime.Now}: Employer: {employer.Name} {employer.Surname} sisteme giris etdi");
                        }

                        Console.Clear();
                        Console.WriteLine("1. Vacancia Show");
                        Console.WriteLine("2. Delete Vacancia");
                        Console.WriteLine("3. Exit");
                        Console.Write("Choose: ");

                        int Id = employer.Id;

                        string? Ch = Console.ReadLine();

                        switch (Ch)
                        {
                            case "1":
                                Console.WriteLine(employer);
                                break;

                            case "2":
                                Console.Clear();
                                Console.WriteLine($"ID: {employer.Id} Name: {employer.Name} Surname: {employer.Surname} PhoneNumber: {employer.PhoneNumber}");
                                system.RemoveEmployer(Id, FileNameEmployer);
                                System.Threading.Thread.Sleep(1000);
                                Console.Clear();
                                break;

                            default:
                                break;
                        }
                    }

                    else
                    {

                        Console.WriteLine("Invalid username or password. Please try again.");
                        Thread.Sleep(500);
                        Console.Clear();
                        system.AddEmployer(FileNameEmployer);

                        string openEmployerFilePath = "run.log";

                        using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                        {
                            writer.WriteLine($"{DateTime.Now}: Employer qeydiyyatdan kecdi");
                        }

                        Console.Clear();
                    }
                }
                else if (makeChoice == "2")
                {

                    Thread.Sleep(1000);
                    Console.Clear();
                    system.AddEmployer(FileNameEmployer);

                    string openEmployerFilePath = "run.log";

                    using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                    {
                        writer.WriteLine($"{DateTime.Now}: Employer qeydiyyatdan kecdi");
                    }
                    Console.Clear();
                }
            }

            else if (Choose == "2")
            {
                Console.Clear();

                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Sign up");

                Console.Write("Choose:  ");
                string? makeChoice = Console.ReadLine();

                if (makeChoice == "1")
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string? username = Console.ReadLine();
                    Console.Write("Password: ");
                    string? password = Console.ReadLine();

                    var worker = jsonWorkerList!.FirstOrDefault(item => item.Name == username && item.Password == password);

                    if (worker != null)
                    {
                        string openEmployerFilePath = "run.log";

                        using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                        {
                            writer.WriteLine($"{DateTime.Now}: Worker:  {worker.Name} {worker.Surname} giris etdi");
                        }

                        Console.Clear();

                        Console.WriteLine("1. All Show Vacancia");
                        Console.WriteLine("2. Filter");

                        Console.Write("Make a Choice:  ");
                        string? Choice = Console.ReadLine();

                        if (Choice == "1")
                        {
                            Console.WriteLine("Show all vacancies");
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;

                            foreach (var employer in jsonEmployerList!)
                            {
                                Console.WriteLine($"Employer ID: {employer.Id}  Name: {employer.Name} Surname: {employer.Surname} Age: {employer.Age}  " +
                                                     $"City: {employer.City} PhoneNumber: {employer.PhoneNumber}");

                                foreach (var vacancia in employer.vacancias)
                                {

                                    Console.WriteLine($"  Vacancia Title: {vacancia.VacancieTitle}, Education: {vacancia.Education}, " +
                                                        $"SalaryMin: {vacancia.salaryMin}, SalaryMax: {vacancia.salaryMax} " +
                                                        $"StartDateTime: {vacancia.StartDateTime} EndDateTime: {vacancia.EndDateTime}\n\n");
                                }
                            }

                            Console.Write("\nEnter the ID of the employer you want to interact with: ");

                            string? employerIdInput = Console.ReadLine();
                            int id = Convert.ToInt32(employerIdInput);
                            Console.Clear();

                            var selectedEmployer = jsonEmployerList?.FirstOrDefault(e => e.Id == id);

                            if (selectedEmployer != null)
                            {
                                try
                                {
                                    MailMessage mail = new MailMessage();
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                    mail.From = new MailAddress(selectedEmployer.gmaileServices.gmail!);
                                    mail.To.Add(selectedEmployer.gmaileServices.gmail!);
                                    mail.Subject = "*Cv Mail*";
                                    string cvInfo = string.Join("\n", worker.WorkerCv.Select(cv => cv.ToString()));

                                    mail.Body = $"{worker.Name} {worker.Surname}\n{cvInfo}";

                                    smtp.Port = 587;
                                    smtp.Credentials = new NetworkCredential(selectedEmployer.gmaileServices.gmail, "bxud vzpz ayod xene");

                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                    Console.WriteLine("Mail sent successfully");
                                }

                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            else
                            {
                                Console.WriteLine("Employer with the given ID not found.");
                                System.Threading.Thread.Sleep(1500);
                                Console.Clear();
                            }
                        }

                        else if (Choice == "2")
                        {
                            Console.Clear();

                            Console.WriteLine("1. Filter Vacany Title");
                            Console.WriteLine("2. Filter Vacany Salary");
                            Console.WriteLine("3. Filter Vacany City");

                            Console.Write("Filter choice:  ");
                            string? filterChoice = Console.ReadLine();

                            switch (filterChoice)
                            {
                                case "1":
                                    Filter.VacanyTitleFilter(FileNameEmployer, worker!);
                                    Console.Clear();
                                    break;

                                case "2":
                                    Filter.SalaryFilter(FileNameEmployer, worker!);
                                    Console.Clear();
                                    break;

                                case "3":
                                    Filter.CityFilter(FileNameEmployer, worker!);
                                    Console.Clear();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    else
                    {

                        Console.WriteLine("You do not have a name in the system, please register");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        system.AddWorkerCv(workers, cvs, FileNameWorker);
                        string openEmployerFilePath = "run.log";

                        using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                        {
                            writer.WriteLine($"{DateTime.Now}: Worker qeydiyyatdan kecdi");
                        }

                        Console.Clear();
                    }
                }

                else if (makeChoice == "2")
                {
                    string openEmployerFilePath = "run.log";

                    using (StreamWriter writer = new StreamWriter(openEmployerFilePath, append: true))
                    {
                        writer.WriteLine($"{DateTime.Now}: Worker qeydiyyatdan kecdi");
                    }

                    Console.Clear();
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    system.AddWorkerCv(workers, cvs, FileNameWorker);

                    Console.Clear();
                }
            }
        }
    }
}