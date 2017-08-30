//using UnityEngine;
//using System.Collections;

//public class Gauge : MonoBehaviour {

//    public int limiter_g;
//    public bool mode;

//	// Use this for initialization
//	void Start () {

        
        
//	}
	
//	// Update is called once per frame
//	void Update () {
//        limiter_g = PlayerLimit.Instance.limiter;
//        mode = PlayerController1.Instance.isFlying;

//        GameObject gauge1 = this.transform.Find("Image1").gameObject;
//        GameObject gauge2 = this.transform.Find("Image2").gameObject;
//        GameObject gauge3 = this.transform.Find("Image3").gameObject;
//        GameObject gauge4 = this.transform.Find("Image4").gameObject;
//        GameObject gauge5 = this.transform.Find("Image5").gameObject;
//        GameObject gauge6 = this.transform.Find("Image6").gameObject;
//        GameObject gauge7 = this.transform.Find("Image7").gameObject;
//        GameObject gauge8 = this.transform.Find("Image8").gameObject;
//        GameObject gauge9 = this.transform.Find("Image9").gameObject;
//        GameObject gauge10 = this.transform.Find("Image10").gameObject;


//        GameObject UI = this.transform.Find("UI").gameObject;
//        GameObject UI1 = this.transform.Find("UI1").gameObject;

//        gauge1.gameObject.SetActive(false);
//        gauge2.gameObject.SetActive(false);
//        gauge3.gameObject.SetActive(false);
//        gauge4.gameObject.SetActive(false);
//        gauge5.gameObject.SetActive(false);
//        gauge6.gameObject.SetActive(false);
//        gauge7.gameObject.SetActive(false);
//        gauge8.gameObject.SetActive(false);
//        gauge9.gameObject.SetActive(false);
//        gauge10.gameObject.SetActive(false);

//        UI.gameObject.SetActive(false);
//        UI1.gameObject.SetActive(false);



//        if (limiter_g >= 1)
//            gauge1.gameObject.SetActive(true);
//        if (limiter_g >= 2)
//            gauge2.gameObject.SetActive(true);
//        if (limiter_g >= 3)
//            gauge3.gameObject.SetActive(true);
//        if (limiter_g >= 4)
//            gauge4.gameObject.SetActive(true);
//        if (limiter_g >= 5)
//            gauge5.gameObject.SetActive(true);
//        if (limiter_g >= 6)
//            gauge6.gameObject.SetActive(true);
//        if (limiter_g >= 7)
//            gauge7.gameObject.SetActive(true);
//        if (limiter_g >= 8)
//            gauge8.gameObject.SetActive(true);
//        if (limiter_g >= 9)
//            gauge9.gameObject.SetActive(true);
//        if (limiter_g >= 10)
//            gauge10.gameObject.SetActive(true);

//        if (mode)
//            UI.gameObject.SetActive(true);
//        else
//            UI1.gameObject.SetActive(true);
        





//    }
//}
