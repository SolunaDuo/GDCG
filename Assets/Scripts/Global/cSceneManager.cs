using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
제작자  : 서형준
만든 날 : 2016-03-23
기능    : 씬 관리 스크립트

    변경 로그

    2016-04-07 김태우
    Singleton 클래스를 상속 받도록 바꾼후 SceneChangeEvent Delegate를 통해
    씬이 바뀔때 처리할게 있을경우 대리자에 대입을 통해 할수 있도록 해보자.
*/

public delegate void SceneChangeEvent();

public class cSceneManager : Singleton<cSceneManager> {



    public Texture     FadeImg;

    private string      szSceneName = "";
    private int         nSceneLevel = -1;

    private float       fFadeTime;
    private int         nFadeDir = 0;
    private float       fAlpha;

    private int         drawDepth= -1000;

    public SceneChangeEvent changeDetect;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnGUI()
    {
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, fAlpha);

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeImg);
    }

    IEnumerator StartFade()
    {
        yield return new WaitForEndOfFrame();
        float elasptime = 0.0f;

        while(elasptime <= fFadeTime)
        {
            elasptime += Time.deltaTime;

            if(nFadeDir == 0)
                fAlpha = nFadeDir + (elasptime / fFadeTime);
            else
                fAlpha = nFadeDir - (elasptime / fFadeTime);
            yield return new WaitForEndOfFrame();
        }
        if ( !szSceneName.Equals( "" ) )
        {
            SceneManager.LoadScene( szSceneName );
            changeDetect();
        }
        if ( nSceneLevel >= 0 )
        {
            SceneManager.LoadScene( nSceneLevel );
            changeDetect();
        }

        fAlpha = 0.0f;

    }

    public void LoadLevel(string name,float fadetime)
    {
        fFadeTime = fadetime;

        szSceneName = name;
        nSceneLevel = -1;

        StartCoroutine( StartFade() );
    }

    public void LoadLevel(int level, float fadetime)
    {
        fFadeTime = fadetime;

        szSceneName = "";
        nSceneLevel = level;

        StartCoroutine(StartFade());
    }
}
