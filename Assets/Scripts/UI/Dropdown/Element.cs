using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Elemennt : UIBase
{
    public string buttonText { get; private set; }

    public override void OnPointerClick( PointerEventData eventData )
    {
        buttonText = gameObject.name;
    }
}
