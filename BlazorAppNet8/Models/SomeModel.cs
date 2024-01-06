using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;

namespace BlazorAppNet8.Models
{


    public class SomeModel 
    {
        public SomeModel() {
            Console.WriteLine("SomeModel Init");

            ConstructorSetProperty = "I was created on construction ";

        }


        public string? ConstructorSetProperty { get; set; } 
        public string? InitSetProperty { get; set; }
        public string? LazySetProperty { get; set; }
        public int TimerSetProperty { get; set; }
        public string? ReactiveSetProperty { get; set; }

        



    }
}
