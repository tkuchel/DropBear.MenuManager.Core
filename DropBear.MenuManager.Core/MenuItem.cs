namespace DropBear.MenuManager.Core;

using System;
using System.Collections.Generic;

public class MenuItem
{
    public string Name { get; set; }
    public Action Action { get; set; }
    public List<MenuItem> Submenu { get; set; }
    public MenuItem Parent { get; set; }

    public MenuItem(string name, Action action = null)
    {
        Name = name;
        Action = action;
        Submenu = new List<MenuItem>();
    }

    public void AddSubmenu(MenuItem item)
    {
        item.Parent = this;
        Submenu.Add(item);
    }

    public void RemoveSubmenu(MenuItem item)
    {
        Submenu.Remove(item);
    }
}

