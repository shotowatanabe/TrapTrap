using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    static Trap instance;

    // Trapのインスタンス化
    public static Trap Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    // Trapのx座標
    public int X { get { return x; } }

    // Trapのz座標
    public int Z { get { return z; } }

    int x;
    int z;

    // Cellの初期化
    public void Initialize(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
