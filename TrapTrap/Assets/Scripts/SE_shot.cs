using UnityEngine;
using System.Collections;

public class SE_shot : MonoBehaviour {

    private AudioSource sound01;

    // Use this for initialization
    void Start () {
        sound01 = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoSEShot()
    {
        sound01.PlayOneShot(sound01.clip);
    }
}
