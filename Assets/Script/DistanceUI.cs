using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI distanceText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGameOver)
        {
            distanceText.gameObject.SetActive(false);
            return;
        }

        distanceText.text =  player.Distance.ToString("F0")+"m";
    }
}
