using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField]
    private AsteroidBig asteroidBig;

    [SerializeField]
    private QuestManager questManager;

    [SerializeField]
    private WebVRController leftCtrl;
    [SerializeField]
    private WebVRController rightCtrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroidBig.GameOver || questManager.GameWon)
        {
            if(leftCtrl.GetButtonDown("Trigger") || leftCtrl.GetButtonDown("Grip") || rightCtrl.GetButtonDown("Trigger") || rightCtrl.GetButtonDown("Grip"))
            {
                Debug.Log("Reload...");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }            
        }
    }
}
