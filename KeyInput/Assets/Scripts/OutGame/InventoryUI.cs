using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemCategoryTypes
{
    None, Weapon, Armor, Shoes, Helmet, Food, Material, CategoryMax
}

public struct ItemData
{
    public ItemCategoryTypes itemType;
    public string itemName;
    public int itemCount;
}
public class InventoryUI : MonoBehaviour
{
    public InventoryCategorySlot categorySlotOrigin;
    public Transform trCategoryLayout;
    public ItemCategoryTypes currentCategory = ItemCategoryTypes.Weapon;
    public ScrollRect itemScrollView;
    public List<ItemData> itemDatas = new List<ItemData>();
    public InventoryItemSlot itemSlotOrigin;
    private void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            ItemData data = new ItemData();
            data.itemCount = Random.Range(1, 100);
            data.itemType = ItemCategoryTypes.Weapon;
            data.itemName = ItemCategoryTypes.Weapon.ToString() + i.ToString();
            itemDatas.Add(data);
        }
        Initialize();
    }
    public void Initialize()
    {
        categorySlotOrigin.gameObject.SetActive(true);
        for(int index = 1; index < (int)ItemCategoryTypes.CategoryMax; index++)
        {
            InventoryCategorySlot newSlot = Instantiate(categorySlotOrigin, trCategoryLayout);
            newSlot.Init((ItemCategoryTypes)index);
        }
        categorySlotOrigin.gameObject.SetActive(false);

        itemSlotOrigin.gameObject.SetActive(true);
        for(int index = 0; index < itemDatas.Count; index++)
        {
            InventoryItemSlot newSlot = Instantiate(itemSlotOrigin, itemScrollView.content.transform);
            newSlot.Init(itemDatas[index].itemName, itemDatas[index].itemCount);
        }
        itemSlotOrigin.gameObject.SetActive(false);
    }
}
