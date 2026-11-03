using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomePanel : MonoBehaviour
{
    [Header("Player Data")]
    public GameManager gameManager;

    [Header("UI References")]
    public TMP_Text playerNameText;
    public TMP_Text levelText;
    public TMP_Text expText;
    public Image expFill;
    public TMP_Text goldText;

    private void OnEnable()
    {
        UpdateUI();
    }

    // 更新玩家资料显示
    public void UpdateUI()
    {
        playerNameText.text = "Player: " + gameManager.playerData.playerName;
        levelText.text = "Level: " + gameManager.playerData.level;
        expText.text = gameManager.playerData.exp + " / " + gameManager.playerData.maxExp;
        goldText.text = "Gold: " + gameManager.playerData.gold;

        UpdateExpBar();
    }

    // 更新经验条长度
    private void UpdateExpBar()
    {
        float ratio = (float)gameManager.playerData.exp / gameManager.playerData.maxExp;
        ratio = Mathf.Clamp01(ratio);

        RectTransform fillRect = expFill.rectTransform;

        fillRect.anchorMin = new Vector2(0, 0);
        fillRect.anchorMax = new Vector2(ratio, 1);

        fillRect.offsetMin = Vector2.zero;
        fillRect.offsetMax = Vector2.zero;
    }

    // 点击按钮增加经验
    public void GainExp()
    {
        gameManager.playerData.exp += 25;

        if (gameManager.playerData.exp >= gameManager.playerData.maxExp)
        {
            gameManager.playerData.exp -= gameManager.playerData.maxExp;
            gameManager.playerData.level++;
            gameManager.playerData.maxExp += 50;
        }

        UpdateUI();
    }
}