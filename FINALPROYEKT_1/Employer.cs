using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FINALPROYEKT_1
{
    public class Employer : User
    {
        private static int id = 0;

        public Employer() { Id = ++id; }

        public Employer(List<Vacancia> vacancias, GmaileService gmaileServices, string? name, string? password,
                string? surname, int age, string? city, string? phoneNumber)
                : base(name: name, surname: surname, age: age, city: city, phoneNumber: phoneNumber, password: password)
        {
            Id = ++id;
            Name = name;
            Surname = surname;
            Age = age;
            City = city;
            PhoneNumber = phoneNumber;
            Password = password;
            this.vacancias = vacancias;
            this.gmaileServices = gmaileServices;
        }

        public int Id { get; set; }

        public List<Vacancia> vacancias { get; set; }

        public GmaileService gmaileServices { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}. {base.ToString()}  \nNamizedden telebler: {vacancias} GameService: {gmaileServices}";
        }
    }
}
