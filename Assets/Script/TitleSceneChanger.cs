using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChanger : MonoBehaviour
{
    public void MoveToGameScene()
    {
        SceneManager.LoadScene("FirstPlainStage");
    }
}
