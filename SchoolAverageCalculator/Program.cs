using SchoolAverageCalculator.Helpers;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.Domain.Entity;
using SchoolAverageCalculator.Pages;

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