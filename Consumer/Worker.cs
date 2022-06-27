using Microsoft.Extensions.Hosting;

internal class Worker : BackgroundService
{
    private readonly Consumer consumer;

    public Worker(Consumer consumer)
    {
        this.consumer = consumer;
        //inject consumer
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //consumer logic
        Console.WriteLine("Message from background service");
        return Task.CompletedTask;
    }
}