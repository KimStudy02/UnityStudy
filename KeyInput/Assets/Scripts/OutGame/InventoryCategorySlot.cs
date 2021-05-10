﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCategorySlot : MonoBehaviour
{
    public ItemCategoryTypes slotType;
    public Text slotText;
    public Button slotButton;
    public void Init(ItemCategoryTypes type)
    {
        slotText.text = type.ToString();
    }
}
