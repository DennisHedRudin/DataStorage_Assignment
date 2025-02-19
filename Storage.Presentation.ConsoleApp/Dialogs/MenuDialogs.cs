
using Data.Interfaces.IServices;
using Data.Models.ProjectModel;
using Data.Services;

namespace Storage.Presentation.ConsoleApp.Dialogs;

public class MenuDialogs(ProjectService projectService) : IMenuDialogs
{
    private readonly ProjectService _projectService = projectService;

    public async Task MenuDialog()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("### Menu ###");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. View Projects");
            Console.WriteLine("3. Update Project");
            Console.WriteLine("4. Delete Project");
            Console.Write("Select your option");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateProjectOption();
                    break;

                case "2":
                    await GetProjectsOption();
                    break;

                case "3":
                    await UpdateProjectOption();
                    break;

                case "4":
                    await DeleteProjectOption();
                    break;

                default:
                    break;
            }
        }
    }

    private async Task CreateProjectOption()
    {
        Console.Clear();
        Console.WriteLine("### Create Project ###");
        Console.Write("Title: #");
        var title = Console.ReadLine()!;

        Console.Write("Description: ");
        var description = Console.ReadLine();

        Console.Write("Start Date (yyyy-MM-dd): ");
        var startDate = DateTime.Parse(Console.ReadLine());

        Console.Write("End Date (yyyy-MM-dd): ");
        var endDate = DateTime.Parse(Console.ReadLine());

        var project = new ProjectRegistrationForm
        {
            Title = title,
            Description = description,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await _projectService.CreateProjectAsync(project);
        if (result)
        {
            Console.WriteLine("Project was created successfully");
        }
        else
        {
            Console.WriteLine("Project was not created");
        }

        Console.ReadKey();

    }
    private async Task GetProjectsOption()
    {
        Console.Clear();
        Console.WriteLine("### Projects ###");

        var projects = await _projectService.GetAllAsync();
        if(projects != null)
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.title} {project.description}");
            }
    }
    private async Task DeleteProjectOption()
    {
        Console.Clear();
        Console.WriteLine("### Delete Project ###");

        var existingProjects = await _projectService.GetAllAsync();
        if (existingProjects == null) 
            return;

    }

    private async Task UpdateProjectOption()
    {
        throw new NotImplementedException();
    }

   

   
}
