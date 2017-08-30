using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Movie_Script : MonoBehaviour
{
    private AudioSource BGM01;
    float B_volume;
    //private bool B_FadeFlag = false;

    //float BGMsub = 0.0025f;

    public MovieTexture move;

    void Start()
    {
        //  move = GetComponent<RawImage>().texture;
        BGM01 = GetComponent<AudioSource>();

        B_volume = BGM01.volume;

        move.Play();
    }
}