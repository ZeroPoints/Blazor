using BlazorAppNet8.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;

namespace BlazorAppNet8.Services
{


    public class SomeService : IDisposable
    {


        public SomeService()
        {
            Console.WriteLine("Service Init");
            SomeModel = new SomeModel();
            Background = Task.Run(TimerSetProperty_Timer);
        }


        public static Task Background { get; set; }


        private async Task TimerSetProperty_Timer()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            while (await timer.WaitForNextTickAsync())
            {
                SomeModel.TimerSetProperty++;
                //Wonder if i can get this to notify the Webpage to update view
                //await InvokeAsync(StateHasChanged);
            }
        }



        public SomeModel SomeModel { get; set; }




        public void Dispose()
        {
            try
            {
            }
            catch { }
        }





    }
}
