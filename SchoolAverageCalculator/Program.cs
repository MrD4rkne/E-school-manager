using SchoolAverageCalculator.Helpers;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Pages;
using Microsoft.Extensions.Configuration;

namespace SchoolAverageCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyApp.Initialize();
            MyApp.Navigation.GoTo(new MainPage());
        }

    }
}