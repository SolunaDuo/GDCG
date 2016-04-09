using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenu : MonoBehaviour
{

    private Button charButton;

    // Use this for initialization
    void Awake()
    {
        charButton = GameObject.Find( "Char" ).GetComponent<Button>();
        charButton.onClick.AddListener( () => { CharacterButton(); } );
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CharacterButton()
    {

    }

}
