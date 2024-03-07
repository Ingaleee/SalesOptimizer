﻿using Microsoft.Extensions.DependencyInjection;
using OzonSales.ConsoleApp.Abstractions;

namespace OzonSales.ConsoleApp;

public class Program
{
    public static async Task Main()
    {
        var services = new ServiceCollection();
        var provider = services.BuildConsoleProvider();

        var inputHandler = provider.GetService<IInputHandler>();
        await inputHandler.HandleAsync();
    }
}