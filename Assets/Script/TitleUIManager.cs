using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}
