using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public class Cv
    {
        public Cv() { }

        public Cv(string? specialty, string? schoolName, int universityScore, List<string> language, List<string> companie, LanguageLevel languageLevel, bool honorsDiploma, string? gitLink, string? linkEdin)
        {
            Specilaty = specialty;
            SchoolName = schoolName;
            Universitycore = universityScore;//range****
            Language = language;
            CompanieCount = companie;//sirket adlari 
            this.languageLevel = languageLevel;
            HonorsDiploma = honorsDiploma;
            GitLink = gitLink;
            Linkedln = linkEdin;
        }

        public string? Specilaty { get; set; }
        public string? SchoolName { get; set; }
        public int Universitycore { get; set; }
        public List<string> Language { get; set; }
        public List<string> CompanieCount { get; set; }
        public LanguageLevel languageLevel { get; set; }
        public bool HonorsDiploma { get; set; }
        public string? GitLink { get; set; }
        public string? Linkedln { get; set; }

        public override string ToString()
        {
            return $"\nSpecilaty: {Specilaty} \nScholl Name: {SchoolName} \nUniversity Score: {Universitycore} " +
                $"\nLanguage: {string.Join(", ", Language)} \nCompanie: {string.Join(", ", CompanieCount)} " +
                $"\nLanguage Level: {languageLevel} \nHonors Diploma: {HonorsDiploma} \nGitLink: {GitLink} \nLinkedln: {Linkedln}";
        }
    }
}
