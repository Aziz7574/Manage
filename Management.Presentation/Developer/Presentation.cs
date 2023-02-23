using Management.Service.DTO;
using Management.Service.Helpers;
using Management.Service.Services;
using System.Security.Cryptography.X509Certificates;

namespace Management.Presentation.Developer
{
    public class Presentation
    {
        private readonly DeveloperService developerServiceservice = new DeveloperService();
        public async void CreateOrEditProfile()
        {
            DeveloperDto dDto = new DeveloperDto();
            try
            {
                Console.Write("Name - >");
                dDto.FirstName = Console.ReadLine();
                Console.Write("Surname - >");
                dDto.LastName = Console.ReadLine();
                Console.Write("Salary - >");
                dDto.Salary = decimal.Parse(Console.ReadLine());
                Console.Write("Position Of Stuff( Junior,Middle,Senior,TeamLeader,ProjectManager) - >");
                bool a = true;
                while (a)
                {
                    string str = Console.ReadLine();
                    switch (str)
                    {
                        case "Junior": { dDto.Status = Domain.Enums.StatusOfDeveloper.Junior; a = false; }; break;
                        case "Middle": { dDto.Status = Domain.Enums.StatusOfDeveloper.Middle; a = false; }; break;
                        case "Senior": { dDto.Status = Domain.Enums.StatusOfDeveloper.Senior; a = false; }; break;
                        case "TeamLeader": { dDto.Status = Domain.Enums.StatusOfDeveloper.TeamLeader; a = false; }; break;
                        case "ProjectManager": { dDto.Status = Domain.Enums.StatusOfDeveloper.ProjectManager; a = false; }; break;
                        default: Console.Write("pls try again"); break;
                    }
                }
                await developerServiceservice.CreateAsync(dDto);
                Console.Clear();
                Console.WriteLine("Successfully created");
            }
            catch
            {
                Console.Write("Something went wrong");
            }
        }


        public async void WatchAllMyTask()
        {
            Console.Write("Enter your id - >");
            long id = long.Parse(Console.ReadLine());
          Response<List<TaskDTO>> allTask =   await  developerServiceservice.WatchAllTasksOfThePerson(id);

            var alltask = allTask.Result.GroupBy(p => p.AssignedToById);

            foreach(var item in alltask)
            {
                Console.WriteLine($"Given by {item.Key}");
                Console.WriteLine("TaskList");
                foreach (var i in item) {
                    Console.WriteLine($"Task target - {i.Target}");
                    Console.WriteLine($"Condition - {i.Process}");
                }
            }
        }
    }
}
