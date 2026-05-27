using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalSceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Œ»İ‚ÌƒV[ƒ“–¼æ“¾
        string currentScene = SceneManager.GetActiveScene().name;

        // 0‚©1‚ğƒ‰ƒ“ƒ_ƒ€æ“¾
        int randomValue = Random.Range(0, 2);

        switch (currentScene)
        {
            case "FirstPlainStage":

                if (randomValue == 0)
                {
                    SceneManager.LoadScene("SnowStage");
                }
                else
                {
                    SceneManager.LoadScene("CaveStage");
                }

                break;

            case "SnowStage":

                if (randomValue == 0)
                {
                    SceneManager.LoadScene("FirstPlainStage");
                }
                else
                {
                    SceneManager.LoadScene("CaveStage");
                }

                break;

            case "CaveStage":

                if (randomValue == 0)
                {
                    SceneManager.LoadScene("FirstPlainStage");
                }
                else
                {
                    SceneManager.LoadScene("SnowStage");
                }

                break;
        }
    }
}
