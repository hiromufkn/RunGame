using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class GameOverUI : MonoBehaviour
{
    public Player player;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
    public GameObject Panel;
    public GameObject Panel2;
    public Button Retry;
    public Button Home;
    // Start is called before the first frame update
    void Start()
    {
        //Retry.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGameOver)
        {
            gameOverText.SetActive(true);
            ScoreText.gameObject.SetActive(true);
            Panel.SetActive(true);
            Panel2.SetActive(false);
            Retry.gameObject.SetActive(true);
            Home.gameObject.SetActive(true);

            //gameOverText.tag = "èIóπ" + player.name;

            ScoreText.text = player.Distance.ToString("F0") + "m";

            
        }
    }

    public void RestartGame()
    {
        Player.Totalhit = 0;
        Player.TotalDistance = 0f;
        Player.TotalSpeed = 7f;
        Player.NextSpeedUp = 50f;

        SceneManager.LoadScene("FirstPlainStage");
    }

    public void Title()
    {
        SceneManager.LoadScene("RunGameScene");
    }
}
