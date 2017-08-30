using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectSceneScript : MonoBehaviour {

    public GameObject P1_OK;
    public GameObject P2_OK;

    public GameObject P1_Ready;
    public GameObject P2_Ready;

    public GameObject F_Panel;

    bool P1Flag;
    bool P2Flag;

    public float red, green, blue, alfa;

    // Use this for initialization
    void Start()
    {
        P1_Ready.SetActive(true);
        P2_Ready.SetActive(true);
        P1_OK.SetActive(false);
        P2_OK.SetActive(false);

        P1Flag = false;
        P2Flag = false;

        red = F_Panel.GetComponent<RawImage>().color.r;
        green = F_Panel.GetComponent<RawImage>().color.g;
        blue = F_Panel.GetComponent<RawImage>().color.b;
        alfa = F_Panel.GetComponent<RawImage>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        // ps4コントローラー用
        //if (!P1Flag && Input.GetButtonDown("Fire2"))
        // キーボード用
        //if(!P1Flag && Input.GetKeyDown("e"))
        // xboxコントローラー用
        if (!P1Flag && Input.GetButtonDown("Fire3"))
        {
            P1_Ready.SetActive(false);
            P1_OK.SetActive(true);
            P1Flag = true;
        }

        // ps4コントローラー用
        //if (!P2Flag && Input.GetButtonDown("Fire5_2"))
        // キーボード用
        //if (!P2Flag && Input.GetKeyDown("o"))
        if (!P2Flag && Input.GetButtonDown("Fire3_2"))
        {
            P2_Ready.SetActive(false);
            P2_OK.SetActive(true);
            P2Flag = true;
        }


        if (P1Flag && P2Flag)
        {
            alfa += 0.01f;
            F_Panel.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);

            if (alfa >= 1.0f)
            {
                SceneManager.LoadScene("Main");
            }
        }

    }

    //public void SMainLoad()
    //{
    //    SceneManager.LoadScene("Main");
    //}
}
