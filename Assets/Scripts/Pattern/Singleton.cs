using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
{
    protected static T pInstance;

    public T instance
    {
        get
        {
            if ( pInstance == null )
            {
                pInstance = FindObjectOfType<T>();
                if ( pInstance == null )
                {
                    pInstance = new GameObject( typeof( T ).Name ).AddComponent<T>();
                }
            }

            return pInstance;
        }
    }
}
