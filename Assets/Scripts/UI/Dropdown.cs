using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dropdown : UIBase
{
    private RectTransform container;
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private float dropSpeed;

    // Use this for initialization
    void Awake()
    {
        container = transform.FindChild( "Container" ).GetComponent<RectTransform>();
        isOpen = false;
        container.localScale = new Vector3( 1f, 0f, 1f );
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
}
