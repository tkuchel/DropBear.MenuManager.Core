namespace DropBear.MenuManager.Core;

using Spectre.Console;
using System;
using System.Collections.Generic;

/// <summary>
/// Class responsible for managing menus and maintaining the main loop of the program.
/// </summary>
public class MenuManager
{
    /// <summary>
    /// The root menu of the application.
    /// </summary>
    private MenuItem RootMenu { get; set; }

    /// <summary>
    /// The currently active menu.
    /// </summary>
    private MenuItem CurrentMenu { get; set; }

    /// <summary>
    /// Initializes a new instance of the MenuManager class with the specified root menu.
    /// </summary>
    /// <param name="rootMenu">The root menu of the application.</param>
    public MenuManager(MenuItem rootMenu)
    {
        RootMenu = rootMenu;
        CurrentMenu = rootMenu;
    }

    /// <summary>
    /// Adds a child menu item to a parent menu item.
    /// </summary>
    /// <param name="parent">The parent menu item.</param>
    /// <param name="child">The child menu item to add.</param>
    public void AddMenuItem(MenuItem parent, MenuItem child)
    {
        try
        {
            parent.AddSubmenu(child);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
        }
    }

    /// <summary>
    /// Removes a child menu item from a parent menu item.
    /// </summary>
    /// <param name="parent">The parent menu item.</param>
    /// <param name="child">The child menu item to remove.</param>
    public void RemoveMenuItem(MenuItem parent, MenuItem child)
    {
        try
        {
            parent.RemoveSubmenu(child);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
        }
    }

    /// <summary>
    /// Starts the menu loop.
    /// </summary>
    public void Start()
    {
        while (true)
        {
            try
            {
                var prompt = new SelectionPrompt<string>().Title("Please select an option:");

                foreach (var item in CurrentMenu.Submenu)
                {
                    prompt.AddChoices(item.Description);
                }

                if (CurrentMenu != RootMenu)
                {
                    prompt.AddChoice("Back");
                }

                var result = AnsiConsole.Prompt(prompt);

                if (result == "Back")
                {
                    CurrentMenu = CurrentMenu.Parent;
                    continue;
                }

                var selectedOption = CurrentMenu.Submenu.Find(item => item.Description == result);

                if (selectedOption.Submenu.Count > 0)
                {
                    CurrentMenu = selectedOption;
                }
                else
                {
                    selectedOption.Action?.Invoke();
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.WriteException(ex);
            }
        }
    }
}
