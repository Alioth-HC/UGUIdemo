
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject homePanel;
    public GameObject inventoryPanel;
    public GameObject taskPanel;
    public GameObject settingPanel;

    // Show Home Page
    public void ShowHome()
    {
        HideAllPanels();
        homePanel.SetActive(true);
    }

    // Show Inventory Page
    public void ShowInventory()
    {
        HideAllPanels();
        inventoryPanel.SetActive(true);
    }

    // Show Quest Page
    public void ShowTask()
    {
        HideAllPanels();
        taskPanel.SetActive(true);
    }

    // Show Settings Page
    public void ShowSetting()
    {
        HideAllPanels();
        settingPanel.SetActive(true);
    }

    // Hide All Pages
    private void HideAllPanels()
    {
        homePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        taskPanel.SetActive(false);
        settingPanel.SetActive(false);
    }
}
