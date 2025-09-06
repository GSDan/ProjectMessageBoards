using MediatR;
using MessageBoard.Application;
using MessageBoard.Application.Commands;
using MessageBoard.Application.DTOs;
using MessageBoard.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

Console.WriteLine($"Number of arguments: {args.Length}");
Console.WriteLine("Arguments:");
foreach (string arg in args)
{
    Console.WriteLine(arg);
}

IHostBuilder builder = Host.CreateDefaultBuilder(args);

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddApplication();
    })
    .Build();

var mediator = host.Services.GetRequiredService<IMediator>();

string? input = null;
while (input != "exit")
{
    input = Console.ReadLine();
    if (input != "exit")
    {
        await HandleCommand(input);
    }
}


async Task HandleCommand(string? command)
{
    if (string.IsNullOrWhiteSpace(command)) return;

    if (command.Contains("->"))
    {
        // Posting a new message
        // Example command format: "Alice -> @Moonshot I'm working on the log on screen"

        string pattern = @"^(\w+)\s*->\s*(@\w+)\s*(.+)$";
        Match match = Regex.Match(input, pattern);

        if (match.Success)
        {
            CreatePostCommand createPostCommand = new(
                Username: match.Groups[1].Value,
                ProjectName: match.Groups[2].Value,
                Message: match.Groups[3].Value);

            CommandResult<PostDTO> result = await mediator.Send(createPostCommand);

            if (!result.Success)
            {
                Console.WriteLine(result.Error);
            }
        }

    }
    else if (command.Contains("follows"))
    {
        // subscribe user to project
    }
    else if (command.Contains("wall"))
    {
        // view all posts for all the user's projects, oldest first
    }
    else
    {
        // read a project
    }
}

UserDTO? userFromDb = await mediator.Send(new GetUserQuery("Alice"));

Console.WriteLine($"{userFromDb?.Name} ");