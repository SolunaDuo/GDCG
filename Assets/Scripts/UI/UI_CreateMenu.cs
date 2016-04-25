using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_CreateMenu : UIBase
{

    private Button btnChar;
    //private Button btnManagement;
    //private Button btnCreate;
    private GameObject btnManage;
    private GameObject btnCreate;
    private GameObject createPanel;

    [SerializeField]
    private bool gameMenuFLAG = false;

    private List<GameObject> createSequence = new List<GameObject>();

    // Use this for initialization
    void Awake()
    {
        btnChar = AddListener( "Char", () => { CharacterButton(); } );
        btnManage = AddListener( "BtnManage", () => { ManageButton(); } ).gameObject;
        btnCreate = AddListener( "BtnCreate", () => { CreateButton(); } ).gameObject;
        AddListener( "BtnNext", () => { Create_nextStep(); } );
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

    private void Create_nextStep()
    {

    }
}
