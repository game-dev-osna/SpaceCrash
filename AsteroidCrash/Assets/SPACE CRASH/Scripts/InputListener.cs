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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(asteroidBig.GameOver || questManager.HyperdriveFixed)
        {
            Debug.Log("done...");
            var value1 = Input.GetAxis("TriggerLeft");
            var value2 = Input.GetAxis("TriggerRight");
            if (value1 > 0.1f || value2 > 0.1f)
            {
                Debug.Log("Reload...");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
}
