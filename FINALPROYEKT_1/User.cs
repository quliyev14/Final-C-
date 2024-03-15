using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public enum LanguageLevel
    {
        A1 = 30,
        A2 = 40,
        B1 = 50,
        B2 = 70,
        C1 = 80,
        C2 = 100
    }



    public class User
    {
        public User() { }

        public User(string? name, string? surname, int age, string? city, string? phoneNumber, string? password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            return $"Name: {Name} Surname: {Surname} Age: {Age} City: {City} PhoneNumber: {PhoneNumber} {Password}";
        }
    }
}
