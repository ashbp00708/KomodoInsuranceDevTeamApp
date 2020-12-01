using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();


       

        //DevTeam Create

        public void AddDataToTeam(DevTeam data)
        {
            _devTeams.Add(data);
        }

        //DevTeam Read

        public List<DevTeam> GetDevTeamData()
        {
            return _devTeams;
        }
        //DevTeam Update

        public bool EditDevTeamData(string oldTeamName, DevTeam newData)
        {
            DevTeam oldData = FindTeamByName(oldTeamName);
            if (oldData != null) 
            {
                oldData.TeamName = newData.TeamName;
                oldData.TeamId = newData.TeamId;
                oldData.Description = newData.Description;
                oldData.PluralRequired = newData.PluralRequired;
                oldData.TeamMembers = newData.TeamMembers;
                return true;
            }
            else
            {
                return false;
         }
        }
        //DevTeam Delete

        public bool RemoveDataFromTeam(string teamName)
        {
            DevTeam data = FindTeamByName(teamName);
            if(data == null)
            {
                return false;
            }
            int initialCount = _devTeams.Count;
            _devTeams.Remove(data);

            if(initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)

        public DevTeam FindTeamByName(string teamName)
        {
            foreach(DevTeam data in _devTeams)
            {
                if(data.TeamName == teamName)
                {
                    return data;
                }
            }
            return null;
        }

    }
}
