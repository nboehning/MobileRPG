using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NavigationPrompt : MonoBehaviour
{
    public GameObject travelContainer;

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(NavigationManager.CanNavigate(tag))
        {
            travelContainer.SetActive(other.gameObject.CompareTag("Player"));
            travelContainer.GetComponentInChildren<Text>().text = "Do you want to travel to " + NavigationManager.GetRouteInformation(tag) + "?";
            Destination.instance.loadDestination = gameObject.tag;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            travelContainer.SetActive(false);
        }
    }
}
