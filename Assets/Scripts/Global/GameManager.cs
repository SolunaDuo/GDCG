using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//public struct ST_GENRE
//{
//    public string Name;
//    public int Money;
//}

public enum GamePlatforms
{
    PC,
    IOS,
    ANDROID,
}

public class GameManager : Singleton<GameManager> {

    //List<ST_GENRE> listGenre = new List<ST_GENRE>();
    private Dictionary<GamePlatforms, string> platformList = new Dictionary<GamePlatforms, string>();
    private Dictionary<string, int> genreList = new Dictionary<string, int>();

    public List<ST_EMPLOYEE_INFO> listMyEmp = new List<ST_EMPLOYEE_INFO>();
    public float MyMoney = 0.0f;
    public float MoneyPlus = 0.0f; // 분당 들어오는 돈

    [SerializeField]
    private TextAsset jsonData;
    void Awake()
    {
        
    }

    public void LoadJson()
    {
        jsonData = Resources.Load<TextAsset>( "Text/Info" );
        LoadGameInfo();
    }

    // Use this for initialization
    void Start() {
        
        DataSaveLoad.instance.LoadData( ref listMyEmp, "MyEmp" );
    }
    #region 
    // 장르
    void LoadGameInfo()
    {
        LitJson.JsonData getData = LitJson.JsonMapper.ToObject( jsonData.text );

        if ( genreList.Count == 0 && platformList.Count == 0 )
        {
            for ( int i = 0; i < getData[ "Genre" ].Count; ++i )
            {
                //ST_GENRE temp = new ST_GENRE();
                //temp.Name = getData["Genre"][i]["Name"].ToString();
                //temp.Money = Convert.ToInt32(getData["Genre"][i]["Money"].ToString());
                string keyName = getData[ "Genre" ][ i ][ "Name" ].ToString();
                int valueMoney = Convert.ToInt32( getData[ "Genre" ][ i ][ "Money" ].ToString() );

                genreList.Add( keyName, valueMoney );
            }

            for ( int i = 0; i < getData[ "Platform" ].Count; i++ )
            {
                string platform = getData[ "Platform" ][ i ].ToString();

                platformList.Add( ( GamePlatforms ) i, platform );
            }
        }
    }

    public IEnumerable<Tools.Tuple.Tuple<string, int>> GetGenre()
    {
        Dictionary<string, int>.Enumerator genreIter = genreList.GetEnumerator();

        while ( genreIter.MoveNext() )
        {
            Debug.Log( "Returned" );
            yield return new Tools.Tuple.Tuple<string, int>( genreIter.Current.Key, genreIter.Current.Value );
        }
    }

    public IEnumerable<string> GetPlatform()
    {
        Dictionary<GamePlatforms, string>.Enumerator platformIter = platformList.GetEnumerator();
        while ( platformIter.MoveNext() )
        {
            yield return platformIter.Current.Value;
        }
    }

    public int GetGenre( string key )
    {
        return genreList[ key ];
    }

    public string GetPlatform( GamePlatforms platform )
    {
        return platformList[ platform ];
    }

    //public ST_GENRE GetGenre(int idx)
    //{
    //    if (idx < listGenre.Count)
    //        return listGenre[idx];

    //    ST_GENRE temp = new ST_GENRE();
    //    temp.Money = 0;
    //    temp.Name = "null";

    //    return temp;
    //}
    #endregion

    public void PlusMyMoney(float fplus)
    {
        MoneyPlus += fplus;

        PlayerPrefs.SetFloat("MoneyPlus", MoneyPlus);
    }
}
