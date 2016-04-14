using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenu : UIBase
{

    private Button btnChar;
    //private Button btnManagement;
    //private Button btnCreate;
    private GameObject btnManage;
    private GameObject btnCreate;
    private GameObject createPanel;

    [SerializeField]
    private bool gameMenuFLAG = false;

    // Use this for initialization
    void Awake()
    {
        btnChar = AddListener( "Char", () => { CharacterButton(); } );
        btnManage = AddListener( "BtnManage", () => { ManageButton(); } ).gameObject;
        btnCreate = AddListener( "BtnCreate", () => { CreateButton(); } ).gameObject;
        btnManage.SetActive( gameMenuFLAG );
        btnCreate.SetActive( gameMenuFLAG );

        createPanel = GameObject.Find( "CreatePanel" );
        createPanel.SetActive( false );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CharacterButton()
    {
        gameMenuFLAG = !gameMenuFLAG;

        btnManage.SetActive( gameMenuFLAG );
        btnCreate.SetActive( gameMenuFLAG );
    }

    private void ManageButton()
    {

    }

    private void CreateButton()
    {
        btnManage.SetActive( false );
        btnCreate.SetActive( false );
        createPanel.SetActive( true );
    }
}
