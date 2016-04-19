using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_MessageBox : Singleton<Panel_MessageBox>
{
    public Text tText;

    private string strMethod;
    private GameObject GameObj;

    // Use this for initialization
    void Start()
    {
        tText = GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Enable( bool onoff )
    {
        if ( onoff )
        {
            transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
        }
        else
        {
            transform.localScale = new Vector3( 0.0f, 0.0f, 0.0f );
        }
    }

    // 함수를 실행시키지 않을꺼면 functionValue 를 ""로..
    public void ShowMessage( string strMsg, string strmethod = "", GameObject gameobj = null )
    {
        Enable( true );
        tText.text = strMsg;

        // FunctionValue = functionvalue;
        strMethod = strmethod;
        GameObj = gameobj;
    }

    public void OnOK()
    {
        if ( strMethod.Equals( "" ) && GameObj == null )
        {
            gameObject.SetActive( false );
            return;
        }

        //if (FunctionValue.Equals(""))
        GameObj.SendMessage( strMethod );
        /* else
             GameObj.SendMessage(strMethod, FunctionValue);*/
    }

    public void OnNO()
    {
        gameObject.SetActive( false );
    }
}
