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

    [SerializeField] private string sceneA;
    [SerializeField] private string sceneB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 0‚©1‚ðƒ‰ƒ“ƒ_ƒ€Žæ“¾
            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
            {
                SceneManager.LoadScene(sceneA);
            }
            else
            {
                SceneManager.LoadScene(sceneB);
            }
        }
    }
}
