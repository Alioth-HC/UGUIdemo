using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public TMP_Text itemText;

    private ItemData itemData;
    private InventoryPanel inventory;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetItem(ItemData item, InventoryPanel manager)
    {
        itemData = item;
        inventory = manager;

        itemText.text = item.itemName + "\nx" + item.count;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        inventory.SelectItem(itemData);
    }
}