using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
제작자  : 서형준
만든 날 : 2016-03-23
기능    : 텍스트를 읽어오는 스크립트
*/

public class LTEXT : MonoBehaviour {

    private static List<string> ltext = null;

    private static bool bInit = false;

    private static void Init(string szFile)
    {
        TextAsset texAsst = (TextAsset)Resources.Load(szFile);

        if(ltext == null)
        {
            ltext = new List<string>();
        }
        else
        {
            ltext.Clear();
            bInit = false;
        }

        if (texAsst != null)
        {
            char[] charsplit = new char[] {'\r','\n'};
            string[] token1;
            token1 = texAsst.text.Split(charsplit, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < token1.Length; ++i)
            {
                char[] charsplit2 = new char[] { ',', '\t' };
                string[] token2 = token1[i].Split(charsplit2, System.StringSplitOptions.RemoveEmptyEntries);

                if (token2 != null)
                {
                    ltext.Add(token2[1]);
                }
                else
                {
                    ltext.Add("null");
                }
            }   
        }
        bInit = true;
    }

    public static void LoadText(string szFile)
    {
        Init(szFile);
    }

    public static string Get(int i)
    {
        if (!bInit) return "null";

        if(ltext.Count < i)
        {
            return "null";
        }

        return ltext[i];
    }
}
