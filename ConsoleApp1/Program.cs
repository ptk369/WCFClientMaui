using Dw.WcfService;
using System.ServiceModel;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var wcfClient = new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpBinding_IService,
    new EndpointAddress("http://192.168.6.36:63489/Service.svc"));

var s = wcfClient.GetData(100);

Console.WriteLine(s);

