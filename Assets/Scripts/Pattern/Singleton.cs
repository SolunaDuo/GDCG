using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
{
    protected static T pInstance;

    public static T instance
    {
        get
        {
            if ( pInstance == null )
            {
                pInstance = FindObjectOfType<T>();
                if ( pInstance == null )
                {
                    //pInstance = new GameObject( typeof( T ).Name ).AddComponent<T>();
                    pInstance = Camera.main.gameObject.AddComponent<T>();
                }
            }

            return pInstance;
        }
    }
}
