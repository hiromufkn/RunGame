using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{
    public Player player;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGameOver)
        {
            gameOverText.SetActive(true);
            ScoreText.gameObject.SetActive(true);

            //gameOverText.tag = "èIóπ" + player.name;

            ScoreText.text = "Score" + player.Distance.ToString("F0") + "m";

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Player.TotalDistance = 0f;

                SceneManager.LoadScene("FirstPlainStage");
            }
        }
    }
}
