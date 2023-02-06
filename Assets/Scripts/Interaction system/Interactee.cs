using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactee : MonoBehaviour
{

    /*
    # Interaction ids breakdown :-
    # 0: Nothing.
    # 1: Dropped item (Add to inventory)
    # 2: NPC (Dialog Special Interaction)
    */

    public Item itemDrop;
    public int interactionId = 0;
    public GameObject whoInteracts;

    private void Start()
    {
        whoInteracts = GameObject.FindGameObjectWithTag("Player");
    }

    public void Action()
    {
        switch (interactionId)
        {
            case 1:
                whoInteracts.GetComponentInChildren<InventoryManager>().Add(itemDrop);
                whoInteracts.GetComponentInChildren<InventoryManager>().UpdateInventoryUI();
                Destroy(gameObject);
                break;
            case 4:
                InventoryManager iM = whoInteracts.GetComponent<InventoryManager>();
                bool[] hasBoth = { false, false };
                foreach (GameObject item in iM.itemsHeld)
                {
                    ItemObjectTracker iot = item.GetComponent<ItemObjectTracker>();
                    if (iot.id == 4) // Stick
                        hasBoth[0] = true;

                    if (iot.id == 6) // Stone
                        hasBoth[1] = true;
                }

                if (hasBoth[0] && hasBoth[1])
                    iM.Trade(new int[] { 4, 6 }, 10);
                break;
            case 5:
                SceneManager.LoadScene("Cave", LoadSceneMode.Single);
                break;
            case 6:
                SceneManager.LoadScene("PreHistoric", LoadSceneMode.Single);
                break;
            default:
                break;
        }
    }
}