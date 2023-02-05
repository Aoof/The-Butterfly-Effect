using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("InteractionController loaded");
    }

    void OnCollided(GameObject collision)
    {
        Debug.Log("Interacted with " + collision.name);
        switch (collision.name)
        {
            case "Pebble":
                collision.GetComponent<Interactee>().ShowInteractionPrompt(gameObject);
                Debug.Log("Interacted with Pebble");
                break;
            default:
                break;
        }
    }
}
