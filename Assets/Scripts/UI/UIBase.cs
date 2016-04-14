using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UIBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    protected struct TEMP_PLATFORMSTRING
    {
        public const string PLATFORM_PC = "PC";
        public const string PLATFORM_ANDROID = "Android";
        public const string PLATFORM_IOS = "IOS";
    }

    protected struct TEMP_GENRESTRING
    {
        public const string GENRE_PUZZLE = "퍼즐";
        public const string GENRE_BOARD = "보드";
        public const string GENRE_ARCADE = "아케이드";
        public const string GENRE_ROLEPLAYING = "롤플레잉";
        public const string GENRE_ACTION = "액션";
    }

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
