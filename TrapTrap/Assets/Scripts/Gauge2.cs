using UnityEngine;
using System.Collections;

public class Gauge2 : MonoBehaviour {

    public int limiter_g;
    public bool mode;
    private int trapColor;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        limiter_g = PlayerLimit.Instance.limiter2;
        mode = PlayerController2.Instance.isFlying;
        trapColor = PlayerController2.Instance.colorNumber;

        GameObject gauge1 = this.transform.Find("Image11").gameObject;
        GameObject gauge2 = this.transform.Find("Image12").gameObject;
        GameObject gauge3 = this.transform.Find("Image13").gameObject;
        GameObject gauge4 = this.transform.Find("Image14").gameObject;
        GameObject gauge5 = this.transform.Find("Image15").gameObject;
        GameObject gauge6 = this.transform.Find("Image16").gameObject;
        GameObject gauge7 = this.transform.Find("Image17").gameObject;
        GameObject gauge8 = this.transform.Find("Image18").gameObject;
        GameObject gauge9 = this.transform.Find("Image19").gameObject;
        GameObject gauge10 = this.transform.Find("Image20").gameObject;


        GameObject mode3 = this.transform.Find("mode3").gameObject;
        GameObject mode4 = this.transform.Find("mode4").gameObject;

        GameObject trapR2 = this.transform.Find("trapR2").gameObject;
        GameObject trapB2 = this.transform.Find("trapB2").gameObject;
        GameObject trapE2 = this.transform.Find("trapE2").gameObject;


        gauge1.gameObject.SetActive(false);
        gauge2.gameObject.SetActive(false);
        gauge3.gameObject.SetActive(false);
        gauge4.gameObject.SetActive(false);
        gauge5.gameObject.SetActive(false);
        gauge6.gameObject.SetActive(false);
        gauge7.gameObject.SetActive(false);
        gauge8.gameObject.SetActive(false);
        gauge9.gameObject.SetActive(false);
        gauge10.gameObject.SetActive(false);

        mode3.gameObject.SetActive(false);
        mode4.gameObject.SetActive(false);

        trapR2.gameObject.SetActive(false);
        trapB2.gameObject.SetActive(false);
        trapE2.gameObject.SetActive(false);

        if (limiter_g >= 1)
            gauge1.gameObject.SetActive(true);
        if (limiter_g >= 2)
            gauge2.gameObject.SetActive(true);
        if (limiter_g >= 3)
            gauge3.gameObject.SetActive(true);
        if (limiter_g >= 4)
            gauge4.gameObject.SetActive(true);
        if (limiter_g >= 5)
            gauge5.gameObject.SetActive(true);
        if (limiter_g >= 6)
            gauge6.gameObject.SetActive(true);
        if (limiter_g >= 7)
            gauge7.gameObject.SetActive(true);
        if (limiter_g >= 8)
            gauge8.gameObject.SetActive(true);
        if (limiter_g >= 9)
            gauge9.gameObject.SetActive(true);
        if (limiter_g >= 10)
            gauge10.gameObject.SetActive(true);

        if (mode)
            mode3.gameObject.SetActive(true);
        else
            mode4.gameObject.SetActive(true);


        switch (trapColor)
        {
            case 0:
                trapR2.gameObject.SetActive(true);
                break;
            case 1:
                trapB2.gameObject.SetActive(true);
                break;
            case 2:
                trapE2.gameObject.SetActive(true);
                break;

        }



    }
}