using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemCategoryTypes
{
    None, Weapon, Armor, Shoes, Helmet, Food, Material, CategoryMax
}
//아이템 카테고리별로 페이징이 되도록 만들어야함.
//itemDatas.FindAll 이라는 함수를 사용하면 쉽게 구현 가능;
//FindAll을 통하여 얻은 정보를 itemSlots에 적용하면 된다.
//currentCategory값을 이용해야 한다.
//카테고리 버튼을 눌렀을때 요 내용들이 수행되어야 한다.





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
    public List<InventoryItemSlot> itemSlots = new List<InventoryItemSlot>();
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
        for (int i = 0; i < 30; i++)
        {
            ItemData data = new ItemData();
            data.itemCount = Random.Range(1, 100);
            data.itemType = ItemCategoryTypes.Armor;
            data.itemName = ItemCategoryTypes.Armor.ToString() + i.ToString();
            itemDatas.Add(data);
        }
        for (int i = 0; i < 10; i++)
        {
            ItemData data = new ItemData();
            data.itemCount = Random.Range(1, 100);
            data.itemType = ItemCategoryTypes.Shoes;
            data.itemName = ItemCategoryTypes.Shoes.ToString() + i.ToString();
            itemDatas.Add(data);
        }
        for (int i = 0; i < 20; i++)
        {
            ItemData data = new ItemData();
            data.itemCount = Random.Range(1, 100);
            data.itemType = ItemCategoryTypes.Helmet;
            data.itemName = ItemCategoryTypes.Helmet.ToString() + i.ToString();
            itemDatas.Add(data);
        }
        for (int i = 0; i < 70; i++)
        {
            ItemData data = new ItemData();
            data.itemCount = Random.Range(1, 100);
            data.itemType = ItemCategoryTypes.Food;
            data.itemName = ItemCategoryTypes.Food.ToString() + i.ToString();
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
            itemSlots.Add(newSlot);
        }        
        itemSlotOrigin.gameObject.SetActive(false);
    }
}
