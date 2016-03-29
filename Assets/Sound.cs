using UnityEngine;
using System.Collections;

/*
제작자  : 서형준
만든 날 : 2016-03-30
기능    : 사운드를 읽어와 재생시키는 스크립트. 오디오 클립안에 넣으면됨.

*/


public enum SOUNDIDX
{
    S_MAX = 0
}

public class Sound : MonoBehaviour {
    public static Sound instance = null;

    private float volum = 0.0f;

    public AudioSource EffSound;
    public AudioSource BgmSound;

    private AudioClip[] clips;


    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
        clips = new AudioClip[(int)SOUNDIDX.S_MAX];

        InitSound();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // Mute가 true이면 소리가 안들림
    public void SetMute(bool Mute)
    {
        EffSound.mute = Mute;
        BgmSound.mute = Mute;
    }

    public void SetVolum(float fv)
    {
        volum = fv;
    }

    public void PlayEff(SOUNDIDX idx)
    {
        if(!EffSound.isPlaying)
        {
            EffSound.PlayOneShot(clips[(int)idx], volum);
        }
    }

    public void BgmEff(SOUNDIDX idx)
    {
        if (!BgmSound.isPlaying)
        {
            BgmSound.loop = true;
            BgmSound.PlayOneShot(clips[(int)idx], volum);
        }
    }

    void InitSound()
    {

    }
}
