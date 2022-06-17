using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;
using GrpcService.Protos;

/* 1 */
//var input = new HelloRequest { Name = "Rafał" };
//using var channel = GrpcChannel.ForAddress("https://localhost:7188/");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(input);
//Console.WriteLine(reply.Message);

/* 2 */
using var channel = GrpcChannel.ForAddress("https://localhost:7188/");
var customerClint = new Customer.CustomerClient(channel);
var customerRequested = new CustomerLookupModel { UserId = 2 };
var reply = await customerClint.GetCustomerInfoAsync(customerRequested);
Console.WriteLine($"{reply.FirstName} {reply.LastName}");

/* 3 */
Console.WriteLine();
Console.WriteLine("New customer list");
Console.WriteLine();
using (var call = customerClint.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName} {currentCustomer.EmailAddress}");
    }
}

Console.ReadLine();