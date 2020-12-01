using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public enum TeamNames
    {
        Design = 1,
        Software,
        Security,
        Media,
        Management
    }

    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        public bool IsPluralSightLicensed { get; set; }
        public TeamNames MemberOfTeam { get; set; }

        public Developer() { }
        public Developer(string firstName, string lastName, int idNumber, bool isPluralSightLicensed, TeamNames memberOfTeam)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            IsPluralSightLicensed = isPluralSightLicensed;
            MemberOfTeam = memberOfTeam;

        }
    }
}
