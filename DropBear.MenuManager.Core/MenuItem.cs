namespace DropBear.MenuManager.Core;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents an item in a menu.
/// </summary>
public class MenuItem
{
    /// <summary>
    /// Gets or sets the identifier of the menu item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the menu item. This is displayed as the text for the menu choice.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the action to be executed when the menu item is selected.
    /// </summary>
    public Action Action { get; set; }

    /// <summary>
    /// Gets the submenu of the menu item.
    /// </summary>
    public List<MenuItem> Submenu { get; private set; }

    /// <summary>
    /// Gets or sets the parent menu item of this menu item.
    /// </summary>
    public MenuItem Parent { get; set; }

    /// <summary>
    /// Initializes a new instance of the MenuItem class with the specified name, description, and action.
    /// </summary>
    /// <param name="name">The identifier of the menu item.</param>
    /// <param name="description">The description of the menu item. This is displayed as the text for the menu choice.</param>
    /// <param name="action">The action to be executed when the menu item is selected.</param>
    public MenuItem(string name, string description, Action action = null)
    {
        Name = name;
        Description = description;
        Action = action;
        Submenu = new List<MenuItem>();
    }

    /// <summary>
    /// Adds a menu item to the submenu.
    /// </summary>
    /// <param name="item">The menu item to add.</param>
    public void AddSubmenu(MenuItem item)
    {
        try
        {
            item.Parent = this;
            Submenu.Add(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding submenu: {ex.Message}");
        }
    }

    /// <summary>
    /// Removes a menu item from the submenu.
    /// </summary>
    /// <param name="item">The menu item to remove.</param>
    public void RemoveSubmenu(MenuItem item)
    {
        try
        {
            Submenu.Remove(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing submenu: {ex.Message}");
        }
    }
}
