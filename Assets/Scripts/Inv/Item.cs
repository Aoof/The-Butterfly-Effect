using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int quantity;
    public Sprite icon;
    public int price;
}
