
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    public TMP_Text questText;

    private QuestData questData;
    private QuestPanel questPanel;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetQuest(QuestData quest, QuestPanel panel)
    {
        questData = quest;
        questPanel = panel;

        questText.text = quest.questName;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        questPanel.SelectQuest(questData);
    }
}
