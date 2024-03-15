using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public static class Filter
    {
        public static void CityFilter(string? filename, Worker worker)
        {
            Console.Write("Enter The City: ");
            string? city = Console.ReadLine();

            try
            {
                var json = File.ReadAllText(filename!);
                var employers = JsonSerializer.Deserialize<List<Employer>>(json);

                foreach (var employer in employers!)
                {
                    if (employer.City == city)
                    {
                        Console.Clear();
                        foreach (var item in employers)
                        {
                            Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.PhoneNumber} {item.City} {item.gmaileServices}");
                            foreach (var item1 in item.vacancias)
                            {
                                Console.WriteLine($"{item1.VacancieTitle} {item1.Education} {item1.salaryMin} {item1.salaryMax}");
                            }
                        }

                        Console.Write("Enter The ID: ");
                        string? enteredId = Console.ReadLine();

                        if (int.TryParse(enteredId, out int id))
                        {

                            if (id == employer.Id)
                            {

                                for (int i = 3; i > 0; i--)
                                {
                                    Console.WriteLine($"{i}");
                                    System.Threading.Thread.Sleep(1000);
                                    Console.Clear();
                                }

                                MailMessage mail = new MailMessage();
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                mail.From = new MailAddress(employer.gmaileServices.gmail!);
                                mail.To.Add(employer.gmaileServices.gmail!);
                                mail.Subject = "*Cv Mail*";
                                string cvInfo = string.Join("\n", worker.WorkerCv.Select(cv => cv.ToString()));

                                mail.Body = $"{worker.Name} {worker.Surname}\n{cvInfo}";
                                smtp.Port = 587;
                                smtp.Credentials = new NetworkCredential(employer.gmaileServices.gmail, "bxud vzpz ayod xene");

                                smtp.EnableSsl = true;
                                smtp.Send(mail);
                                Console.WriteLine("📨 Mail sent successfully");
                                System.Threading.Thread.Sleep(1200);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("Entered ID does not match any employer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID entered.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void SalaryFilter(string? filename, Worker worker)
        {
            Console.Clear();
            Console.Write("salary min: ");
            string? salary = Console.ReadLine();
            int salarymin = Convert.ToInt32(salary);

            try
            {
                var json = File.ReadAllText(filename!);
                var employers = JsonSerializer.Deserialize<List<Employer>>(json);

                foreach (var employer in employers!)
                {
                    foreach (var vacancie in employer.vacancias)
                    {
                        int Salary = Convert.ToInt32(vacancie.salaryMin);

                        if (Salary >= salarymin)
                        {
                            Console.WriteLine($"{employer.Id} {employer.Name} {employer.Surname} {employer.PhoneNumber} {employer.City} {employer.gmaileServices}");
                            Console.WriteLine($"{vacancie.VacancieTitle} {vacancie.Education} {vacancie.salaryMin} {vacancie.salaryMax}");

                            Console.Write("Enter The ID: ");
                            string? enteredId = Console.ReadLine();

                            if (int.TryParse(enteredId, out int id))
                            {
                                if (id == employer.Id)
                                {
                                    for (int i = 3; i > 0; i--)
                                    {
                                        Console.WriteLine($"{i}");
                                        System.Threading.Thread.Sleep(1000);
                                        Console.Clear();
                                    }

                                    MailMessage mail = new MailMessage();
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                    mail.From = new MailAddress(employer.gmaileServices.gmail!);
                                    mail.To.Add(employer.gmaileServices.gmail!);
                                    mail.Subject = "*Cv Mail*";
                                    string cvInfo = string.Join("\n", worker.WorkerCv.Select(cv => cv.ToString()));

                                    mail.Body = $"{worker.Name} {worker.Surname}\n{cvInfo}";
                                    smtp.Port = 587;
                                    smtp.Credentials = new NetworkCredential(employer.gmaileServices.gmail, "bxud vzpz ayod xene");

                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                    Console.WriteLine("📨 Mail sent successfully");
                                    System.Threading.Thread.Sleep(1200);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Entered ID does not match any employer.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID entered.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void VacanyTitleFilter(string? filename, Worker worker)
        {
            Console.Write("Enter Vacany name: ");
            string? vacanyTitle = Console.ReadLine();

            try
            {
                var json = File.ReadAllText(filename!);
                var employers = JsonSerializer.Deserialize<List<Employer>>(json);

                foreach (var employer in employers!)
                {
                    foreach (var vacany in employer.vacancias)
                    {
                        if (vacany.VacancieTitle == vacanyTitle)
                        {
                            Console.Clear();
                            foreach (var emplo in employers)
                            {
                                Console.WriteLine($"{emplo.Id} {emplo.Name} {emplo.Surname} {emplo.PhoneNumber} {emplo.City} {emplo.gmaileServices}");
                                foreach (var emploVacany in emplo.vacancias)
                                {
                                    Console.WriteLine($"{emploVacany.VacancieTitle} {emploVacany.Education} {emploVacany.salaryMin} {emploVacany.salaryMax}");
                                }
                            }

                            Console.Write("Enter The ID: ");
                            string? enteredId = Console.ReadLine();

                            if (int.TryParse(enteredId, out int id))
                            {

                                if (id == employer.Id)
                                {

                                    for (int i = 3; i > 0; i--)
                                    {
                                        Console.WriteLine($"{i}");
                                        System.Threading.Thread.Sleep(1000);
                                        Console.Clear();
                                    }

                                    MailMessage mail = new MailMessage();
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                    mail.From = new MailAddress(employer.gmaileServices.gmail!);
                                    mail.To.Add(employer.gmaileServices.gmail!);
                                    mail.Subject = "*Cv Mail*";
                                    string cvInfo = string.Join("\n", worker.WorkerCv.Select(cv => cv.ToString()));

                                    mail.Body = $"{worker.Name} {worker.Surname}\n{cvInfo}";
                                    smtp.Port = 587;
                                    smtp.Credentials = new NetworkCredential(employer.gmaileServices.gmail, "bxud vzpz ayod xene");

                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                    Console.WriteLine("📨 Mail sent successfully");
                                    System.Threading.Thread.Sleep(1200);
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("Entered ID does not match any employer.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID entered.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
