using UnityEngine;
using System.Collections;

public class TitleBGM : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        SoundManager.Instance.PlayBGM(4);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
