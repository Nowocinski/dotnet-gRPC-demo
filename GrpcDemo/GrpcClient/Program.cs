using Grpc.Net.Client;
using GrpcService;

var input = new HelloRequest { Name = "Rafał" };
using var channel = GrpcChannel.ForAddress("https://localhost:7188/");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(input);
Console.WriteLine(reply.Message);
Console.ReadLine();