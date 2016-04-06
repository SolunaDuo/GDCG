using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Employeeitems : MonoBehaviour {

    public bool isActive;
    public int nNum; // 몇번째 인지 체크

    public ST_EMPLOYEE_INFO StInfo;

    private Text tRank;

    public void SetMyInfo(Employeeitems temp)
    {
        isActive = temp.isActive;
        nNum = temp.nNum;

        StInfo = temp.StInfo;

        tRank.text = temp.nNum.ToString();
    }

    public void OnClick()
    {
        
    }
}
