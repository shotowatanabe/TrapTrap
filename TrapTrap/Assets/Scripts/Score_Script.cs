using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Score_Script : MonoBehaviour
{
    public int P1_SetTrap = 0, P2_SetTrap = 0, P1_SetScore, P2_SetScore;
    public int P1_HitTrap = 0, P2_HitTrap = 0, P1_HitScore, P2_HitScore;

    public int Phase = 0;
    int P1_Score, P2_Score;

    public float Timer;

    public bool EndFlag = false;
    float alfa, Talfa, red, green, blue, f_Speed = 0.01f;

    public GameObject P1_text, P2_text;
    public Text Set_text00, Set_text01, Set_text02, Hit_text00, Hit_text01, Hit_text02, Score_Text00, Score_Text01, Score_Text02;
    public Text Judge01, Judge02;

    public GameObject BottonObj, FadeObj;


    // Use this for initialization
    void Start()
    {
        red = this.GetComponent<RawImage>().color.r;
        green = this.GetComponent<RawImage>().color.g;
        blue = this.GetComponent<RawImage>().color.b;
        alfa = 0.0f;
        Talfa = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Phase > 0)
        {
            PlayerController1.Instance.input = false;
            PlayerController2.Instance.input = false;
        }

        switch (Phase)
        {
            case 0:

                break;

            case 1:
                PFrameDrow();
                if (alfa >= 1.0f)
                {
                    Phase = 2;
                    Timer = 1.0f;
                }
                break;

            case 2:
                PtextDrow();
                if (Talfa >= 1.0f)
                {
                    Timer -= Time.deltaTime;
                    if (Timer <= 0.0f)
                    {
                        Set_text00.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                        Score_Text00.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                        Timer = 1.0f;
                        Phase = 3;
                    }
                }
                break;
            case 3:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    P1_SetScore = P1_SetTrap * 100;
                    P2_SetScore = P2_SetTrap * 100;

                    Set_text01.text = P1_SetTrap + "回 × 100 =" + P1_SetScore;
                    Set_text02.text = P2_SetTrap + "回 × 100 =" + P2_SetScore;

                    Set_text01.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    Set_text02.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);

                    Score_Text01.text = P1_SetScore.ToString();
                    Score_Text02.text = P2_SetScore.ToString();

                    Score_Text01.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    Score_Text02.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);

                    Timer = 1.0f;
                    Phase = 4;
                }
                break;

            case 4:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    Hit_text00.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    Timer = 1.0f;
                    Phase = 5;
                }
                break;

            case 5:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    P1_HitScore = P1_HitTrap * 300;
                    P2_HitScore = P2_HitTrap * 300;
                    Hit_text01.text = P1_HitTrap + "回 × -300 = " + P1_HitScore;
                    Hit_text02.text = P2_HitTrap + "回 × -300 = " + P2_HitScore;

                    Hit_text01.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    Hit_text02.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    Timer = 1.0f;
                    Phase = 6;
                    P1_Score = P1_SetTrap * 100;
                    P2_Score = P2_SetTrap * 100;
                }
                break;

            case 6:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    if (P1_HitScore >= 1)
                    {
                        P1_Score -= 100;
                        P1_HitScore -= 100;
                        Hit_text01.text = P1_HitTrap + "回 × -300 = " + P1_HitScore;
                        Score_Text01.text = P1_Score.ToString();
                        Hit_text01.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                        Score_Text01.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    }
                    if (P2_HitScore >= 1)
                    {
                        P2_Score -= 100;
                        P2_HitScore -= 100;
                        Hit_text02.text = P2_HitTrap + "回 × -300 = " + P2_HitScore;
                        Score_Text02.text = P2_Score.ToString();
                        Hit_text02.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                        Score_Text02.GetComponent<Text>().color = new Color(0.2f, 1.0f, 1.0f, 1.0f);
                    }

                    if (P1_HitScore <= 0 && P2_HitScore <= 0)
                    {
                        Phase = 7;
                    }
                }
                break;

            case 7:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    Timer = 1.0f;
                    if (P1_Score == P2_Score)
                    {
                        Phase = 10;
                    }
                    if (P1_Score < P2_Score)
                    {
                        Phase = 9;
                    }
                    else if (P1_Score > P2_Score)
                    {
                        Phase = 8;
                    }

                }
                break;

            case 8:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    Judge01.text = "WIN";
                    Judge02.text = "LOST";

                    Judge01.GetComponent<Text>().color = new Color(1f, 0f, 0f, 1.0f);
                    Judge02.GetComponent<Text>().color = new Color(0f, 0f, 1f, 1.0f);
                    Timer = 1.0f;
                    Phase = 11;
                    BottonObj.SetActive(true);
                }
                break;

            case 9:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    Judge01.text = "LOST";
                    Judge02.text = "WIN";

                    Judge01.GetComponent<Text>().color = new Color(0f, 0f, 1f, 1.0f);
                    Judge02.GetComponent<Text>().color = new Color(1f, 0f, 0f, 1.0f);
                    Timer = 1.0f;
                    Phase = 11;
                    BottonObj.SetActive(true);
                }
                break;

            case 10:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {
                    Judge01.text = "DRAW";
                    Judge02.text = "DRAW";

                    Judge01.GetComponent<Text>().color = new Color(0f, 1f, 0f, 1.0f);
                    Judge02.GetComponent<Text>().color = new Color(0f, 1f, 0f, 1.0f);
                    Timer = 1.0f;
                    Phase = 11;
                    BottonObj.SetActive(true);
                }
                break;
            case 11:
                Timer -= Time.deltaTime;
                if (Timer <= 0.0f)
                {

                    if (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire5_2"))
                    {
                        Timer = 0.0f;
                        red = 0.0f;
                        blue = 0.0f;
                        green = 0.0f;
                        alfa = 0.0f;
                        Phase = 12;
                    }
                }
                break;

            case 12:
                {
                    FadeObj.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
                    alfa += 0.01f;
                    if (alfa >= 1.0f)
                    {
                        SceneManager.LoadScene("Title");
                    }
                }
                break;
        }
    }

    public void p_vP1Set()
    {
        ++P1_SetTrap;
    }

    public void p_vP2Set()
    {
        ++P2_SetTrap;
    }

    public void p_vP1Hit()
    {
        ++P1_HitTrap;
    }

    public void p_vP2Hit()
    {
        ++P2_HitTrap;
    }

    public void p_vGameEnd()
    {
        Phase = 1;
    }

    private void PFrameDrow()
    {
        this.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
        alfa += f_Speed;
    }

    private void PtextDrow()
    {
        P1_text.GetComponent<RawImage>().color = new Color(255, 255, 255, Talfa);
        P2_text.GetComponent<RawImage>().color = new Color(255, 255, 255, Talfa);
        Talfa += 0.1f;
    }
}