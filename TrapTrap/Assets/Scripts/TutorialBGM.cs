using UnityEngine;
using System.Collections;

public class TutorialBGM : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        SoundManager.Instance.PlayBGM(6);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
