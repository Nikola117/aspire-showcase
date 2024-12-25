using YamlDotNet.Serialization;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("sql-server")
    .WithLifetime(ContainerLifetime.Persistent);

var catalogdb = sqlServer.AddDatabase("catalogdb");

var server = builder.AddProject<Projects.AspireShowcase_Server>("aspireshowcase-server")
    .WithReference(catalogdb)
    .WaitFor(catalogdb);

builder.AddProject<Projects.AspireShowcase_Client>("aspireshowcase-client")
    .WithExternalHttpEndpoints()
    .WithReference(server)
    .WaitFor(server);

builder.Build().Run();
