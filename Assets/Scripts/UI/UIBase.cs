using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBase : MonoBehaviour
{
    protected void AddListener( Button button, UnityEngine.Events.UnityAction action )
    {
        button.onClick.AddListener( action );
    }

    protected Button AddListener( string objectName, UnityEngine.Events.UnityAction action )
    {
        Button button = GameObject.Find( objectName ).GetComponent<Button>();
        button.onClick.AddListener( action );

        return button;
    }
}
