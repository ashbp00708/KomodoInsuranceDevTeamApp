using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Create Developer Data
        public void AddDeveloperToDirectory(Developer data)
        {
            _developerDirectory.Add(data);
        }
       

        //Developer Read

        public List<Developer> DisplayDeveloperDirectory()
        {
            return _developerDirectory;
        }
       

        //Developer Update

        public bool EditDeveloperData(string oldLastName, Developer newData)
        {
            Developer oldData = DisplayDevById(oldLastName);
        if(oldData != null)
            {
                oldData.FirstName = newData.FirstName;
                oldData.LastName = newData.LastName;
                oldData.IdNumber = newData.IdNumber;
                oldData.IsPluralSightLicensed = newData.IsPluralSightLicensed;
                oldData.MemberOfTeam = newData.MemberOfTeam;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Developer Delete

        public bool DeleteDevFromDirectory(string lastName)
        {
            Developer data = DisplayDevById(lastName);
            if(data == null)
            {
                return false;
            }
            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(data);
            if(initialCount>_developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)

        public Developer DisplayDevById(string lastName)
        {
            foreach (Developer data in _developerDirectory)
            {
                if(data.LastName == lastName)
                {
                    return data;
                }
            }
            return null;
        }
    }
}
