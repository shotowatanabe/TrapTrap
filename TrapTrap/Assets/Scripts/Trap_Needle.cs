using UnityEngine;
using System.Collections;

public class Trap_Needle : Trap
{
    public GameObject p_needleEfct;
    public GameObject Scoreobj;

    GameObject player1;
    GameObject player2;
    GameObject needle1;
    GameObject needle2;

    Vector3 playerPos1;
    Vector3 playerPos2;
    Vector3 trapPos;
    Vector3 needlePos1;
    Vector3 needlePos2;

    bool Trap_Upflag01;
    bool Trap_Downflag01;
    bool Trap_Wait01;
    bool Trap_Upflag02;
    bool Trap_Downflag02;
    bool Trap_Wait02;

    float Up_PosY = 0.5f;
    float Down_PosY = -2.5f;

    float FTimer = 2.0f;

    // Use this for initialization
    void Start()
    {
        Trap_Upflag01 = false;
        Trap_Upflag02 = false;
        Trap_Wait01 = false;
        Trap_Wait02 = false;

        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        Scoreobj = GameObject.Find("Result_Flame");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos1 = player1.transform.position;
        playerPos2 = player2.transform.position;
        trapPos = this.transform.position;

        if (playerPos1 == trapPos)
        {
            //  ニードルオブジェクト(ニードル/ゲージ上昇)
            if (!Trap_Downflag01 && !Trap_Upflag01 && !Trap_Wait01)
            {
                Trap_Upflag01 = true;
                needle1 = Instantiate(p_needleEfct);        //  複製する
                needle1.name = "needle_Efct01";
                needle1.transform.position = needlePos1 = new Vector3(trapPos.x, Down_PosY, trapPos.z); //  トラップの座標に出てくる

                Scoreobj.GetComponent<Score_Script>().p_vP1Hit();
            }
        }

        if (playerPos2 == trapPos)
        {
            //  ニードルオブジェクト(ニードル/ゲージ上昇)
            if (!Trap_Downflag02 && !Trap_Upflag02 && !Trap_Wait02)
            {
                Trap_Upflag02 = true;
                needle2 = Instantiate(p_needleEfct);        //  複製する
                needle2.name = "needle_Efct02";
                needle2.transform.position = needlePos2 = new Vector3(trapPos.x, Down_PosY, trapPos.z); //  トラップの座標に出てくる

                Scoreobj.GetComponent<Score_Script>().p_vP2Hit();
            }
        }

        if (Trap_Upflag01)
        {

            needlePos1.y += 1.0f;
            needle1.transform.position = needlePos1;
            if (needlePos1.y >= Up_PosY)
            {
                Trap_Upflag01 = false;
                Trap_Wait01 = true;
                SoundManager.Instance.PlaySE(9);
            }
        }

        else if (Trap_Wait01)
        {
            FTimer -= Time.deltaTime;
            if (FTimer <= 0.0f)
            {
                Trap_Wait01 = false;
                Trap_Downflag01 = true;
                FTimer = 2.0f;
            }
        }
        else if (Trap_Downflag01)
        {
            needlePos1.y -= 1.0f;
            needle1.transform.position = needlePos1;
            if (needlePos1.y <= Down_PosY)
            {
                Trap_Downflag01 = false;
                Destroy();
            }
        }



        if (Trap_Upflag02)
        {

            needlePos2.y += 1.0f;
            needle2.transform.position = needlePos2;
            if (needlePos2.y >= Up_PosY)
            {

                Trap_Upflag02 = false;
                Trap_Wait02 = true;
                SoundManager.Instance.PlaySE(9);

            }
        }
        else if (Trap_Wait02)
        {
            FTimer -= Time.deltaTime;
            if (FTimer <= 0.0f)
            {
                Trap_Wait02 = false;
                Trap_Downflag02 = true;
                FTimer = 2.0f;
            }
        }
        else if (Trap_Downflag02)
        {
            needlePos2.y -= 1.0f;
            needle2.transform.position = needlePos2;
            if (needlePos2.y <= Down_PosY)
            {
                Trap_Downflag02 = false;

                Destroy();
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player1")
        {
            PlayerLimit.Instance.limiter1 = PlayerLimit.Instance.limiter1 + 5;
            if (PlayerLimit.Instance.limiter1 >= 10)
            {
                PlayerLimit.Instance.limiter1 = 10;
                PlayerLimit.Instance.limit1 = true;
            }
        }
        else if(col.gameObject.tag == "Player2")
        {
            PlayerLimit.Instance.limiter2 = PlayerLimit.Instance.limiter2 + 5;
            if (PlayerLimit.Instance.limiter2 >= 10)
            {
                PlayerLimit.Instance.limiter2 = 10;
                PlayerLimit.Instance.limit2 = true;
            }
        }
    }
    void Destroy()
    {
        Destroy(needle1);
        Destroy(needle2);
        Destroy(gameObject); Destroy(needle2);
    }
}