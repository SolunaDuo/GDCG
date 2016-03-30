using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
제작자  : 서형준
만든 날 : 2016-03-23
기능    : 씬 관리 스크립트
*/

public class cSceneManager : MonoBehaviour {
    private static cSceneManager Instance = null;


    public Texture     FadeImg;

    private string      szSceneName = "";
    private int         nSceneLevel = -1;

    private float       fFadeTime;
    private int         nFadeDir = 0;
    private float       fAlpha;

    private int         drawDepth= -1000;


    public static cSceneManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = GameObject.Find("SCENEMGR").GetComponent< cSceneManager>();
            }
            return Instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
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
        if (!szSceneName.Equals(""))
            SceneManager.LoadScene(szSceneName);
        if(nSceneLevel >= 0 )
            SceneManager.LoadScene(nSceneLevel);

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
