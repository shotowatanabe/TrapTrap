using UnityEngine;
using System.Collections;

public class Trap_Electronic : Trap
{
    int stopTime = 5;

    GameObject player1;
    GameObject player2;
    GameObject eEfct1;
    GameObject eEfct2;

    public GameObject p_ElecEfct;
    public GameObject Scoreobj;

    bool EFlag1 = false;
    bool EFlag2 = false;

    // Use this for initialization
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        Scoreobj = GameObject.Find("Result_Flame");
}

    // Update is called once per frame
    void Update()
    {
        if (EFlag1)
        {
            eEfct1.transform.position = player1.transform.position; //  位置づれ解消
        }
        if (EFlag2)
        {
            eEfct2.transform.position = player2.transform.position; //  位置づれ解消
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player1")
        {
            if (!EFlag1)
            {
                PlayerController1.Instance.input = false;
                StartCoroutine(Release1());
                eEfct1 = Instantiate(p_ElecEfct);        //  複製する
                eEfct1.name = "Ele_Efct01";
                eEfct1.transform.position = player1.transform.position; //  プレイヤー座標に出てくる
                EFlag1 = true;
                Scoreobj.GetComponent<Score_Script>().p_vP1Hit();

                SoundManager.Instance.PlaySE(12);
            }

        }

        if (col.gameObject.tag == "Player2")
        {
            if (!EFlag2)
            {
                PlayerController2.Instance.input = false;
                StartCoroutine(Release2());
                eEfct2 = Instantiate(p_ElecEfct);        //  複製する
                eEfct2.name = "Ele_Efct02";
                eEfct2.transform.position = player2.transform.position; //  プレイヤー座標に出てくる
                EFlag2 = true;
                Scoreobj.GetComponent<Score_Script>().p_vP2Hit();

                SoundManager.Instance.PlaySE(12);
            }

        }
    }

    void Destroy()
    {
        Destroy(eEfct1);
        Destroy(eEfct2);
        Destroy(gameObject);
    }

    IEnumerator Release1()
    {
        yield return new WaitForSeconds(stopTime);
        PlayerController1.Instance.input = true;
        EFlag2 = false;
        
        Destroy();
    }

    IEnumerator Release2()
    {
        yield return new WaitForSeconds(stopTime);
        PlayerController2.Instance.input = true;
        EFlag2 = false;
        
        Destroy();
    }
}
