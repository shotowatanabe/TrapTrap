using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class Field : MonoBehaviour
{
    public Transform topWall;
    public int numberX;
    public int numberZ;
    public int totalDepth;
    int ChangeCellCollorCoroutineCount;
    int colorNumber;

    public PlayerController1 playerPrefab1;
    public PlayerController2 playerPrefab2;
    public Cell cellPrefab;
    public Trap_Electronic electronicPrefab;
    public Trap_Needle needlePrefab;
    public Trap_Slow slowPrefab;
    public Trap_Treasure treasurePrefab;
    public Score_Script Scoreobj;
    static Field instance;

    List<Cell> cells = new List<Cell>();
    List<Trap> traps = new List<Trap>();

    // Playerの色定義
    public enum PlayerColor
    {
        Red,
        Blue,
        Yellow
    }

    // cellの色定義
    public enum CellColor
    {
        Red,
        Blue,
        Yellow
    }

    // playerのタイプ
    public enum PlayerType
    {
        Player1,
        Player2
    }

    // treasureの定義
    public enum TreasureType
    {
        Player1,
        Player2
    }

    public static Field Instance
    {
        get { return instance; }
    }

    CellColor CurrentCellColor
    {
        get { return (CellColor)colorNumber; }
    }

    void Awake()
    {
        instance = this;

        Vector3 playerStartPoint1 = new Vector3(-8, 0.5f, -18);
        Vector3 playerStartPoint2 = new Vector3(8, 0.5f, -18);
        Vector3 treasurePoint1 = new Vector3(-8, 0.5f, -20);
        Vector3 treasurePoint2 = new Vector3(8, 0.5f, -20);

        // playerを配置
        var player1 = Instantiate(playerPrefab1);
        player1.name = "Player1";
        player1.transform.position = playerStartPoint1;
        player1.PlayerColor = PlayerColor.Red;
        player1.PlayerType = PlayerType.Player1;

        if (playerPrefab2)
        {
            var player2 = Instantiate(playerPrefab2);
            player2.name = "Player2";
            player2.transform.position = playerStartPoint2;
            player2.PlayerColor = PlayerColor.Red;
            player2.PlayerType = PlayerType.Player2;
        }
        // treasureを配置
        var treasure1 = Instantiate(treasurePrefab);
        treasure1.name = "Treasure1";
        treasure1.transform.position = treasurePoint1;
        treasure1.Initialize(7, 27);
        traps.Add(treasure1);
        treasure1.TreasureType = TreasureType.Player1;

        var treasure2 = Instantiate(treasurePrefab);
        treasure2.name = "Treasure2";
        treasure2.transform.position = treasurePoint2;
        treasure2.Initialize(23, 27);
        traps.Add(treasure2);
        treasure2.TreasureType = TreasureType.Player2;

        // cellを配置する座標を設定
        Vector3 placePosition = new Vector3(
            topWall.position.x - topWall.localScale.x / 2 + cellPrefab.transform.localScale.x / 2,
            topWall.position.y - topWall.localScale.y / 2 + cellPrefab.transform.localScale.y / 2,
            topWall.position.z - topWall.localScale.z / 2 - cellPrefab.transform.localScale.z / 2);

        // cellを配置する幅と奥行きを調整
        Vector3 localscale = cellPrefab.transform.localScale;
        localscale.x = topWall.localScale.x / numberX;
        localscale.z = totalDepth / numberZ;
        cellPrefab.transform.localScale = localscale;

        // cellを配置
        for (int z = 0; z < numberZ; z++)
        {
            Vector3 currentPlacePosition = placePosition - Vector3.forward * cellPrefab.transform.localScale.z * z;
            for (int x = 0; x < numberX; x++)
            {
                var cell = Instantiate(cellPrefab);
                cell.transform.position = currentPlacePosition;
                currentPlacePosition.x += cellPrefab.transform.localScale.x;
                cell.Initialize(x, z);
                cells.Add(cell);
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // フィールドの初期化
    public void Initialize()
    {
        // すべてのcellの色をランダムに設定
        System.Random rnd = new System.Random();
        foreach (var cell in cells)
        {
            CellColor[] candidates = { CellColor.Red, CellColor.Blue, CellColor.Yellow };
            cell.CellColor = candidates[rnd.Next(candidates.Length)];
        }
    }

    // cellの色変更
    public void OnCellClick(Cell cell, PlayerController1 player1, PlayerController2 player2)
    {
        // cellの色をplayerと同じ色に変更
        if (player1 != null)
        {
            if (player1.PlayerColor == PlayerColor.Red)
            {
                if (!(cell.CellColor == CellColor.Red))
                {
                    colorNumber = 0;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit1();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
            else if (player1.PlayerColor == Field.PlayerColor.Blue)
            {
                if (!(cell.CellColor == Field.CellColor.Blue))
                {
                    colorNumber = 1;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit1();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
            else if (player1.PlayerColor == Field.PlayerColor.Yellow)
            {
                if (!(cell.CellColor == Field.CellColor.Yellow))
                {
                    colorNumber = 2;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit1();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
        }

        if (player2 != null)
        {
            if (player2.PlayerColor == Field.PlayerColor.Red)
            {
                if (!(cell.CellColor == Field.CellColor.Red))
                {
                    colorNumber = 0;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit2();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
            else if (player2.PlayerColor == Field.PlayerColor.Blue)
            {
                if (!(cell.CellColor == Field.CellColor.Blue))
                {
                    colorNumber = 1;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit2();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
            else if (player2.PlayerColor == Field.PlayerColor.Yellow)
            {
                if (!(cell.CellColor == Field.CellColor.Yellow))
                {
                    colorNumber = 2;
                    cell.CellColor = CurrentCellColor;
                    ChangeCellCollor(cell, player1, player2);
                    PlayerLimit.Instance.MinusLimit2();
                    SoundManager.Instance.PlaySE(8);
                }
                else
                {
                    SoundManager.Instance.PlaySE(6);
                }
            }
        }
    }

    // 指定したcellを起点にcellの色を変更する
    public void ChangeCellCollor(Cell cell, PlayerController1 player1, PlayerController2 player2)
    {
        StartCoroutine(ChangeCellCollorCoroutine(cell, player1, player2));
    }

    // 任意のcellから指定された方向に対し、異なる色のcellがあるか確認する
    bool OtherColorCell(Cell cell, CellColor cellColor, int xDirection, int zDirection)
    {
        var x = cell.X;
        var z = cell.Z;
        int turnCount = 0;

        var otherColor = false;
        while (true)
        {
            x += xDirection;
            z += zDirection;

            var targetCell = GetCell(x, z);
            if (null == targetCell || turnCount > 3)
            {
                return false;
            }
            else if (targetCell.CellColor == cellColor)
            {
                return otherColor;
            }
            else
            {
                otherColor = true;
                ++turnCount;
            }
        }

    }

    // cellの色を変更するコルーチン
    IEnumerator ChangeCellCollorCoroutine(Cell cell, PlayerController1 player1, PlayerController2 player2)
    {
        // 4方向それぞれに対し、ひっくり返す処理を実行
        ChangeCellCollorCoroutineCount = 4;
        StartCoroutine(ChangeCoroutine(cell, player1, player2, -1, 0));
        StartCoroutine(ChangeCoroutine(cell, player1, player2, 0, -1));
        StartCoroutine(ChangeCoroutine(cell, player1, player2, 0, 1));
        StartCoroutine(ChangeCoroutine(cell, player1, player2, 1, 0));

        while (ChangeCellCollorCoroutineCount > 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    // cellの色を変更するコルーチン（指定した1方向に対して処理をかける実働メソッド）
    IEnumerator ChangeCoroutine(Cell cell, PlayerController1 player1, PlayerController2 player2, int xDirection, int zDirection)
    {
        if (!OtherColorCell(cell, cell.CellColor, xDirection, zDirection))
        {
            ChangeCellCollorCoroutineCount--;
            yield break;
        }

        var x = cell.X;
        var z = cell.Z;

        while (true)
        {
            x += xDirection;
            z += zDirection;
            var targetCell = GetCell(x, z);
            var targetTrap = GetTrap(x, z);
            Vector3 trapPosition = new Vector3(targetCell.transform.position.x, targetCell.transform.position.y + 1, targetCell.transform.position.z);

            if (targetCell == null || targetCell.CellColor == cell.CellColor)
            {
                ChangeCellCollorCoroutineCount--;
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                targetCell.CellColor = cell.CellColor;

                // 相手のtreasureを同じ色のcellで挟んだら勝利
                if (targetTrap != null && 0 == targetTrap.GetType().Name.CompareTo("Trap_Treasure"))
                {
                    Trap_Treasure obj = (Trap_Treasure)targetTrap;
                    if (player1 != null)
                    {
                        if (obj.TreasureType == TreasureType.Player2 && player1.PlayerType == PlayerType.Player1)
                        {
                            SceneManager.LoadScene("Title");
                        }
                    }
                    if (player2 != null)
                    {
                        if (obj.TreasureType == TreasureType.Player1 && player2.PlayerType == PlayerType.Player2)
                        {
                            SceneManager.LoadScene("Title");
                        }
                    }
                }

                // trapの上書き
                if (targetTrap != null && 0 != targetTrap.GetType().Name.CompareTo("Trap_Treasure"))
                {
                    Destroy(targetTrap.gameObject);
                    targetTrap = null;
                }

                // 色に対応したtrapを設置
                if (targetTrap == null)
                {
                    if (cell.CellColor == CellColor.Red)
                    {
                        var trap = Instantiate(needlePrefab);
                        trap.transform.position = trapPosition;
                        trap.Initialize(x, z);
                        traps.Add(trap);
                    }
                    else if (cell.CellColor == CellColor.Blue)
                    {
                        var trap = Instantiate(slowPrefab);
                        trap.transform.position = trapPosition;
                        trap.Initialize(x, z);
                        traps.Add(trap);
                    }
                    else if (cell.CellColor == CellColor.Yellow)
                    {
                        var trap = Instantiate(electronicPrefab);
                        trap.transform.position = trapPosition;
                        trap.Initialize(x, z);
                        traps.Add(trap);
                    }
                    if (Scoreobj != null)
                    {
                        if (player1 != null)
                        {
                            Scoreobj.GetComponent<Score_Script>().p_vP1Set();
                        }
                        else if (player2 != null)
                        {
                            Scoreobj.GetComponent<Score_Script>().p_vP2Set();
                        }
                    }
                }
            }
        }
    }

    // 指定のcellを取得
    Cell GetCell(int x, int z)
    {
        return cells.FirstOrDefault(c => c.X == x && c.Z == z);
    }

    // Trapの位置を取得
    Trap GetTrap(int x, int z)
    {
        return traps.FirstOrDefault(t => t.X == x && t.Z == z);
    }
}
