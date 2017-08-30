using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TitleScene : MonoBehaviour {

    public GameObject Fadeobj;
    public GameObject p_gFrame;

    int Phase = 0;
    float Timer = 0f;

    float red, blue, green, alfa;

    //float p_fTimer = 0.0f;
    //bool p_bTrigger1 = false;
    //bool p_bTrigger2 = false;

    // Use this for initialization
    void Start ()
    {
        red = Fadeobj.GetComponent<RawImage>().color.r;
        green = Fadeobj.GetComponent<RawImage>().color.g;
        blue = Fadeobj.GetComponent<RawImage>().color.b;
        alfa = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Phase)
        {
            case 0:
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if(Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    p_gFrame.SetActive(true);
                    Phase = 1;
                }

                break;

            case 1:
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire1"))
                // キーボード用
                //if(Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    Phase = 2;
                }
                // ps4コントローラー用
                //else if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //else if(Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                else if (Input.GetButtonDown("Fire1"))
                {
                    Phase = 3;
                }

                break;

            case 2:
                Fadeobj.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
                alfa += 0.01f;
                if(alfa > 1.0f)
                {
                    SceneManager.LoadScene("Tutorial");
                }
                break;

            case 3:
                Fadeobj.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
                alfa += 0.01f;
                if (alfa > 1.0f)
                {
                    SceneManager.LoadScene("Serect");
                }
                break;

        }     

    }

}
