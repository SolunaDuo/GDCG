using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
제작자  : 서형준
만든 날 : 2016-03-31
기능    : 직원 관리 팝업 패널 스크립트.
*/

public class Employeeitems : MonoBehaviour {

    public bool isActive;
    public int nNum; // 몇번째 인지 체크

    public ST_EMPLOYEE_INFO StInfo;

    public Text tRank;

    public void SetMyInfo(Employeeitems temp)
    {
        isActive = temp.isActive;
        nNum = temp.nNum;

        StInfo = temp.StInfo;

        tRank.text = temp.nNum.ToString();
    }

    public void OnClick()
    {
        //if(isActive)
         Panel_Employee.instance.ShowInfo(this.GetComponent<Employeeitems>());
        //else
            // 직원 뽑는 팝업 생성
    }
}
