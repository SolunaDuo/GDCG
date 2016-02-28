using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
{
    protected static T instance;

    public void CreateInstance()
    {
        if ( instance == null )
        {
            GameObject ins = new GameObject( typeof( T ).Name );
        }
    }

    public static T get()
    {
        if ( instance == null )
        {
            instance = FindObjectOfType<T>();
            if ( instance == null )
            {
                GameObject ins = new GameObject( typeof( T ).Name );
            }
        }

        return instance;
    }
}
