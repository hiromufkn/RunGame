using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalSceneChanger : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // åªç›ÇÃÉVÅ[ÉìñºéÊìæ
        string currentScene = SceneManager.GetActiveScene().name;

        // 0Ç©1ÇÉâÉìÉ_ÉÄéÊìæ
        int randomValue = Random.Range(0, 2);

        switch (currentScene)
        {
            case "FirstPlainStage":

                if (randomValue == 0)
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("SnowStage");
                }
                else
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("CaveStage");
                }

                break;

            case "SnowStage":

                if (randomValue == 0)
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("FirstPlainStage");
                }
                else
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("CaveStage");
                }

                break;

            case "CaveStage":

                if (randomValue == 0)
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("FirstPlainStage");
                }
                else
                {
                    Player.TotalDistance = player.Distance;
                    SceneManager.LoadScene("SnowStage");
                }

                break;
        }
    }
}
