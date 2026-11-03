using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject itemSlotPrefab;

    [Header("Content")]
    public Transform content;
    public GameManager gameManager;
    public TMP_Text goldText;

    [Header("Detail UI")]
    public TMP_Text itemNameText;
    public TMP_Text itemCountText;
    public TMP_Text itemDescriptionText;
    public Button useButton;

    private List<ItemData> itemList = new List<ItemData>();

    private ItemData selectedItem;

    private void Start()
    {
        CreateTestItems();
        RefreshInventory();
        ClearDetail();
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + gameManager.playerData.gold;
    }

    private void CreateTestItems()
    {
        itemList.Add(new ItemData(
            "Potion", 3, "Restores health.", true
        ));

        itemList.Add(new ItemData(
            "Sword", 1, "A basic weapon."
        ));

        itemList.Add(new ItemData(
            "Shield", 2, "Reduces incoming damage."
        ));

        itemList.Add(new ItemData(
            "Crystal", 5, "A mysterious crystal."
        ));

        itemList.Add(new ItemData(
            "Herb", 8, "A common medicinal plant."
        ));

        itemList.Add(new ItemData(
            "Key", 1, "Opens a locked door."
        ));

        itemList.Add(new ItemData(
            "Gem", 4, "A valuable gemstone."
        ));

        itemList.Add(new ItemData(
            "Book", 2, "Contains useful knowledge."
        ));

        itemList.Add(new ItemData(
            "Ore", 6, "Raw material for crafting."
        ));

        itemList.Add(new ItemData(
            "Food", 10, "Restores stamina.", true
        ));

        itemList.Add(new ItemData(
            "Ring", 1, "A mysterious ring."
        ));

        itemList.Add(new ItemData(
            "Scroll", 3, "Contains an ancient spell."
        ));
    }

    public void RefreshInventory()
    {
        // 清除旧的物品格子
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        // 根据物品数据重新生成格子
        foreach (ItemData item in itemList)
        {
            GameObject slotObject =
                Instantiate(itemSlotPrefab, content);

            ItemSlot slot =
                slotObject.GetComponent<ItemSlot>();

            slot.SetItem(item, this);
        }
    }

    // 显示选中物品的详情
    public void SelectItem(ItemData item)
    {
        selectedItem = item;

        itemNameText.text = item.itemName;
        itemCountText.text = "Quantity: " + item.count;
        itemDescriptionText.text = item.description;

        useButton.interactable = item.isUsable;
    }

    // 清空详情面板
    private void ClearDetail()
    {
        selectedItem = null;

        itemNameText.text = "Select an item";
        itemCountText.text = "Quantity: 0";
        itemDescriptionText.text = "Item description...";
        useButton.interactable = false;
    }

    public void UseSelectedItem()
    {
        if (selectedItem == null)
        {
            return;
        }

        if (!selectedItem.isUsable)
        {
            return;
        }

        selectedItem.count--;

        if (selectedItem.count <= 0)
        {
            itemList.Remove(selectedItem);
            ClearDetail();
        }
        else
        {
            SelectItem(selectedItem);
        }

        RefreshInventory();
    }

    //测试金币增加功能
    public void GainGold()
    {
        gameManager.playerData.gold += 100;
        UpdateGoldUI();
    }
}