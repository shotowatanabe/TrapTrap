using UnityEngine;
using System.Collections;

public class Trap_Slow : Trap
{
    GameObject player1;
    GameObject player2;

    Vector3 playerPosition1;
    Vector3 playerPosition2;
    Vector3 trapPosition;

    public GameObject Scoreobj;

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
        playerPosition1 = player1.transform.position;
        playerPosition2 = player2.transform.position;
        trapPosition = this.transform.position;

        if (playerPosition1 == trapPosition)
        {
            PlayerController1.Instance.slowTime = 10;
            PlayerController1.Instance.slow = true;
            Scoreobj.GetComponent<Score_Script>().p_vP1Hit();
            SoundManager.Instance.PlaySE(11);
            Destroy(gameObject);
        }

        if (playerPosition2 == trapPosition)
        {
            PlayerController2.Instance.slowTime = 10;
            PlayerController2.Instance.slow = true;
            Scoreobj.GetComponent<Score_Script>().p_vP2Hit();
            SoundManager.Instance.PlaySE(11);
            Destroy(gameObject);
        }
    }
}
