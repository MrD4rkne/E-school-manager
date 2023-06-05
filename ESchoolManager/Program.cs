using ESchoolManager.Helpers;
using ESchoolManager.App.Concrete;
using ESchoolManager.Domain.Entity;
using ESchoolManager.Pages;

namespace ESchoolManager
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