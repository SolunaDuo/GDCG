using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UIBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{


    #region For Test
    protected const float dropDownWidth = 332.1f;
    protected const float dropDownHeight = 40f;
    protected const float dropDownPosX = 166.05f;
    protected const float dropDownPosY = 0f;
    protected const int Layer_UI = 5;

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
    #endregion

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

    protected void AddListener( Button button, UnityAction action )
    {
        button.onClick.AddListener( action );
    }

    protected Button AddListener( string objectName, UnityAction action )
    {
        Button button = GameObject.Find( objectName ).GetComponent<Button>();
        button.onClick.AddListener( action );

        return button;
    }

    protected void CreateDropDownMenu( Transform parent, string menuName, string containerName, UnityAction buttonEvent )
    {
        RectTransform container = parent.FindChild( containerName ).GetComponent<RectTransform>();

        GameObject dropDownElement = new GameObject( menuName );
        dropDownElement.transform.SetParent( container );
        dropDownElement.AddComponent<Elemennt>();

        dropDownElement.layer = Layer_UI;

        RectTransform elementTransform = dropDownElement.AddComponent<RectTransform>();
        elementTransform.sizeDelta = new Vector2( dropDownWidth, dropDownHeight );
        elementTransform.anchoredPosition3D = new Vector3( 0, 0, 0 );
        elementTransform.anchoredPosition = new Vector2( dropDownPosX, dropDownPosY );
        elementTransform.localScale = new Vector3( 1, 1, 1 );
        elementTransform.localPosition.Set( 0, 0, 0 );

        CanvasRenderer elementRenderer = dropDownElement.AddComponent<CanvasRenderer>();
        Image elementImage = dropDownElement.AddComponent<Image>();
        elementImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>( "UI/Skin/UISprite.psd" );
        elementImage.type = Image.Type.Sliced;

        Button elementButton = dropDownElement.AddComponent<Button>();
        elementButton.interactable = true;
        if ( buttonEvent != null )
        {
            elementButton.onClick.AddListener( buttonEvent );
        }
        else
        {
            elementButton.onClick.AddListener( () => { DefaultListener(); } );
        }

        dropDownElement.AddComponent<LayoutElement>().minHeight = 40f;

        CreateText( elementTransform, menuName, true, Color.black );
    }

    protected void CreateText( Transform parent, string message, bool bestFit, Color textColor )
    {
        GameObject textObject = new GameObject( "Text" );
        textObject.transform.SetParent( parent );
        textObject.layer = Layer_UI;

        RectTransform textTransform = textObject.AddComponent<RectTransform>();
        textTransform.anchorMin = new Vector2( 0, 0 );
        textTransform.anchorMax = new Vector2( 1, 1 );
        textTransform.pivot = new Vector2( 0.5f, 0.5f );
        //textTransform.sizeDelta.Set( 0, 0 );
        //textTransform.anchoredPosition3D = new Vector3( 0, 0, 0 );
        //textTransform.anchoredPosition = new Vector2( 0, 0 );
        textTransform.offsetMin = new Vector2( 0, 0 );
        textTransform.offsetMax = new Vector2( 0, 0 );
        textTransform.localScale = new Vector3( 1, 1, 1 );
        textTransform.localPosition.Set( 0, 0, 0 );

        CanvasRenderer renderer = textObject.AddComponent<CanvasRenderer>();

        Text text = textObject.AddComponent<Text>();
        text.supportRichText = true;
        text.text = message;
        text.font = Resources.GetBuiltinResource<Font>( "Arial.ttf" );
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
        text.resizeTextForBestFit = bestFit;
    }

    private void DefaultListener() { }
}
