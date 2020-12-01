using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public bool PluralRequired { get; set; }
        public List<Developer> TeamMembers { get; set; }

        public DevTeam() { }
        public DevTeam(string teamName, int teamId, string description, bool pluralRequired)
        {
            TeamName = teamName;
            TeamId = teamId;
            Description = description;
            PluralRequired = pluralRequired;
            
        }
    }
}
