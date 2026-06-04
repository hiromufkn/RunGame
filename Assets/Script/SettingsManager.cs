using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void SetDrawDistance(float distance)
    {
        PlayerPrefs.SetFloat("DrawDistance", distance);
        PlayerPrefs.Save();
    }
}
