using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public struct ST_GENRE
{
    public string Name;
    public int Money;
}

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    List<ST_GENRE> listGenre = new List<ST_GENRE>();

    [SerializeField]
    private TextAsset jsonData;
    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        LoadGameInfo();

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
    #endregion
}
