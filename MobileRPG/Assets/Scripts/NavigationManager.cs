using UnityEngine;
using System.Collections.Generic;

public static class NavigationManager
{
    // A static list of possible destinations in the game
    // knows everywhere you can travel in the game
    public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
    {
        {"World", "the big bad world"},
        {"Cave", "the deep dark cave"},
    };

    /// <summary>
    /// Used to Interrogate the destination list
    /// </summary>
    /// <param name="destination"></param>
    /// <returns>Returns the text to display in the prompt</returns>
    /// Note: This can be used to create a navigation link, which can route the player depending on
    /// INVENTORY items or other conditions
    public static string GetRouteInformation(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
    }

    // Will complete later
    /// <summary>
    /// Limits the players travel based on their current destination
    /// </summary>
    /// <param name="destination">The target destination</param>
    /// <returns>Return if the player is able to travel to a destination</returns>
    public static bool CanNavigate(string destination)
    {
        return true;
    }

    /// <summary>
    /// Instigates navigation. Controls the exact things that happen when the player travels.
    /// </summary>
    /// <param name="destination">The destination that the player will travel to</param>
    public static void NavigateTo(string destination)
    {
        // Fill in later
        // SceneManager.LoadLevel(destination);
    }
}
