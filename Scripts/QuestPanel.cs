
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class QuestPanel : MonoBehaviour
{
    [Header("Quest List")]
    public Transform questContent;
    public GameObject questSlotPrefab;

    [Header("Quest Details")]
    public TMP_Text questNameText;
    public TMP_Text questDescriptionText;
    public TMP_Text rewardText;
    public TMP_Text statusText;
    public Button claimButton;

    [Header("Quest Data")]
    public List<QuestData> quests = new List<QuestData>();

    [Header("Game Manager")]
    public GameManager gameManager;

    private QuestData selectedQuest;

    // 通知金币系统发放奖励
    public Action<int> OnGoldRewardClaimed;

    private void Start()
    {
        claimButton.onClick.AddListener(ClaimReward);
        RefreshQuestList();
        ClearDetails();
    }

    // 生成任务列表
    public void RefreshQuestList()
    {
        if (questContent == null || questSlotPrefab == null)
        {
            Debug.LogError("QuestPanel references are missing!");
            return;
        }

        foreach (Transform child in questContent)
        {
            Destroy(child.gameObject);
        }

        foreach (QuestData quest in quests)
        {
            GameObject slotObject =
                Instantiate(questSlotPrefab, questContent);

            QuestSlot slot = slotObject.GetComponent<QuestSlot>();

            if (slot != null)
            {
                slot.SetQuest(quest, this);
            }
        }
    }

    // 选择任务
    public void SelectQuest(QuestData quest)
    {
        selectedQuest = quest;

        questNameText.text = quest.questName;
        questDescriptionText.text = quest.description;
        rewardText.text = quest.rewardGold.ToString() + " Gold";

        UpdateQuestStatus();
    }

    // 更新任务状态
    private void UpdateQuestStatus()
    {
        if (selectedQuest == null)
            return;

        if (selectedQuest.isClaimed)
        {
            statusText.text = "Claimed";
            claimButton.interactable = false;
        }
        else
        {
            statusText.text = "In Progress";
            claimButton.interactable = true;
        }
    }

    // 领取奖励
    private void ClaimReward()
    {
        if (selectedQuest == null)
            return;

        if (!selectedQuest.isCompleted || selectedQuest.isClaimed)
            return;

        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned!");
            return;
        }

        // 增加金币
        gameManager.playerData.gold += selectedQuest.rewardGold;

        // 标记任务已领取
        selectedQuest.isClaimed = true;

        // 更新任务状态
        UpdateQuestStatus();

        Debug.Log("Reward claimed! Current Gold: "
            + gameManager.playerData.gold);
    }

    // 测试用：完成当前选中的任务
    public void CompleteSelectedQuest()
    {
        if (selectedQuest == null)
            return;

        selectedQuest.isCompleted = true;

        UpdateQuestStatus();

        Debug.Log("Quest Completed: " + selectedQuest.questName);
    }

    // 清空详情
    private void ClearDetails()
    {
        selectedQuest = null;

        questNameText.text = "Select a Quest";
        questDescriptionText.text = "";
        rewardText.text = "";
        statusText.text = "";

        claimButton.interactable = false;
    }
}
