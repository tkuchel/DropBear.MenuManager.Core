namespace DropBear.MenuManager.Core;

using Spectre.Console;
using System.Collections.Generic;

public class MenuManager
{
    private MenuItem RootMenu { get; set; }
    private MenuItem CurrentMenu { get; set; }

    public MenuManager(MenuItem rootMenu)
    {
        RootMenu = rootMenu;
        CurrentMenu = rootMenu;
    }

    public void AddMenuItem(MenuItem parent, MenuItem child)
    {
        parent.AddSubmenu(child);
    }

    public void RemoveMenuItem(MenuItem parent, MenuItem child)
    {
        parent.RemoveSubmenu(child);
    }

    public void Start()
    {
        while (true)
        {
            var prompt = new SelectionPrompt<string>().Title("Please select an option:");

            foreach (var item in CurrentMenu.Submenu)
            {
                prompt.AddChoices(item.Name);
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

            var selectedOption = CurrentMenu.Submenu.Find(item => item.Name == result);

            if (selectedOption != null && selectedOption.Submenu.Count > 0)
            {
                CurrentMenu = selectedOption;
            }
            else
            {
                if (selectedOption?.Action != null)
                {
                    selectedOption.Action.Invoke();
                }
            }
        }
    }
}
