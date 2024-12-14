var builder = DistributedApplication.CreateBuilder(args);

var rabbitMq = builder.AddRabbitMQ("healthy-rabbit-mq")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithManagementPlugin()
    .WithDataVolume();

var postgres = builder.AddPostgres("healthy-postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin()
    .WithDataVolume();

postgres.AddDatabase("healthy-db");

builder.AddProject<Projects.Healthy_Presentation_DevicesApi>("healthy-devices-api")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq);

builder.AddProject<Projects.Healthy_Presentation_UsersApi>("healthy-users-api")
    .WithReference(postgres)
    .WaitFor(postgres);

builder.AddProject<Projects.Healthy_Presentation_Worker>("healthy-worker")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq)
    .WithReference(postgres)
    .WaitFor(postgres);

builder.Build().Run();
