using MediatR;
using MessageBoard.Application;
using MessageBoard.Application.Commands;
using MessageBoard.Application.DTOs;
using MessageBoard.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine($"Number of arguments: {args.Length}");
Console.WriteLine("Arguments:");
foreach (string arg in args)
{
    Console.WriteLine(arg);
}

IHostBuilder builder = Host.CreateDefaultBuilder(args);

// Create a Host for DI, config, logging, etc.
using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationLayer();

        //// Add other app services, DbContext, etc.
        //services.AddTransient<IMyService, MyService>();

    })
    .Build();

var mediator = host.Services.GetRequiredService<IMediator>();


Guid userId = await mediator.Send(new CreateUserCommand("Mr Test"));

UserDTO? userFromDb = await mediator.Send(new GetUserQuery(userId));

Console.WriteLine(userFromDb?.Name ?? "Not found");