using SchoolAverageCalculator.App.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Concrete
{
    public class NavigationService
    {
        private Stack<BasePage> NavigationStack = new Stack<BasePage>();
        /// <summary>
        /// Navigate to page
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

        private void ShowPage(BasePage page, bool first = true)
        {
            Console.Title = GetFullRoute();
            if (first)
            {
                if (page.Prepare())
                    page.Draw();
            }
            else
                page.Draw();
        }

        public void GoBack()
        {
            if (NavigationStack.Count > 1) {
                NavigationStack.Pop();
                CollapseRoute();
            }
            ShowPage(NavigationStack.Peek(), false);
        }
        public void RefreshPage()
        {
            ShowPage(NavigationStack.Peek(), false);
        }
    

        private List<string> _routes = new();
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
        /// Add lastest page
        /// </summary>
        /// <param name="endPoint"></param>
        private void ExpandRoute(string endPoint)
        {
            _routes.Add(endPoint);
        }
        /// <summary>
        /// Remove latest page
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
