using UnityEngine;
using System.Collections;

public class MainBGM : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        SoundManager.Instance.PlayBGM(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
