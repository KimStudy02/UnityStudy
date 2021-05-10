using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public Text itemNameText;
    public Text countText;
    public void Init(string itemName, int count)
    {
        itemNameText.text = itemName;
        countText.text = count.ToString();
    }

}
