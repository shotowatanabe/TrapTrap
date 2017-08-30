using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public Material[] material;
    int colorNumber;
    public int stopTime = 1;

    // Cellのx座標
    public int X { get { return x; } }

    // Cellのz座標
    public int Z { get { return z; } }

    // Cellの色を割り当てる
    public Field.CellColor CellColor
    {
        set
        {
            switch (value)
            {
                case Field.CellColor.Red:
                    GetComponent<Renderer>().material = material[0];
                    colorNumber = 0;
                    break;
                case Field.CellColor.Blue:
                    GetComponent<Renderer>().material = material[1];
                    colorNumber = 1;
                    break;
                case Field.CellColor.Yellow:
                    GetComponent<Renderer>().material = material[2];
                    colorNumber = 2;
                    break;
            }
        }
        get
        {
            if (colorNumber == 0)
            {
                return Field.CellColor.Red;
            }
            else if (colorNumber == 1)
            {
                return Field.CellColor.Blue;
            }
            else
            {
                return Field.CellColor.Yellow;
            }
        }
    }

    int x;
    int z;

    // Cellの初期化
    public void Initialize(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    // プレイヤーがcellの色を変更する時の処理
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;
        int layerPlayer1 = LayerMask.GetMask(new string[] { "Player1" });
        int layerPlayer2 = LayerMask.GetMask(new string[] { "Player2" });
        int layerStage = LayerMask.GetMask(new string[] { "Stage" });

        // player1の処理
        if(PlayerController1.Instance.input)
        {
            if (Physics.Raycast(ray, out hit, 1.0f, layerPlayer1))
            {
                if (!PlayerController1.Instance.isMove)
                {
                    if (Input.GetButtonDown("Fire5"))
                    {
                        if (PlayerLimit.Instance.limiter1 >= 5)
                        {
                            Field.Instance.OnCellClick(this, PlayerController1.Instance, null);
                            PlayerController1.Instance.input = false;
                            Invoke("Release1", stopTime);

                            PlayerController1.Instance.ChangeCellColorAnim();
                        }
                        else
                        {
                            SoundManager.Instance.PlaySE(6);
                        }
                    }
                }
            }
        }

        // player2の処理
        if(PlayerController2.Instance.input)
        {
            if (Physics.Raycast(ray, out hit, 1.0f, layerPlayer2))
            {
                if (!PlayerController2.Instance.isMove)
                {
                    if (Input.GetButtonDown("Fire5_2"))
                    {
                        if (PlayerLimit.Instance.limiter2 >= 5)
                        {
                            Field.Instance.OnCellClick(this, null, PlayerController2.Instance);
                            PlayerController2.Instance.input = false;
                            Invoke("Release2", stopTime);

                            PlayerController2.Instance.ChangeCellColorAnim();
                        }
                        else
                        {
                            SoundManager.Instance.PlaySE(6);
                        }
                    }
                }
            }
        }

        if (Physics.Raycast(ray, out hit, 1.0f, layerStage))
        {
            Destroy(gameObject);
        }
    }

    void Release1()
    {
        PlayerController1.Instance.Release();
    }

    void Release2()
    {
        PlayerController2.Instance.Release();
    }
}