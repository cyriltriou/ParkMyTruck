using System;
using System.Collections.Generic;
using System.Text;

namespace ParkMyTruck.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        CurrentPosition,
        Scanner
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
