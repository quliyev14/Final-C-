using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public class SyStem
    {
        public SyStem() { }

        public void AddWorkerCv(List<Worker> workers, List<Cv> cv, string? filname)
        {
            LanguageLevel level;

            Console.Write("Specialty:  ");
            string? Specialty = Console.ReadLine();

            Console.Write("School name:  ");
            string? SchoolName = Console.ReadLine();

            Console.Write("University score:  ");
            string? Score = Console.ReadLine();
            int UniversityScore = Convert.ToInt32(Score);

            Console.Write("Honor Diploma (true/false):  ");
            bool HonorDiploma = Convert.ToBoolean(Console.ReadLine());

            Console.Write("GitLink:  ");
            string? GitLink = Console.ReadLine();

            Console.Write("LinkedIn:  ");
            string? LinkedIn = Console.ReadLine();

            List<string> companies = new();

            Console.Write("Number of Companies worked for:  ");
            string? compCount = Console.ReadLine();

            for (int i = 0; i < Convert.ToInt32(compCount); i++)
            {
                Console.Write("Company Name:  ");
                string? CompanyName = Console.ReadLine();

                companies.Add(CompanyName!);
            }

            Console.Write("Number of Languages known:  ");
            string? langCount = Console.ReadLine();
            int LangCount = Convert.ToInt32(langCount);

            List<Cv> newCvs = new List<Cv>();

            while (LangCount > 0)
            {
                List<string> languages = new List<string>();

                Console.Write("Language:  ");
                string? Language = Console.ReadLine();
                languages.Add(Language!);

                string? languageLevel;
                do
                {
                    Console.Write("Language Level (A1, A2, B1, B2, C1, C2):  ");
                    languageLevel = Console.ReadLine();
                } while (!Enum.TryParse(languageLevel, out level));

                LangCount--;

                Cv newCv = new Cv(Specialty, SchoolName, UniversityScore, languages, companies, level, HonorDiploma, GitLink, LinkedIn);
                newCvs.Add(newCv);
            }

            Console.Write("Name:  ");
            string? Name = Console.ReadLine();

            Console.Write("Surname:  ");
            string? Surname = Console.ReadLine();

            Console.Write("Age:  ");
            string? age = Console.ReadLine();
            int Age = Convert.ToInt32(age);

            Console.Write("Password:  ");
            string? Password = Console.ReadLine();

            Console.Write("City:  ");
            string? City = Console.ReadLine();

            Console.Write("Phone number:  ");
            string? PhoneNumber = Console.ReadLine();

            Console.Write("Gender:  ");
            string? Gender = Console.ReadLine();

            Worker worker = new Worker(Name, Surname, Password, Age, City, PhoneNumber, newCvs, Gender);
            workers.Add(worker);

            List<Worker>? existingWorkers = new List<Worker>();

            if (File.Exists(filname))
            {
                string? json = File.ReadAllText(filname);
                existingWorkers = JsonSerializer.Deserialize<List<Worker>>(json);
            }

            int maxId = existingWorkers!.Count > 0 ? existingWorkers.Max(e => e.id) : 0;
            worker.id = maxId + 1;
            existingWorkers!.Add(worker);

            string updateJson = JsonSerializer.Serialize(existingWorkers, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(filname!, updateJson);
        }

        public void AddEmployer(string filename)
        {
            List<Vacancia> vacancias = new();

            List<Employer> employers = new();


            //Employer
            Console.WriteLine("Employer");
            Console.Write("Name:  ");
            string? Name = Console.ReadLine();

            Console.Write("Surname:  ");
            string? Surname = Console.ReadLine();

            Console.Write("Age:  ");
            string? age = Console.ReadLine();
            int Age = Convert.ToInt32(age);

            Console.Write("Password:  ");
            string? Password = Console.ReadLine();

            Console.Write("City:  ");
            string? City = Console.ReadLine();

            Console.Write("Phone number:  ");
            string? PhoneNumber = Console.ReadLine();

            Console.WriteLine("Oz gmalinizi daxil edin gmaile mesaj gedecek ");
            Console.Write("Gmail:  ");
            string? gmailService = Console.ReadLine();

            GmaileService Gmailservice = new(gmailService);

            // vacancie
            Console.WriteLine("Vacancie");
            Console.Write("Vacancie Title:  ");
            string? vacancieTitle = Console.ReadLine();
            Console.Write("Education  (Ali), (Orta), (Vacib deyil), (Elmi derecede):  ");
            string? Education = Console.ReadLine();
            Console.Write("Salary min:  ");
            string? salarymin = Console.ReadLine();
            Console.Write("Salary max:  ");
            string? salarymax = Console.ReadLine();


            Vacancia vacancia = new(vacancieTitle: vacancieTitle, education: Education, salaryMin: salarymin!, salaryMax: salarymax!);

            vacancias.Add(vacancia);

            Employer employer = new(vacancias, Gmailservice, name: Name, password: Password, surname: Surname, age: Age, city: City, phoneNumber: PhoneNumber);

            List<Employer> existingEmployers = new List<Employer>();

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                existingEmployers = JsonSerializer.Deserialize<List<Employer>>(json) ?? new List<Employer>();
            }

            int maxId = existingEmployers!.Count > 0 ? existingEmployers.Max(e => e.Id) : 0;

            employer.Id = maxId + 1;

            existingEmployers.Add(employer);


            string updatedJson = JsonSerializer.Serialize(existingEmployers, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(filename, updatedJson);

            Console.WriteLine("you have registered...");
            Console.Clear();
        }

        public void RemoveEmployer(int id, string? filename)
        {
            var json = File.ReadAllText("emplo.json");
            var jsonList = JsonSerializer.Deserialize<List<Employer>>(json);

            var employerToRemove = jsonList!.FirstOrDefault(e => e.Id == id);
            if (employerToRemove != null)
            {
                jsonList!.Remove(employerToRemove);

                var updatedJson = JsonSerializer.Serialize(jsonList, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(filename!, updatedJson);

                Console.WriteLine($"Employer with ID {id} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employer with ID {id} not found.");
            }
        }
    }
}
