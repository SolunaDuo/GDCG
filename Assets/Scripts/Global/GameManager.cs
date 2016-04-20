using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public struct ST_GENRE
{
    public string Name;
    public int Money;
}

public class GameManager : Singleton<GameManager> {

    List<ST_GENRE> listGenre = new List<ST_GENRE>();

    public List<ST_EMPLOYEE_INFO> listMyEmp = new List<ST_EMPLOYEE_INFO>();

    public float MyMoney = 0.0f;
    public float MoneyPlus = 0.0f; // 분당 들어오는 돈

    [SerializeField]
    private TextAsset jsonData;
    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        LoadGameInfo();
        DataSaveLoad.instance.LoadData(ref listMyEmp, "MyEmp");
        Debug.Log(listMyEmp);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    #region 
    // 장르
    void LoadGameInfo()
    {
        LitJson.JsonData getData = LitJson.JsonMapper.ToObject(jsonData.text);

        for(int i=0; i<getData["Genre"].Count;++i)
        {
            ST_GENRE temp = new ST_GENRE();
            temp.Name = getData["Genre"][i]["Name"].ToString();
            temp.Money = Convert.ToInt32(getData["Genre"][i]["Money"].ToString());

            listGenre.Add(temp);
        }
    }

    public ST_GENRE GetGenre(int idx)
    {
        if (idx < listGenre.Count)
            return listGenre[idx];

        ST_GENRE temp = new ST_GENRE();
        temp.Money = 0;
        temp.Name = "null";

        return temp;
    }

    public void PlusMyMoney(float fplus)
    {
        MoneyPlus += fplus;

        PlayerPrefs.SetFloat("MoneyPlus", MoneyPlus);
    }
    #endregion
}
