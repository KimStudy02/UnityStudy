using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 목표 : 아이템 카테고리별로 페이징이 되도록 만들어야함

// 힌트1. : itemDatas.FindAll 이라는 함수를 사용하면 쉽게 구현 가능;
//  => FindAll을 통하여 얻은 정보를 itemSlots에 적용하면 된다.
// 힌트2. : currentCategory값을 이용해야 한다.
//  => 카테고리 버튼을 눌렀을때 요 내용들이 수행되어야 한다.

public enum ItemCategoryTypes
{
    None, 

    Weapon,
    Armor,
    Shoes,
    Helmet,
    Food,
    Material, 

    CategoryMax
}

public struct ItemData
{
    public ItemCategoryTypes itemType;
    public string itemName;
    public int itemCount;
}

public class InventoryUI : UIBase
{
    public static InventoryUI Instance = null;

    public InventoryCategorySlot categorySlotOrigin;
    public Transform trCategoryLayout;
    public ItemCategoryTypes currentCategory = ItemCategoryTypes.Weapon;
    public ScrollRect itemScrollView;
    public InventoryItemSlot itemSlotOrigin;
    public List<InventoryItemSlot> itemSlots = new List<InventoryItemSlot>();

    // 아이템 데이터들...
    public List<ItemData> itemDatas = new List<ItemData>();

    private void Start()
    {
        Instance = this;

        // Category 버튼 생성
        categorySlotOrigin.gameObject.SetActive(true);
        for (int index = 1; index < (int)ItemCategoryTypes.CategoryMax; index++)
        {
            InventoryCategorySlot newSlot = Instantiate(categorySlotOrigin, trCategoryLayout);
            newSlot.Init((ItemCategoryTypes)index);
        }
        categorySlotOrigin.gameObject.SetActive(false);
        
        #region Dummy Data Add        
        for (int i = 0; i < 50; i++)
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
        #endregion

        // 처음엔 Weapon 페이지를 보여준다.
        SetInventoryPage(ItemCategoryTypes.Weapon);
    }

    public void OnClickCategoryButton(ItemCategoryTypes categoryType)
    {
        SetInventoryPage(categoryType);
    }

    public void SetInventoryPage(ItemCategoryTypes categoryType)
    {
        // 현재 생성 되어있는 인벤토리 슬롯을 모두 끈다!
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].gameObject.SetActive(false);
        }

        // 인벤토리에 보여질 아이템 카테고리에 맞추어 모든 타겟 데이터를 꺼낸다.
        List<ItemData> findDatas = itemDatas.FindAll(x => x.itemType == categoryType);

        // 혹시나, 인벤토리 슬롯이 보여줘야하는 데이터보다 작게 생성 되어있다면 추가 슬롯을 생성해준다.
        itemSlotOrigin.gameObject.SetActive(true);
        while (itemSlots.Count < findDatas.Count)
        {
            InventoryItemSlot newSlot = Instantiate(itemSlotOrigin, itemScrollView.content.transform);
            itemSlots.Add(newSlot);
        }
        itemSlotOrigin.gameObject.SetActive(false);

        // 인벤토리 슬롯에 데이터들을 각각 넣어준다.
        for (int i = 0; i < findDatas.Count; i++)
        {
            itemSlots[i].Init(findDatas[i].itemName, findDatas[i].itemCount);
            itemSlots[i].gameObject.SetActive(true);
        }
    }
}
