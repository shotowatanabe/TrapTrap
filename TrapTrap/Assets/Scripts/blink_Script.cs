using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class blink_Script : MonoBehaviour {

    public GameObject   blinkobj;

    public float p_fblkSpd = 0.05f;
    private float alfa, red, green, blue;
    float Timer = 0.0f;

    int Phase = 0;

	// Use this for initialization
	void Start () {
        red = blinkobj.GetComponent<RawImage>().color.r;
        green = blinkobj.GetComponent<RawImage>().color.g;
        blue = blinkobj. GetComponent<RawImage>().color.b;
        alfa = blinkobj.GetComponent<RawImage>().color.a;

    }
	
	// Update is called once per frame
	void Update ()
    {
        switch(Phase)
        {
            case 0:             
                alfa -= p_fblkSpd;
                if (alfa < 0.0f)
                {
                    Phase = 1;
                }
                break;

            case 1:
                alfa += p_fblkSpd;
                if (alfa > 1.0f)
                {
                    Phase = 0;
                }
                break;
        }
        GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
    }
}
