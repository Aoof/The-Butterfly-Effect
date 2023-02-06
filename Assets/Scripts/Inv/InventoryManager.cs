using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> itemsHeld = new List<GameObject>();
    public GameObject ItemUI;
    public GameObject inventoryPanel;

    public ScriptableObject[] AllItems;

    private int[] counts = {0, 0};
    private List<GameObject> existingTransforms = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        UpdateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (counts[0] != counts[1])
            UpdateInventoryUI();
    }

    public void Add(Item item) 
    {
        GameObject itemObject = new GameObject(item.itemName);
        ItemObjectTracker iot = itemObject.AddComponent<ItemObjectTracker>();
        iot.itemName = item.itemName;
        iot.icon = item.icon;
        iot.quantity = item.quantity;
        iot.price = item.price;
        iot.id = item.id;

        itemObject.transform.SetParent(transform);
        foreach (GameObject itemHeld in itemsHeld)
        {
            var thing = itemHeld.GetComponent<ItemObjectTracker>();
            if (item.itemName == thing.itemName)
            {
                thing.quantity += 1;
                Destroy(itemObject);
                return;
            }
        }
        counts[0] += 1;
        itemsHeld.Add(itemObject);
    }

    public void UpdateInventoryUI()
    {
        foreach (GameObject item in existingTransforms)
            Destroy(item);

        counts[1] = 0;
        
        int i = 0;
        foreach (GameObject item in itemsHeld)
        {
            GameObject itemUI = Instantiate(ItemUI);
            itemUI.transform.SetParent(inventoryPanel.transform);

            ItemObjectTracker iot = item.GetComponent<ItemObjectTracker>();

            Vector2 pos = new Vector2(10+(10 * i), -15 + (-15 * Mathf.Floor(i / 6f)));
            RectTransform rectTransform = itemUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = pos;
            rectTransform.localScale = new Vector3(1, 1, 0);
            TMPro.TextMeshProUGUI[] texts = itemUI.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
            texts[0].text = iot.quantity.ToString();
            texts[1].text = iot.itemName;
            itemUI.GetComponent<Image>().sprite = iot.icon;

            existingTransforms.Add(itemUI);
            counts[1] += 1;
            i += 1;
        }
    }


    public void Remove(Item item)
    {
        foreach (GameObject itemHeld in itemsHeld)
        {
            var thing = itemHeld.GetComponent<ItemObjectTracker>();
            if (item.id == thing.id)
            {
                counts[0] -= 1;
                itemsHeld.Remove(itemHeld);
                Destroy(itemHeld);
                return;
            }
        }
    }

    public void Trade(int[] stuffToTrade, int result)
    {

        Item item = null;
        foreach (Item _item in AllItems)
        {
            foreach (int id in stuffToTrade)
            {
                if (_item.id == id)
                    Remove(_item);
            }
            if (_item.id == result)
                item = _item;
        }
        if (item == null)
            return;
        switch (result)
        {
            case 10:
                Add(item);
                break;
        }
    }
}
