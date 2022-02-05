using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isHiding = false;
    public bool lanternEnabled = false;
    public bool isDead = false;

    public float setVolume = .1f;

    public GameObject hideSpot;
    public GameObject player;
    public GameObject useHint;

    public AudioSource mainMusic;
    public AudioSource chaseMusic;

    public void Awake()
    {
        instance = this;
    }
	public void Start()
	{
        mainMusic.volume = setVolume;
        chaseMusic.volume = 0;
    }

    public void volumeFadeoutFunc()
	{
        StartCoroutine(volumeFadeout());
	}

    private IEnumerator volumeFadeout()
    {
        float lastVolume = chaseMusic.volume;
        while (chaseMusic.volume > 0)
        {
            //Debug.Log("Fadout");
            yield return new WaitForSeconds(.2f);
            chaseMusic.volume -= lastVolume / 10;
            if (chaseMusic.volume < 0)
            {
                chaseMusic.volume = 0;
            }
        }
        yield return null;
    }
}
