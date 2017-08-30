using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    Image[] images = new Image[3];

    [SerializeField]
    Sprite[] numberSprites = new Sprite[10];

    public float timeCount { get; private set; }
    private GameObject Count;

    public int time;

    public Score_Script Score_Obj; 

    void Start()
    {
        SetTime(time);
        Count = this.gameObject;
        Count.gameObject.SetActive(true);
    }

    public void SetTime(float time)
    {
        timeCount = time;
        StartCoroutine(TimerStart());
    }

    void SetNumbers(int sec, int val1, int val2)
    {
        string str = String.Format("{0}", sec);
        if (sec >= 100)
        {
            images[0].sprite = numberSprites[Convert.ToInt32(str.Substring(0, 1))];
            images[1].sprite = numberSprites[Convert.ToInt32(str.Substring(1, 1))];
            images[2].sprite = numberSprites[Convert.ToInt32(str.Substring(2, 1))];
        }
        else if(sec >= 10)
        {
            images[0].sprite = numberSprites[0];
            //images[0].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            images[1].sprite = numberSprites[Convert.ToInt32(str.Substring(0, 1))];
            images[2].sprite = numberSprites[Convert.ToInt32(str.Substring(1, 1))];
        }
        else
        {
            images[0].sprite = numberSprites[0];
            images[1].sprite = numberSprites[0];
            //images[0].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            images[2].sprite = numberSprites[Convert.ToInt32(str.Substring(0, 1))];
        
        }

    }

    IEnumerator TimerStart()
    {
        while (timeCount >= 0)
        {
            int sec = Mathf.FloorToInt(timeCount % 181);

            SetNumbers(sec, 1, 2);

            yield return new WaitForSeconds(1.0f);
            timeCount -= 1.0f;
        }
        TimeOver();
    }

    void TimeOver()
    {
        Count.gameObject.SetActive(false);
        //SceneManager.LoadScene("Main");
        PlayerController1.Instance.input = false;
        PlayerController2.Instance.input = false;

        Score_Obj.GetComponent<Score_Script>().p_vGameEnd();
    }
}