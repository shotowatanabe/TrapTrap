using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Tutorial_Script : MonoBehaviour
{

    public float p_fspeed = 0.1f;
    private float alfa, red, green, blue, Falfa;
    public GameObject Flameobj;
    public GameObject Fadeobj;

    public int Phase;
    public float Timer = 0;


    public GameObject[] TextBox;
    public float[] WaitTime;
    public GameObject[] PicBox;

    // Use this for initialization
    void Start()
    {
        red = Flameobj.GetComponent<RawImage>().color.r;
        green = Flameobj.GetComponent<RawImage>().color.g;
        blue = Flameobj.GetComponent<RawImage>().color.b;
        alfa = 0.0f;

        Phase = 0;
        Timer = WaitTime[0];
    }

    // Update is called once per frame
    void Update()
    {
        Flameobj.GetComponent<RawImage>().color = new Color(red, green, blue, alfa);
        switch (Phase)
        {
            case 0:     //      非表示状態

                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    ++Phase;
                }

                break;

            case 1:     //     フェードインフェイズ

                PlayerController1.Instance.input = false;

                alfa += p_fspeed;
                if (alfa >= 1)
                {
                    ++Phase;
                }
                break;

            case 2:     //      表示状態

                TextBox[0].SetActive(true); //  text01を表示

                PicBox[1].SetActive(true);  //  pic01を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[0].SetActive(false);

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                break;

            case 3:     //      表示状態

                TextBox[1].SetActive(true);   //    text02を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[1].SetActive(false);    //    text02を削除
                    PicBox[1].SetActive(false);     //    pic01を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if(Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[1].SetActive(false);    //    text02を削除
                    PicBox[1].SetActive(false);     //    pic01を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 4:     //      表示状態

                TextBox[2].SetActive(true);     //  text03を表示
                PicBox[2].SetActive(true);      //  pic02を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[2].SetActive(false);    //  text03を削除
                    PicBox[2].SetActive(false);     //  pic02を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を表示
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[2].SetActive(false);    //  text03を削除
                    PicBox[2].SetActive(false);     //  pic02を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を表示
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 5:     //      表示状態

                TextBox[3].SetActive(true);     //  text03を表示
                PicBox[3].SetActive(true);      //  pic02を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[3].SetActive(false);    //  text03を削除
                    PicBox[3].SetActive(false);     //  pic02を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[3].SetActive(false);    //  text03を削除
                    PicBox[3].SetActive(false);     //  pic02を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }

                break;

            case 6:     //      表示状態

                TextBox[4].SetActive(true);     //  text03を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[4].SetActive(false);    //  text03を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[4].SetActive(false);    //  text03を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 7:     //     フェードアウトフェイズ              
                alfa -= p_fspeed;

                if (alfa <= 0)
                {
                    ++Phase;
                    Timer = WaitTime[1];
                    PlayerController1.Instance.input = true;
                }
                break;

            case 8:     //      非表示状態              
                if (PlayerLimit.Instance.limiter1 >= 10)
                {
                    Timer -= Time.deltaTime;
                    if (Timer <= 0.0f)
                    {
                        ++Phase;
                    }
                }

                break;

            case 9:     //     フェードインフェイズ

                PlayerController1.Instance.input = false;

                alfa += p_fspeed;
                if (alfa >= 1)
                {
                    ++Phase;
                }
                break;

            case 10:     //      表示状態

                TextBox[5].SetActive(true); //  text06を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[5].SetActive(false);    //  text06を削除

                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                break;

            case 11:     //      表示状態

                TextBox[6].SetActive(true); //  text07を表示

                PicBox[4].SetActive(true);  //  pic05を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示     

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[6].SetActive(false);    //  text07を削除
                    PicBox[4].SetActive(false);  //  pic05を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[6].SetActive(false);    //  text07を削除
                    PicBox[4].SetActive(false);  //  pic05を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 12:     //      表示状態

                TextBox[7].SetActive(true); //  text08を表示

                PicBox[5].SetActive(true);  //  pic05を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示


                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[7].SetActive(false);    //  text08を削除

                    PicBox[5].SetActive(false);  //  pic05を表示
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[7].SetActive(false);    //  text08を削除

                    PicBox[5].SetActive(false);  //  pic05を表示
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 13:     //      表示状態

                TextBox[8].SetActive(true); //  text09を表示

                PicBox[6].SetActive(true);  //  pic06を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[8].SetActive(false);    //  text09を削除
                    PicBox[6].SetActive(false);  //  pic06を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[8].SetActive(false);    //  text09を削除
                    PicBox[6].SetActive(false);  //  pic06を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 14:     //      表示状態

                TextBox[9].SetActive(true); //  text10を表示

                PicBox[7].SetActive(true);  //  pic07を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[9].SetActive(false);    //  text10を削除
                    PicBox[7].SetActive(false);  //  pic07を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[9].SetActive(false);    //  text10を削除
                    PicBox[7].SetActive(false);  //  pic07を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 15:     //      表示状態

                TextBox[10].SetActive(true); //  text11を表示

                PicBox[8].SetActive(true);  //  pic08を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[10].SetActive(false);    //  text11を削除
                    PicBox[8].SetActive(false);  //  pic08を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[10].SetActive(false);    //  text11を削除
                    PicBox[8].SetActive(false);  //  pic08を削除
                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;
            case 16:     //      表示状態

                TextBox[4].SetActive(true); //  text05を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    TextBox[4].SetActive(false);    //  text05を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    TextBox[4].SetActive(false);    //  text05を削除

                    PicBox[0].SetActive(false);  //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }

                break;

            case 17:     //     フェードアウトフェイズ              
                alfa -= p_fspeed;

                if (alfa <= 0)
                {
                    ++Phase;
                    Timer = WaitTime[2];
                    PlayerController1.Instance.input = true;
                }
                break;

            case 18:     //      非表示状態

                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    ++Phase;
                }

                break;

            case 19:     //     フェードインフェイズ

                PlayerController1.Instance.input = false;

                alfa += p_fspeed;
                if (alfa >= 1)
                {
                    ++Phase;
                }
                break;

            case 20:     //      表示状態
                TextBox[11].SetActive(true); //  text12を表示

                PicBox[0].SetActive(true);  //  CircleBotton01を表示              

                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    TextBox[11].SetActive(false); //  text12を表示
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }

                break;

            case 21:     //      表示状態
                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                PicBox[9].SetActive(true);  //  pic09を表示
                PicBox[12].SetActive(true);  //  pic12を表示

                TextBox[12].SetActive(true); //  text13を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[9].SetActive(false);  //  pic09を削除
                    PicBox[12].SetActive(false);  //  pic12を削除
                    TextBox[12].SetActive(false); //  text13を表示
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[9].SetActive(false);  //  pic09を削除
                    PicBox[12].SetActive(false);  //  pic12を削除
                    TextBox[12].SetActive(false); //  text13を表示
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 22:     //      表示状態
                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                PicBox[10].SetActive(true);  //  pic10を表示

                TextBox[13].SetActive(true); //  text13を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[10].SetActive(false);  //  pic10を削除
                    TextBox[13].SetActive(false); //  text13を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[10].SetActive(false);  //  pic10を削除
                    TextBox[13].SetActive(false); //  text13を削除
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 23:     //      表示状態
                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                TextBox[14].SetActive(true); //  text15を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除

                    TextBox[14].SetActive(false); //  text15を表示
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除

                    TextBox[14].SetActive(false); //  text15を表示
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;

            case 24:     //      表示状態
                PicBox[0].SetActive(true);  //  CircleBotton01を表示
                PicBox[11].SetActive(true);  //  ClossBotton01を表示

                PicBox[13].SetActive(true);  //  pic12を表示

                TextBox[15].SetActive(true); //  text15を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[13].SetActive(false);  //  pic12を削除
                    TextBox[15].SetActive(false); //  text16を表示
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    PicBox[0].SetActive(false);     //  CircleBotton01を削除
                    PicBox[11].SetActive(false);  //  ClossBotton01を削除
                    PicBox[13].SetActive(false);  //  pic12を削除
                    TextBox[15].SetActive(false); //  text16を表示
                    SoundManager.Instance.PlaySE(10);
                    --Phase;
                }
                break;
            case 25:     //      表示状態
                PicBox[14].SetActive(true);  //  pic13を表示

                TextBox[16].SetActive(true); //  text15を表示
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    PicBox[14].SetActive(false);  //  pic13を削除

                    TextBox[16].SetActive(false); //  text16を削除
                    SoundManager.Instance.PlaySE(10);
                    ++Phase;
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    PicBox[14].SetActive(false);  //  pic13を削除

                    TextBox[16].SetActive(false); //  text16を削除

                    Falfa = Fadeobj.GetComponent<RawImage>().color.a;
                    SoundManager.Instance.PlaySE(10);
                    Phase = 29;
                }
                break;

            case 26:     //     フェードアウトフェイズ              
                alfa -= p_fspeed;

                if (alfa <= 0)
                {
                    ++Phase;
                    PlayerController1.Instance.input = true;
                    PicBox[15].SetActive(true);

                }
                break;

            case 27:     //      練習モード
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire2"))
                // キーボード用
                //if (Input.GetKeyDown("return"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire3"))
                {
                    ++Phase;
                    SoundManager.Instance.PlaySE(10);
                }
                // ps4コントローラー用
                //if (Input.GetButtonDown("Fire5"))
                // キーボード用
                //if (Input.GetKeyDown("backspace"))
                // xboxコントローラー用
                if (Input.GetButtonDown("Fire1"))
                {
                    Phase = 29;
                    SoundManager.Instance.PlaySE(10);
                }

                break;

            case 28:
                Fadeobj.GetComponent<RawImage>().color = new Color(0.0f, 0.0f, 0.0f, Falfa);

                Falfa += 0.01f;
                if (Falfa >= 1.0f)
                {
                    SceneManager.LoadScene("Tutorial");
                }

                break;

            case 29:
                Fadeobj.GetComponent<RawImage>().color = new Color(0.0f, 0.0f, 0.0f, Falfa);

                Falfa += 0.01f;
                if (Falfa >= 1.0f)
                {
                    SceneManager.LoadScene("Serect");
                }
                break;
        }
    }

}
