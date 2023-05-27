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
        /// Show page - Draw() (and Prepare() if it is it's first appearance with this data)
        /// </summary>
        /// <param name="page"></param>
        /// <param name="first"></param>
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
        /// <summary>
        /// Navigate backwards, take last Page from Stack
        /// </summary>
        public void GoBack()
        {
            if (NavigationStack.Count > 1) {
                NavigationStack.Pop();
                CollapseRoute();
            }
            ShowPage(NavigationStack.Peek(), false);
        }
        /// <summary>
        /// Refresh page - (Re) Draw() without Prepare()
        /// </summary>
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
