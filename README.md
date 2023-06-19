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

    public async Task MyMethod() 
    { 
        // Use the cache manager 
        bool exists = await _MenuManager.ExistsInMemoryCache("myKey"); 
        // Other code... 
    } 
} 
``` 

## Documentation 

For more detailed documentation, please see the official documentation. 

## Contributing 

We welcome contributions! Please see our contributing guide for details. 

## License 

MenuManager is licensed under the MIT License. 
