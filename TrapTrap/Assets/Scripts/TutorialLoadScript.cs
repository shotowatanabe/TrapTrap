using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialLoadScript : MonoBehaviour {

    public GameObject p_gFPanel;
    private float p_fTimer = 0.0f;
    private bool p_bTrigger = false;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (p_bTrigger)
        {
            p_fTimer += Time.deltaTime;

            if (p_fTimer >= 3.0)
            {
                SceneManager.LoadScene("Tutorial");

            }
        }
    }

    public void TutorialLoad()
    {
        p_gFPanel.SetActive(true);
        p_bTrigger = true;
    }
}
