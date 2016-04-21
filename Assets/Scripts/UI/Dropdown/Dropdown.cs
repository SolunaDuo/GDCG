using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
//using System.Linq;

public class Dropdown : UIBase
{
    private RectTransform container;
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private float dropSpeed;

    UnityEngine.UI.Text containerName;

    // Use this for initialization
    void Awake()
    {
        container = transform.FindChild( "Container" ).GetComponent<RectTransform>();
        containerName = transform.FindChild( "Text" ).GetComponent<UnityEngine.UI.Text>();
        isOpen = false;
        container.localScale = new Vector3( 1f, 0f, 1f );

        UnityEngine.Events.UnityAction buttonAction = () => { DropDownMenuClick(); };

        GameManager.instance.LoadJson();

        if ( gameObject.name.Contains( "Genre" ) )
        {
            foreach ( var genreData in GameManager.instance.GetGenre() )
            {
                CreateDropDownMenu( transform, genreData.first, "Container", buttonAction );
            }
        }
        else if ( gameObject.name.Contains( "Platform" ) )
        {
            foreach ( var platformData in GameManager.instance.GetPlatform() )
            {
                CreateDropDownMenu( transform, platformData, "Container", buttonAction );
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vScale = container.localScale;
        vScale.y = Mathf.Lerp( vScale.y, isOpen ? 1 : 0, Time.deltaTime * dropSpeed );
        container.localScale = vScale;
    }

    public override void OnPointerClick( PointerEventData eventData )
    {
        isOpen = !isOpen;
    }

    private void DropDownMenuClick()
    {
        isOpen = !isOpen;
        containerName.text = EventSystem.current.currentSelectedGameObject.name;
    }
}
