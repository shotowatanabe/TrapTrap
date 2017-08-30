using UnityEngine;
using System.Collections;

public class Trap_Treasure : Trap
{
    public int friend;
    public int playerNumber;

    public Field.TreasureType TreasureType
    {
        set
        {
            switch (value)
            {
                case Field.TreasureType.Player1:
                    playerNumber = 0;
                    break;
                case Field.TreasureType.Player2:
                    playerNumber = 1;
                    break;
            }
        }
        get
        {
            if (playerNumber == 0)
            {
                return Field.TreasureType.Player1;
            }
            else
            {
                return Field.TreasureType.Player2;
            }
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
