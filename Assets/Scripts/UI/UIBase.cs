using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UIBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public virtual void OnPointerClick( PointerEventData eventData )
    {
        Debug.Log( "Pointer Click" );
    }

    public virtual void OnPointerDown( PointerEventData eventData )
    {
        Debug.Log( "Pointer Down" );
    }

    public virtual void OnPointerEnter( PointerEventData eventData )
    {
        Debug.Log( "Pointer Enter" );
    }

    public virtual void OnPointerExit( PointerEventData eventData )
    {
        Debug.Log( "Pointer Exit" );
    }

    public virtual void OnPointerUp( PointerEventData eventData )
    {
        Debug.Log( "Pointer Up" );
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
