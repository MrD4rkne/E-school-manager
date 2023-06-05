using ESchoolManager.App.Abstract;
using ESchoolManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Concrete
{
    public class NavigationService
    {
        private Stack<BasePage> NavigationStack = new Stack<BasePage>();
        private List<string> _routes = new();

        /// <summary>
        /// Navigate to page and put it onto stack
        /// </summary>
        /// <param name="page"></param>
        public void GoTo(BasePage page)        
        {
            if (page == null)
                return;
            NavigationStack.Push(page);
            ExpandRoute(page.Title);
            ShowPage(page);
        }

        /// <summary>
        /// Navigate backwards, Pop Page from Stack
        /// </summary>
        public void GoBack(bool shouldReloadData = false)
        {
            if (NavigationStack.Count > 1)
            {
                NavigationStack.Pop();
                CollapseRoute();
            }
            ShowPage(NavigationStack.Peek(), shouldReloadData);
        }

        /// <summary>
        /// Show page - Draw() (and Prepare() if it there is need to load data)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="refreshData"></param>
        private void ShowPage(BasePage page, bool refreshData = true)
        {
            Console.Title = GetFullRoute();
            if (refreshData)
            {
                try
                {
                    if (page.Prepare())
                        page.Draw();
                }
                catch(InvalidDataException invEx) {
                    Console.Clear();
                    Console.WriteLine(invEx.Message);
                    InputManager.WaitForAnyKey();
                }             
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong :(");
                    Console.WriteLine(ex.Message);
                    InputManager.WaitForAnyKey();
                }
            }
            else
                page.Draw();
            GoBack();
        }

        /// <summary>
        /// Refresh page - (Re) Draw() without Prepare()
        /// </summary>
        public void RefreshPage(bool shouldReloadData = false)
        {
            ShowPage(NavigationStack.Peek(), shouldReloadData);
        }

        /// <summary>
        /// Get full route for current stack data
        /// </summary>
        /// <returns></returns>
        private string GetFullRoute()
        {
            if (_routes.Count == 0)
                return string.Empty;
            string ret = _routes.First()
                ;
            for(int i = 1; i< _routes.Count; i++)
            {
                ret += " => " + _routes[i];
            }
            return ret;
        }

        /// <summary>
        /// Add latest page to route
        /// </summary>
        /// <param name="endPoint"></param>
        private void ExpandRoute(string endPoint)
        {
            _routes.Add(endPoint);
        }

        /// <summary>
        /// Remove latest page from route
        /// </summary>
        private void CollapseRoute()
        {
            if (_routes.Count > 0)
            {
                _routes.RemoveAt(_routes.Count - 1);
            }
        }
    }
}
