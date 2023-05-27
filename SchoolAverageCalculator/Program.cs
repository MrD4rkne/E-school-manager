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


        //static void Main(string[] args)
        //{
        //    MenuService menuHelper = new MenuService();
        //    MarksService marksService = new MarksService();
        //    CreateMenus(menuHelper);

        //    while (true)
        //    {
        //        switch (DrawManager.DrawMenu("Welcome to Average Calculator!", menuHelper,"Main"))
        //        {
        //            case 1:
        //                // summary
        //                DrawSummary(marksService, menuHelper);
        //                break;
        //            case 2:
        //                AddMark(marksService, menuHelper);
        //                break;
        //            case 3:
        //                ManageMark(marksService, menuHelper);
        //                break;
        //            case 4:
        //                Console.WriteLine();
        //                Console.WriteLine("Have a nice day!");
        //                InputManager.WaitForAnyKey("Press any key to proceed...");
        //                break;
        //        }
        //    }
        //}


        //static void DrawSummary(MarksService marksService, MenuService menuHelper)
        //{
        //    Console.WriteLine();
        //    var marks = marksService.Items;
        //    Console.WriteLine($"Average: {Math.Round(marksService.CountAverage(), 2)}");
        //    Console.WriteLine("Your marks:");
        //    Console.WriteLine("Value    Weight");

        //    foreach (var mark in marks)
        //    {
        //        Console.WriteLine($"{mark.Value} {mark.Weight}");
        //    }
        //    Console.WriteLine();
        //    InputManager.WaitForAnyKey();
        //}

        //static void AddMark(MarksService marksService, MenuService menuHelper)
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("Enter mark properties:");
        //    Mark markToAdd = new Mark(InputManager.GetDecimalInput("Value: "), InputManager.GetDecimalInput("Weight: "), InputManager.GetTextInput("Description (optional): ", true));
        //    int rows = marksService.AddItem(markToAdd);
        //    Console.WriteLine();
        //    Console.WriteLine("Success!");

        //    Console.WriteLine();
        //    InputManager.WaitForAnyKey();
        //}

        //static void ManageMark(MarksService marksService, MenuService menuHelper)
        //{
        //    Console.WriteLine();

        //    var marks = marksService.Items;

        //    if (marks == null || marks.Count == 0)
        //    {
        //        Console.WriteLine("There are not any marks!");
        //        InputManager.WaitForAnyKey();
        //        return;
        //    }


        //    int choice = DrawManager.DrawMenu("Choose mark: ", marks.Select(x => $"{x.Value} {x.Weight} {x.Description}").ToArray());

        //    Mark mark = marks.ElementAtOrDefault(choice - 1);
        //    if (mark == null)
        //    {
        //        Console.WriteLine("Error occured");
        //        return;
        //    }

        //    int action = DrawManager.DrawMenu("Choose what to do: ", menuHelper,"ManageMark");
        //    switch (action)
        //    {
        //        case 1:
        //            EditMark(mark, menuHelper);
        //            break;
        //        case 2:
        //            bool confirm = DrawManager.DrawMenu("Are you sure you want to delete this mark? ", menuHelper, "ConfirmAction") == 1;
        //            if (confirm)
        //                marksService.RemoveItem(mark.Id);
        //            return;
        //        case 3:
        //            return;
        //    }
        //}

        //static void PrintMark(Mark mark)
        //{
        //    Console.WriteLine($"Value: {mark.Value}");
        //    Console.WriteLine($"Weight: {mark.Weight}");
        //    Console.WriteLine($"Description: {mark.Description}");
        //}

        //static void EditMark(Mark mark, MenuService menuHelper)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine();

        //        PrintMark(mark);

        //        int property = DrawManager.DrawMenu("Choose what to edit: ", menuHelper, "EditMark");

        //        Console.WriteLine();

        //        switch (property)
        //        {
        //            case 1:
        //                mark.Value = InputManager.GetDecimalInput("New value: ");
        //                break;
        //            case 2:
        //                mark.Weight = InputManager.GetDecimalInput("New weight: ");
        //                break;
        //            case 3:
        //                mark.Description = InputManager.GetTextInput("New description: ", true);
        //                break;
        //            case 4:
        //                return;
        //        }
        //    }

        //}
        //static void CreateMenus(MenuService menuHelper)
        //{
        //    // Main
        //    menuHelper.AddItem(new MenuItem() { Id = 0, MenuTitle = "Main", Title = "See summary" });
        //    menuHelper.AddItem(new MenuItem() { Id = 1, MenuTitle = "Main", Title = "Add new mark" });
        //    menuHelper.AddItem(new MenuItem() { Id = 2, MenuTitle = "Main", Title = "Manage existing marks" });
        //    menuHelper.AddItem(new MenuItem() { Id = 3, MenuTitle = "Main", Title = "Close app" });

        //    // Summary
        //    menuHelper.AddItem(new MenuItem() { Id = 4, MenuTitle = "Summary", Title = "Return" });

        //    // Adding new mark
        //    menuHelper.AddItem(new MenuItem() { Id = 5, MenuTitle = "AddNew", Title = "Return" });

        //    // Managing mark
        //    menuHelper.AddItem(new MenuItem() { Id = 6, MenuTitle = "ManageMark", Title = "Edit" });
        //    menuHelper.AddItem(new MenuItem() { Id = 7, MenuTitle = "ManageMark", Title = "Delete" });
        //    menuHelper.AddItem(new MenuItem() { Id = 8, MenuTitle = "ManageMark", Title = "Return" });

        //    // confirmation
        //    menuHelper.AddItem(new MenuItem() { Id = 9, MenuTitle = "ConfirmAction", Title = "Yes" });
        //    menuHelper.AddItem(new MenuItem() { Id = 10, MenuTitle = "ConfirmAction", Title = "No" });

        //    // Managing Mark Edit
        //    menuHelper.AddItem(new MenuItem() { Id = 11, MenuTitle = "EditMark", Title = "Value" });
        //    menuHelper.AddItem(new MenuItem() { Id = 12, MenuTitle = "EditMark", Title = "Weight" });
        //    menuHelper.AddItem(new MenuItem() { Id = 13, MenuTitle = "EditMark", Title = "Description" });
        //    menuHelper.AddItem(new MenuItem() { Id = 14, MenuTitle = "EditMark", Title = "Return" });
        //}

    }
}