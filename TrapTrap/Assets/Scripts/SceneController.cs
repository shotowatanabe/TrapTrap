using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
    //public static SceneController Instance
    //{
    //    get { return instance; }
    //}

    //static SceneController instance;

    //public Field field;

    //int colorNumber;

    //Field.CellColor CurrentCellColor
    //{
    //    get { return (Field.CellColor)((colorNumber)); }
    //}

    //void Awake()
    //{
    //    instance = this;
    //}

    //void Start()
    //{
    //    GameStart();
    //}
    
    //// ゲームを開始します
    //public void GameStart()
    //{
    //    //turnNumber = 0;
    //    field.Initialize();
    //    //IncrementTurnNumber();
    //}

    //// cellの色変更
    //public void OnCellClick(Cell cell, PlayerController1 player1, PlayerController2 player2)
    //{
    //    // cellの色をplayerと同じ色に変更
    //    if (player1 != null)
    //    {
    //        if (player1.PlayerColor == Field.PlayerColor.Red)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Red))
    //            {
    //                colorNumber = 0;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit1();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //        else if (player1.PlayerColor == Field.PlayerColor.Blue)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Blue))
    //            {
    //                colorNumber = 1;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit1();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //        else if (player1.PlayerColor == Field.PlayerColor.Yellow)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Yellow))
    //            {
    //                colorNumber = 2;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit1();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //    }

    //    if (player2 != null)
    //    {
    //        if (player2.PlayerColor == Field.PlayerColor.Red)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Red))
    //            {
    //                colorNumber = 0;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit2();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //        else if (player2.PlayerColor == Field.PlayerColor.Blue)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Blue))
    //            {
    //                colorNumber = 1;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit2();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //        else if (player2.PlayerColor == Field.PlayerColor.Yellow)
    //        {
    //            if (!(cell.CellColor == Field.CellColor.Yellow))
    //            {
    //                colorNumber = 2;
    //                cell.CellColor = Instance.CurrentCellColor;
    //                field.ChangeCellCollor(cell, player1, player2);
    //                PlayerLimit.Instance.MinusLimit2();
    //                SoundManager.Instance.PlaySE(8);
    //            }
    //            else
    //            {
    //                SoundManager.Instance.PlaySE(6);
    //            }
    //        }
    //    }
    //}
}