using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsController : MonoBehaviour
{
    public GameObject interactPrompt;
    public Vector3 promptLocation;
    private GameObject interactedWith;

    private GameObject promptGO;
    // Start is called before the first frame update
    void Start()
    {
        promptGO = Instantiate(interactPrompt);
        promptGO.transform.SetParent(GameObject.Find("Canvas").transform);

        promptGO.transform.position = new Vector3 (Screen.width/2.0f, promptLocation.y, promptLocation.z);
        promptGO.transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactedWith != null)
        {
            Interactee interactee = interactedWith.GetComponent<Interactee>();
            if (interactee)
                interactee.Action();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Interactee interactee = collision.gameObject.GetComponent<Interactee>();
        if (interactee)
        {
            promptGO.SetActive(true);
            interactedWith = collision.gameObject;
            promptGO.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "[E] Interact with " + interactedWith.GetComponent<SpriteRenderer>().sprite.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Interactee interactee = collision.gameObject.GetComponent<Interactee>();
        if (interactee)
        { 
            promptGO.SetActive(false);
            if (collision.gameObject == interactedWith)
                interactedWith = null;
        }
    }
}
