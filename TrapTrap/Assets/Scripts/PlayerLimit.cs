using UnityEngine;
using System.Collections;

public class PlayerLimit : MonoBehaviour
{
    public int limiter1;
    public int limiter2;
    public bool limit1 = false;
    public bool limit2 = false;
    static PlayerLimit instance;

    public static PlayerLimit Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        limiter1 = 3;
        limiter2 = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlusLimit1()
    {
        if (PlayerController1.Instance.isFlying == false)
        {
            if (limiter1 + 1 <= 10)
            {
                limit1 = false;
                ++limiter1;
            }
            else
            {
                limit1 = true;
            }
        }
        else if (PlayerController1.Instance.isFlying == true)
        {
            if (limiter1 + 2 <= 10)
            {
                limit1 = false;
                limiter1 = limiter1 + 2;
            }
            else
            {
                limit1 = true;
            }
        }
    }

    public void PlusLimit2()
    {
        if (PlayerController2.Instance.isFlying == false)
        {
            if (limiter2 + 1 <= 10)
            {
                limit2 = false;
                ++limiter2;
            }
            else
            {
                limit2 = true;
            }
        }
        else if (PlayerController2.Instance.isFlying == true)
        {
            if (limiter2 + 2 <= 10)
            {
                limit2 = false;
                limiter2 = limiter2 + 2;
            }
            else
            {
                limit2 = true;
            }
        }
    }

    public void MinusLimit1()
    {
        limit1 = false;
        limiter1 = limiter1 - 5;
        if (limiter1 < 0)
        {
            limiter1 = 0;
        }
    }

    public void MinusLimit2()
    {
        limit2 = false;
        limiter2 = limiter2 - 5;
        if (limiter2 < 0)
        {
            limiter2 = 0;
        }
    }
}
