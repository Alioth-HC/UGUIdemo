using System;

[Serializable]
public class QuestData
{
    public string questName;
    public string description;
    public int rewardGold;
    public bool isCompleted;
    public bool isClaimed;

    public QuestData(string name, string desc, int reward)
    {
        questName = name;
        description = desc;
        rewardGold = reward;
        isCompleted = false;
        isClaimed = false;
    }
}