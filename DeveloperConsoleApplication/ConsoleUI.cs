using System;
using DevTeamsProject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperConsoleApplication
{
    class ConsoleUI

    {
        private DevTeamRepo _teamRepo = new DevTeamRepo();
        private DeveloperRepo _devRepo = new DeveloperRepo();

        public void Run()
        {
            SeedDataList();
            DeveloperMenu();
        }
        private void DeveloperMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                System.Console.WriteLine("Komodo Developer Database\n" +
                    "Select an option from the directory:\n" +
                    "1. Add Developer to Database\n" +
                    "2. Display Developers\n" +
                    "3. Display Developers by ID Number\n" +
                    "4. Display Developers that need Plural Sight License\n" +
                    "5. Edit Developer Data\n" +
                    "6. Delete Developer from Database");
                    System.Console.WriteLine("Komodo Developer Team Database\n" +
                    "7. Add Developer Team\n" +
                    "8. Display Developer Teams\n" +
                    "9. Display Teams that Require Plural Sight License\n" +
                    "10. Display Developers in Teams\n" +
                    "11. Edit Developer Team Data\n" +
                    "12. Delete Developer Team from Database\n" +
                    "13. Exit Komodo Database");

                string input = System.Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        DisplayDevs();
                        break;
                    case "3":
                        DisplayDevById();
                        break;
                    case "4":
                        DisplayDevByPlural();
                        break;
                    case "5":
                        EditDevData();
                        break;
                    case "6":
                        DeleteDev();
                        break;
                    case "7":
                        AddDevTeam();
                        break;
                    case "8":
                        DisplayDevTeam();
                        break;
                    case "9":
                        DisplayPluralSightRequiredTeams();
                        break;
                    case "10":
                        DisplayDevsInTeam();
                        break;
                    case "11":
                        EditDevTeamData();
                        break;
                    case "12":
                        DeleteDevTeam();
                        break;
                    case "13":
                        System.Console.WriteLine("Have a Nice Day!");
                        keepRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Select a Valid Option From Menu..");
                        break;

                }
                System.Console.WriteLine("Press any key to continue..");
                System.Console.ReadKey();
                System.Console.Clear();
            }
        }
        private void AddDeveloper()
        {
            System.Console.Clear();
            Developer newData = new Developer();

            System.Console.WriteLine("Enter the First Name of the Developer:");
            newData.FirstName = System.Console.ReadLine();

            System.Console.WriteLine("Enter the Last Name of the Developer:");
            newData.LastName = System.Console.ReadLine();

            System.Console.WriteLine("Enter the NEW Id Number Assigned to the Developer:");
            string devIdNumber = System.Console.ReadLine();
            newData.IdNumber = int.Parse(devIdNumber);

            System.Console.WriteLine("Is the Developer Plural Sight Licensed? (y/n)");
            string pluralSightString = System.Console.ReadLine();

            if (pluralSightString == "y")
            {
                newData.IsPluralSightLicensed = true;
            }
            else
            {
                newData.IsPluralSightLicensed = false;
            }

            System.Console.WriteLine("Enter the Team Name to Assign Developer a Team:\n" +
                "1. Design\n" +
                "2. Software\n" +
                "3. Security\n" +
                "4. Media\n" +
                "5. Management");
            string teamMemberString = System.Console.ReadLine();
            int teamMemberInt = int.Parse(teamMemberString);
            newData.MemberOfTeam = (TeamNames)teamMemberInt;

            _devRepo.AddDeveloperToDirectory(newData);

        }
        private void DisplayDevs()
        {
            System.Console.Clear();
            List<Developer> developerDirectory = _devRepo.DisplayDeveloperDirectory();

            foreach(Developer data in developerDirectory)
            {
                System.Console.WriteLine($"First Name: {data.FirstName}\n" +
                    $"Last Name: {data.LastName}\n" +
                    $"Identification Number: {data.IdNumber}\n" +
                    $"Plural Sight License: {data.IsPluralSightLicensed}");
            }
        }
        private void DisplayDevById()
        {
            System.Console.Clear();
            System.Console.WriteLine("Enter the ID number associated to the developer you would like to view:");
            string devIdNumberstring = System.Console.ReadLine();
            int MemberOfTeam = int.Parse(devIdNumberstring);
        }
        private void DisplayDevByPlural()
        {

            System.Console.WriteLine("Developers who do not currently have Plural Sight License: ");
           
           
            

        }
        private void EditDevData()
        {
            DisplayDevs();

            System.Console.WriteLine("\n" + "Enter the last name of the developer that you would like to edit:");
            string oldLastName = System.Console.ReadLine();

            Developer newData = new Developer();

            System.Console.WriteLine("Enter the first name for the new developer data:");
            newData.FirstName = System.Console.ReadLine();

            System.Console.WriteLine("Enter the last name for the new developer data:" );
            newData.LastName = System.Console.ReadLine();

            System.Console.WriteLine("Enter the identification number for the new developer data:");
            string devIdNumberstring = System.Console.ReadLine();
            int idNumber = int.Parse(devIdNumberstring);

            System.Console.WriteLine("Is the developer plural sight licensed? (y/n)");
            string isPluralSightLicensedString = System.Console.ReadLine();
            if (isPluralSightLicensedString == "y")
            {
                newData.IsPluralSightLicensed = true;
            }
            else
            {
                newData.IsPluralSightLicensed = false;
            }
            System.Console.WriteLine("Enter name of team developer is assigned:");
            string teamMemberString = System.Console.ReadLine();
            int teamMemberInt = int.Parse(teamMemberString);
            newData.MemberOfTeam = (TeamNames)teamMemberInt;

            bool wasEdited = _devRepo.EditDeveloperData(oldLastName, newData);
            if(wasEdited)
            {
                System.Console.WriteLine("Developer data was successfully edited.");
            }
            else
            {
                System.Console.WriteLine("Could not edit develoer data...");
            }

        }
        private void DeleteDev()
        {
            System.Console.WriteLine("Enter the last name of the Developer you would like to delete:");
            string input = System.Console.ReadLine();
            bool devDeleted = _devRepo.DeleteDevFromDirectory(input);

            if (devDeleted)
            {
                System.Console.WriteLine("The developer data has been successfully deleted from the database.");

            }
            else
            {
                System.Console.WriteLine("The developer data could not be deleted from the database.");
            }

        }
        private void AddDevTeam()
        {
            System.Console.Clear();
            DevTeam newData = new DevTeam();

            System.Console.WriteLine("Enter the name of the team you would like to create:");
            newData.TeamName = System.Console.ReadLine();

            System.Console.WriteLine("Enter a description for the new team:");
            newData.Description = System.Console.ReadLine();

            System.Console.WriteLine("Enter an identification number for the new team:");
            string teamIdNumberString = System.Console.ReadLine();
            newData.TeamId = int.Parse(teamIdNumberString);

            System.Console.WriteLine("Does the new team require developers to be plural sight licensed? (y/n)");
            string pluralSightRequiredString = System.Console.ReadLine();

            if (pluralSightRequiredString == "y")
            {
                newData.PluralRequired = true;
            }
            else
            {
                newData.PluralRequired = false;
            }

        }
        private void DisplayDevTeam()
        {
            System.Console.Clear();
            List<DevTeam> devTeams = _teamRepo.GetDevTeamData();

            foreach(DevTeam data in devTeams)
            {
                System.Console.WriteLine($"Team Name: {data.TeamName}\n" +
                    $"Description: {data.Description}\n" +
                    $"Plural Sight Required: {data.PluralRequired}");
                    
            }

        }
        private void DisplayPluralSightRequiredTeams()
        {
            System.Console.Clear();
            System.Console.WriteLine("Developer teams that require Plural Sight License:");

            
        }
        private void DisplayDevsInTeam()
        {
        }

        private void EditDevTeamData()
        {
            DisplayDevTeam();

            System.Console.WriteLine("Enter the team name of the data you would like to Edit:");
            string oldTeamName = System.Console.ReadLine();
            DevTeam newData = new DevTeam();

            System.Console.WriteLine("Enter the name for the new team data:");
            newData.TeamName = System.Console.ReadLine();

            System.Console.WriteLine("Enter the description for the new team data:");
            newData.Description = System.Console.ReadLine();

            System.Console.WriteLine("Enter the team number for the new team data:");
            string teamIdNumberString = System.Console.ReadLine();
            newData.TeamId = int.Parse(teamIdNumberString);

            System.Console.WriteLine("Does the team data require plural sight licensing? (y/n)");
            string pluralSightRequiredString = System.Console.ReadLine();
            if(pluralSightRequiredString == "y")
            {
                newData.PluralRequired = true;

            }
            else
            {
                newData.PluralRequired = false;
            }
            bool wasEdited = _teamRepo.EditDevTeamData(oldTeamName, newData);
            if(wasEdited)
            {
                System.Console.WriteLine("Team Data was successfully Edited!");

            }
            else
            {
                System.Console.WriteLine("Could not edit team data...");
            }

        }
        private void DeleteDevTeam()
        {
            DisplayDevTeam();

            System.Console.WriteLine("\n" +
                "Enter the number of the team you want to delete");
            string input = System.Console.ReadLine();

            bool dataDeleted = _teamRepo.RemoveDataFromTeam(input);
            
            if(dataDeleted)
            {
                System.Console.WriteLine("The team was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine("The team could not be deleted.");
            }

        }
        private void SeedDataList()
        {
            DevTeam Design = new DevTeam("Design", 1, "Team with a heavy CSS and UI focused schedule.", true);
            DevTeam Software = new DevTeam("Software", 2, "Team with a heavy focuse on C# and application testing.", true);
            DevTeam Security = new DevTeam("Security", 3, "Team with a cybersecurity background and focus on protecting company network and privacy.", false);
            DevTeam Media = new DevTeam("Media", 4, "Team with a focus in online presence, advertisements, and marketing.", false);
            DevTeam Management = new DevTeam("Management", 5, "Team of senior level Developers that work to lead the individual teams in their specified field.", true);

            _teamRepo.AddDataToTeam(Design);
            _teamRepo.AddDataToTeam(Software);
            _teamRepo.AddDataToTeam(Security);
            _teamRepo.AddDataToTeam(Media);
            _teamRepo.AddDataToTeam(Management);

            Developer developer1 = new Developer("Michael", "Pabody", 1, true, TeamNames.Management);
            Developer developer2 = new Developer("Casey", "Wilson", 2, true, TeamNames.Management);
            Developer developer3 = new Developer("Drew", "Graber", 3, true, TeamNames.Software);
            Developer developer4 = new Developer("Jess", "Schultz", 4, true, TeamNames.Design);
            Developer developer5 = new Developer("David", "Whitt", 5, false, TeamNames.Security);
            Developer developer6 = new Developer("Zach", "Maynard", 6, false, TeamNames.Media);

            _devRepo.AddDeveloperToDirectory(developer1);
            _devRepo.AddDeveloperToDirectory(developer2);
            _devRepo.AddDeveloperToDirectory(developer3);
            _devRepo.AddDeveloperToDirectory(developer4);
            _devRepo.AddDeveloperToDirectory(developer5);
            _devRepo.AddDeveloperToDirectory(developer6);

        }

    }

    
}
