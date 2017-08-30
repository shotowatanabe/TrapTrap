using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trap01 : MonoBehaviour {

    GameObject p_gTrapA;
    Vector3 TrapA_position;
    bool Trap_UpflagA;
    bool Trap_DownflagA;
    bool Trap_WaitA;
    bool Debuff_Flag;
    bool Elec_Flag;

    public GameObject Debuff_Eff;
    public GameObject Elect_Eff;

    public float Up_PosY = 0.0f;
    public float Down_PosY = -6.0f;

    public float FTimer = 2.0f;
    public float DTimer = 10.0f;
    public float ETimer = 5.0f;

    //  ParticleSystem Ps;
    //  ParticleSystem.MinMaxCurve minmaxcurve;



    // Use this for initialization
    void Start ()
    {
        p_gTrapA = GameObject.Find("Trap_A");
        TrapA_position = p_gTrapA.transform.position;
        Trap_UpflagA = false;
        Trap_WaitA = false;

        Debuff_Flag = false;
        Elec_Flag = false;

        //  Ps = GetComponent<ParticleSystem>();
        //  minmaxcurve = Ps.emission.rate;
        //  minmaxcurve.constant = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Debuff_Flag)
        {
            DTimer -= Time.deltaTime;
            if(DTimer <= 0.0f)
            {
                //  minmaxcurve.constant = 0.0f;
                Debuff_Eff.SetActive(false);
                Debuff_Flag = false;
            }
        }

        if (Elec_Flag)
        {
            ETimer -= Time.deltaTime;
            if (ETimer <= 0.0f)
            {
                //  minmaxcurve.constant = 0.0f;
                Elect_Eff.SetActive(false);
                Elec_Flag = false;
            }
        }

        if (Trap_UpflagA)
        {
            TrapA_position.y += 1.0f;
            p_gTrapA.transform.position = TrapA_position;
            if (TrapA_position.y >= Up_PosY)
            {
                Trap_UpflagA = false;
                Trap_WaitA = true;
                SE_shot S = p_gTrapA.GetComponent<SE_shot>();
                S.DoSEShot();
            }
        }
        else if (Trap_WaitA)
        {
            FTimer -= Time.deltaTime;
            if (FTimer <= 0.0f)
            {
                Trap_WaitA = false;
                Trap_DownflagA = true;
                FTimer = 2.0f;
            }
        }
        else if (Trap_DownflagA)
        {
            TrapA_position.y -= 1.0f;
            p_gTrapA.transform.position = TrapA_position;
            if (TrapA_position.y <= Down_PosY)
            {
                Trap_DownflagA = false;
            }
        }
    }

    public void Trap_A()
    {
        if (!Trap_DownflagA && !Trap_UpflagA && !Trap_WaitA)
        {
            Trap_UpflagA = true;
        }
    }

    public void p_Debuff()
    {
        
        Debuff_Flag = true;
        Debuff_Eff.SetActive(true);
        //minmaxcurve.constant = 3.0f;
        DTimer = 10.0f;
    }

    public void p_Elec()
    {

        Elec_Flag = true;
        Elect_Eff.SetActive(true);
        //minmaxcurve.constant = 3.0f;
        ETimer = 5.0f;
    }
}
