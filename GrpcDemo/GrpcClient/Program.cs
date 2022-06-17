using Grpc.Net.Client;
using GrpcService;
using GrpcService.Protos;

//var input = new HelloRequest { Name = "Rafał" };
//using var channel = GrpcChannel.ForAddress("https://localhost:7188/");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(input);
//Console.WriteLine(reply.Message);

using var channel = GrpcChannel.ForAddress("https://localhost:7188/");
var customerClint = new Customer.CustomerClient(channel);
var customerRequested = new CustomerLookupModel { UserId = 2 };
var reply = await customerClint.GetCustomerInfoAsync(customerRequested);

Console.WriteLine($"{reply.FirstName} {reply.LastName}");
Console.ReadLine();