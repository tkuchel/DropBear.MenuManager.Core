# MenuManager 

MenuManager is a .NET library that provides an easy-to-use console menu system using Spectre.Console. 

## Features 

- Easy-to-use console menu system
- Supports multiple levels of menus
- Supports custom menu items
- Supports custom menu item actions
  
## Installation 

You can add MenuManager to your project by using the NuGet package manager in Visual Studio, or by using the `dotnet add package` command in the .NET CLI: 

```bash 
dotnet add package DropBear.MenuManager.Core 
``` 

## Usage 

First, register the MenuManager services in your `Startup.cs` file: 

```csharp 
public void ConfigureServices(IServiceCollection services) 
{ 
    // Other service configuration... 

    services.AddMenuManager(); 
} 
``` 

Then, you can inject and use `IMenuManager` in your classes: 

```csharp 
public class MyClass 
{ 
    private readonly IMenuManager _MenuManager; 

    public MyClass(IMenuManager MenuManager) 
    { 
        _MenuManager = MenuManager; 
    } 

    public static void Action1()
    {
        Console.WriteLine("Action 1 was triggered!");
    }

    public static void Action2()
    {
        Console.WriteLine("Action 2 was triggered!");
    }

    public static void SubmenuAction()
    {
        Console.WriteLine("Submenu action was triggered!");
    }

    public static void Main(string[] args)
    {
        MenuItem root = new MenuItem("root", "Main Menu");
        MenuItem item1 = new MenuItem("option1", "Option 1", Action1);
        MenuItem item2 = new MenuItem("option2", "Option 2", Action2);
        MenuItem submenu = new MenuItem("submenu1", "Submenu");
        MenuItem submenuItem = new MenuItem("suboption1", "Submenu Option", SubmenuAction);

        // Add the submenu item to the submenu
        submenu.AddSubmenu(submenuItem);

        // Add the items to the root menu
        root.AddSubmenu(item1);
        root.AddSubmenu(item2);
        root.AddSubmenu(submenu);

        MenuManager manager = new MenuManager(root);
        manager.Start();
    }
} 
``` 

## Documentation 

For more detailed documentation, please see the official documentation. 

## Contributing 

We welcome contributions! Please see our contributing guide for details. 

## License 

MenuManager is licensed under the MIT License. 
