using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public class Vacancia
    {
        public Vacancia(string? vacancieTitle, string? education, string salaryMin, string salaryMax)
        {
            VacancieTitle = vacancieTitle;
            Education = education;
            this.salaryMin = salaryMin;
            this.salaryMax = salaryMax;
            StartDateTime = DateTime.Now;
            EndDateTime = DateTime.Now.AddMonths(1);
        }

        public string? VacancieTitle { get; set; }
        public string? Education { get; set; }
        public string? salaryMin { get; set; }
        public string? salaryMax { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }


        public override string ToString()
        {
            return $"VacanTitle: {VacancieTitle} \nEducation: {Education} \nSalaryMin: {salaryMin} \nSalaryMax{salaryMax} " +
                $"StartDateTime: {StartDateTime.Day}/{StartDateTime.Month}/{StartDateTime.Year} " +
                $"\nEndDateTime: {StartDateTime.Day}/{StartDateTime.Month + 1}/{StartDateTime.Year}";
        }
    }
}
