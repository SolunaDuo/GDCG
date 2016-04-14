using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UIBase : MonoBehaviour, IPointerClickHandler
{
    public virtual void OnPointerClick( PointerEventData eventData )
    {
        
    }

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
