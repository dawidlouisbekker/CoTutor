
using Microsoft.Maui.Controls;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CoTutor
{
    public class AppShell : Shell
    {
        public AppShell()
        {
            Shell.SetTabBarIsVisible(this, true);
            //Shell.SetTabBarPlacement(this, TabBarPlacement.Top);
            //FlyoutBehavior = FlyoutBehavior.Disabled;
            //IsVisible = true;

            var tabBar = new TabBar();
            ShellContent Login = new ShellContent();

            var homeContent = new ShellContent
            {
                Title = "Home",
                ContentTemplate = new DataTemplate(typeof(Login)),
            };
            tabBar.Items.Add(homeContent);

            var chatsContent = new ShellContent
            {
                Title = "Chats",
                ContentTemplate = new DataTemplate(typeof(chats)),
            };
            tabBar.Items.Add(chatsContent);

            Items.Add(tabBar);

        }






    }
}

/*
public void RemoveTab(string title)
{
    // Find the TabBar in the Items collection
    foreach (var item in Items)
    {
        if (item is TabBar tabBar)
        {
            // Find the ShellContent with the specified title
            var shellContentToRemove = tabBar.Items.FirstOrDefault(sc => sc.Title == title);
            if (shellContentToRemove != null)
            {
                // Remove the ShellContent from the TabBar
                tabBar.Items.Remove(shellContentToRemove);
                break; // Exit the loop after removing
            }
        }
    }
} */