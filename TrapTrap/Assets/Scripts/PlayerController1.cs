using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private Quaternion fromRotation;
    private Quaternion toRotation;
    private Vector3 fromPosition;
    private Vector3 toPosition;
    public GameObject child1;
    public GameObject child2;
    private GameObject pDebuff1;
    public GameObject p_DebuffEfct;
    public Material[] material;
    private Animator anim;
    private static PlayerController1 instance;

    private float rotationTime = 0;
    private float movementTime = 0;
    public float rotationSpeed = 2.0f;
    public float movementSpeed = 2.0f;
    public float slowTime = 10;
    public int height = 2;
    private int layerMask;
    public int colorNumber;
    private int playerNumber;

    public bool isRotate = false;
    public bool isMove = false;
    public bool isFlying = false;
    public bool input = true;
    public bool slow = false;
    private bool DFlag1 = false;
    
    public static PlayerController1 Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    // Playerの色を割り当てる
    public Field.PlayerColor PlayerColor
    {
        set
        {
            switch (value)
            {
                case Field.PlayerColor.Red:
                    child2.GetComponent<Renderer>().material = material[0];
                    colorNumber = 0;
                    break;

                case Field.PlayerColor.Blue:
                    child2.GetComponent<Renderer>().material = material[1];
                    colorNumber = 1;
                    break;

                case Field.PlayerColor.Yellow:
                    child2.GetComponent<Renderer>().material = material[2];
                    colorNumber = 2;
                    break;
            }
        }
        get
        {
            if (colorNumber == 0)
            {
                return Field.PlayerColor.Red;
            }
            else if (colorNumber == 1)
            {
                return Field.PlayerColor.Blue;
            }
            else
            {
                return Field.PlayerColor.Yellow;
            }
        }
    }

    // playerのタイプを割り当てる
    public Field.PlayerType PlayerType
    {
        set
        {
            switch (value)
            {
                case Field.PlayerType.Player1:
                    playerNumber = 0;
                    break;
                case Field.PlayerType.Player2:
                    playerNumber = 1;
                    break;
            }
        }
        get
        {
            if (playerNumber == 0)
            {
                return Field.PlayerType.Player1;
            }
            else
            {
                return Field.PlayerType.Player2;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
        anim = child1.GetComponent<Animator>();

        input = true;

        layerMask = LayerMask.GetMask(new string[] { "Stage", "Treasure", "Player2" });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            ++colorNumber;
        }

        if (colorNumber > 2)
        {
            colorNumber = 0;
        }

        child2.GetComponent<Renderer>().material = material[colorNumber];


        // playerの方向転換
        float directionY = 0.0f;
        if (input == true)
        {
            directionY = Input.GetAxisRaw("Horizontal");
            if (directionY > 0)
            {
                directionY = 1;
            }
            else if (directionY < 0)
            {
                directionY = -1;
            }
            else
            {
                directionY = 0;
            }
        }

        // キー入力がある　&&　方向転換中でない　&&　移動中でない場合、方向転換する
        if (directionY != 0 && !isRotate && !isMove)
        {
            fromRotation = transform.rotation;                      // 方向転換前のクォータニオン
            transform.Rotate(0, directionY * 90, 0, Space.World);   // 90度方向転換
            toRotation = transform.rotation;                        // 方向転換後のクォータニオン
            transform.rotation = fromRotation;                      // Rotationを方向転換前に戻す
            rotationTime = 0;                                       // 方向転換中の経過時間を0に
            isRotate = true;                                        // 方向転換中のフラグを立てる
        }

        if (isRotate)
        {
            rotationTime += Time.deltaTime;
            float ratio = rotationTime * rotationSpeed;

            // 方向転換
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);

            // 方向転換終了時に各パラメータを初期化して方向転換中のフラグを下ろす
            if (ratio >= 1)
            {
                isRotate = false;
                directionY = 0;
                rotationTime = 0;
            }
        }

        // Playerの移動
        float directionZ = 0.0f;
        if (input == true)
        {
            directionZ = Input.GetAxisRaw("Vertical");
            if (directionZ > 0)
            {
                directionZ = 1;
            }
            else if (directionZ < 0)
            {
                directionZ = -1;
            }
            else
            {
                directionZ = 0;
            }
        }

        // キー入力がある　&&　方向転換中でない　&&　移動中でない場合、前後移動する
        if (directionZ != 0 && !isRotate && !isMove)
        {
            // 進行方向にレイを飛ばして障害物がなければ移動する
            Ray ray = new Ray(transform.position, transform.forward * (int)Mathf.Sign(directionZ));
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit, 1.0f, layerMask))
            {
                PlayerLimit.Instance.PlusLimit1();

                if (PlayerLimit.Instance.limit1 == false)
                {
                    fromPosition = transform.position;                      // 移動前のポジション
                    transform.position += transform.forward * directionZ;   // 1m移動
                    toPosition = transform.position;                        // 移動後のポジション
                    transform.position = fromPosition;                      // Positionを移動前に戻す
                    movementTime = 0;                                       // 移動中の経過時間を0に
                    isMove = true;

                    SoundManager.Instance.PlaySE(3);
                }
                //else
                //{
                //    SoundManager.Instance.PlaySE(3);
                //}
            }
        }

        // spaceキーが押された　&&　方向転換中でない　&&　移動中でない場合、上下移動する
        if (input == true)
        {
            if (Input.GetButtonDown("Fire2") && !isRotate && !isMove)
            {
                // 地上形態
                if (!isFlying)
                {
                    // 進行方向にレイを飛ばして障害物がなければ上昇する
                    Ray ray = new Ray(transform.position, transform.up);
                    RaycastHit hit;
                    if (!Physics.Raycast(ray, out hit, height, layerMask))
                    {
                        fromPosition = transform.position;              // 移動前のポジション
                        transform.position += transform.up * height;    // 上昇
                        toPosition = transform.position;                // 移動後のポジション
                        transform.position = fromPosition;              // Positionを移動前に戻す
                        movementTime = 0;                               // 移動中の経過時間を0に
                        isMove = true;                                  // 移動中のフラグを立てる
                        isFlying = !isFlying;

                        anim.SetBool("Flying", true);
                        SoundManager.Instance.PlaySE(7);
                    }
                }

                // 飛行形態
                if (isFlying)
                {
                    // 進行方向にレイを飛ばして障害物がなければ移動する
                    Ray ray = new Ray(transform.position, -transform.up);
                    RaycastHit hit;
                    if (!Physics.Raycast(ray, out hit, height, layerMask))
                    {
                        fromPosition = transform.position;              // 移動前のポジション
                        transform.position -= transform.up * height;    // 下降
                        toPosition = transform.position;                // 移動後のポジション
                        transform.position = fromPosition;              // Positionを移動前に戻す
                        movementTime = 0;                               // 移動中の経過時間を0に
                        isMove = true;                                  // 移動中のフラグを立てる
                        isFlying = !isFlying;

                        anim.SetBool("Flying", false);
                        SoundManager.Instance.PlaySE(7);
                    }
                }
            }
        }

        if (isMove)
        {
            movementTime += Time.deltaTime;
            float ratio2 = movementTime * movementSpeed;

            // 移動
            transform.position = Vector3.Lerp(fromPosition, toPosition, ratio2);

            // 移動終了時に各パラメータを初期化して移動中のフラグを下ろす
            if (ratio2 >= 1)
            {
                isMove = false;
                directionZ = 0;
                movementTime = 0;
            }
        }

        if (slow)
        {
            movementSpeed = 0.5f;

            if (DFlag1 == false)
            {
                DFlag1 = true;

                pDebuff1 = Instantiate(p_DebuffEfct);
                pDebuff1.name = "Debf_Efct01";
                pDebuff1.transform.position = transform.position;
            }

            if (DFlag1)
            {
                pDebuff1.transform.position = transform.position;
            }

            slowTime -= Time.deltaTime;

            if (slowTime < 0)
            {
                movementSpeed = 2;
                slowTime = 10;
                Destroy(pDebuff1);
                DFlag1 = false;
                slow = false;
            }
        }
    }

    public void Release()
    {
        input = true;
    }

    public void ChangeCellColorAnim()
    {
        anim.SetTrigger("Change");
    }
}
