using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ObjectManager : Singleton<ObjectManager>
{

    private Dictionary<string, Dictionary<string, GameObject>> objectList = new Dictionary<string, Dictionary<string, GameObject>>();
    private string currentSceneName;

    void Awake()
    {

    }

    public void SetCurretScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        objectList.Add( sceneName, new Dictionary<string, GameObject>() );
        currentSceneName = sceneName;
    }

    public void SetCurrentScene( string sceneName )
    {
        objectList.Add( sceneName, new Dictionary<string, GameObject>() );
        currentSceneName = sceneName;
    }

    public void Clear( string sceneName )
    {
        objectList[ sceneName ].Clear();
    }

    public void AllClear()
    {
        Dictionary<string, Dictionary<string, GameObject>>.Enumerator iter = objectList.GetEnumerator();

        while ( iter.MoveNext() )
        {
            iter.Current.Value.Clear();
        }
        iter.Dispose();
    }
}
