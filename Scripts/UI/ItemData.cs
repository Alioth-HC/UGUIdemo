using System;

[Serializable]
public class ItemData
{
    public string itemName;
    public int count;
    public string description;
    public bool isUsable;

    public ItemData(string name, int amount, string desc, bool usable = false)
    {
        itemName = name;
        count = amount;
        description = desc;
        isUsable = usable;
    }
}