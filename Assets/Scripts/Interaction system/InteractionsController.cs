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

    void OnCollisionEnter2D(Collider2D collision)
    {
        Debug.Log("Interacted with " + collision.gameObject.name);
        switch (collision.gameObject.name)
        {
            case "Pebble":
                collision.gameObject.GetComponent<Interactee>().ShowInteractionPrompt(gameObject);
                Debug.Log("Interacted with Pebble");
                break;
            default:
                break;
        }
    }
}
