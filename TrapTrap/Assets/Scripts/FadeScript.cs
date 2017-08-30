using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScript : MonoBehaviour {
 
    float p_fspeed = 0.01f;
    private float alfa,red, green, blue;
    GameObject Fadeobj;

    public bool p_bFadeTrigger;

    // Use this for initialization
    void Start () {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        p_bFadeTrigger = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += p_fspeed;

        if(alfa >= 1)
        {
            p_bFadeTrigger = false;    

        }
	
	}

    //public void p_vFade()
    //{
    //    p_bFadeTrigger = true;
    //}
}
