using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public class Worker : User
    {
        private static int ID = 0;
        public int id { get; set; }

        public Worker() { id = ++ID; }

        public Worker(string? name, string? surname, string? password, int age, string? city, string? phoneNumber, List<Cv> workerCv, string? gender)
            : base(name: name, surname: surname, age: age, city: city, phoneNumber: phoneNumber, password: password)
        {
            id = ++ID;
            Name = name;
            Surname = surname;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
            Password = password;
            WorkerCv = workerCv;
            Gender = gender;
        }

        public string? Gender { get; }
        public List<Cv> WorkerCv { get; set; }


        public override string ToString()
        {
            //string cvInfo = string.Join("\n", WorkerCv.Select(cv => cv.ToString()));

            return $"ID: {id} \n{base.ToString()} \nWorkerCv: \n{WorkerCv} \nGender: {Gender}";
        }
    }
}
