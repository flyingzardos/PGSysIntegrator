using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGSysIntegrator.Application.Models;

namespace PGSysIntegrator.Infrastructure.Helpers
{
    public class SortingHelper
    {
        //public  void BubbleSort<T>(this List<T> list, Func<T, int> selector)
        //{
        //    while (true)
        //    {
        //        bool changed = false;
        //        for (int i = 1; i < list.Count; i++)
        //        {
        //            if (selector(list[i - 1]) > selector(list[i]))
        //            {
        //                T temp = list[i - 1];
        //                list[i - 1] = list[i];
        //                list[i] = temp;
        //                changed = true;
        //            }
        //        }

        //        if (!changed)
        //            break;
        //    }
        //}

        public List<MaximoLocationMember> BubbleSortByChildLocations(List<MaximoLocationMember> list)
        {
            while (true) // keep going through the list until there are no more parents below children
            {
                bool changed = false;
                for (int i = 1; i < list.Count; i++)
                {
                    // just to make sure this is not a root node OR the location is is empty
                    if(string.IsNullOrEmpty(list[i].LocationHierarchy.ParentName) || string.IsNullOrEmpty(list[i - 1].Location))
                        // if the previous member is a parent to the current member
                        if (list[i - 1].Location.Contains(list[i].LocationHierarchy.ParentName) )
                        {
                            MaximoLocationMember temp = new MaximoLocationMember();
                            temp.LocationHierarchy = new Parent();
                            // set the previous member in a temp location
                            temp = list[i - 1];
                            // move the current member into the previous member's spot
                            list[i - 1] = list[i];
                            // move the previous member into the position before it (member bubbled up)
                            list[i] = temp;
                            changed = true;
                        }
                }

                if (!changed)
                    break;
            }

            return list;
        }

        public List<MaximoLocationMember> BubbleSortByParentLocations(List<MaximoLocationMember> list)
        {
            while (true) // keep going through the list until there are no more parents below children
            {
                bool changed = false;
                for (int i = 1; i < list.Count; i++)
                {
                    // just to make sure this is not a root node OR the location is is empty
                    if(string.IsNullOrEmpty(list[i].LocationHierarchy.ParentName) || string.IsNullOrEmpty(list[i + 1].Location))
                        // if the next member is a parent to the current member
                        if (list[i].LocationHierarchy.ParentName.Contains(list[i + 1].Location) )
                        {
                            MaximoLocationMember temp = new MaximoLocationMember();
                            temp.LocationHierarchy = new Parent();
                            // set the next member in a temp location
                            temp = list[i + 1];
                            // move the current member into the previous member's spot
                            list[i + 1] = list[i];
                            // move the previous member into the position before it (member bubbled up)
                            list[i] = temp;
                            changed = true;
                        }
                }

                if (!changed)
                    break;
            }
            return list;
        }
    }
}
