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

    public Text tName;
    public Text tHp;
    public Text tAbllity;

    public void SetMyInfo(Employeeitems temp)
    {
        isActive = temp.isActive;
        nNum = temp.nNum;

        StInfo = temp.StInfo;
        if (tName != null && tHp != null && tAbllity != null)
        {
            tName.text = StInfo.Name;
            tHp.text = StInfo.State1.ToString();
            tAbllity.text = StInfo.State2.ToString();
        }

        tRank.text = temp.nNum.ToString();
    }

    public void OnClick()
    {
        if(isActive)
            Panel_Employee.instance.ShowInfo(this.GetComponent<Employeeitems>());
        else
        {

        }
            // 직원 뽑는 팝업 생성
    }

    public void OnSelectClick()
    {
        GameManager.instance.listMyEmp.Add(StInfo);
        gameObject.SetActive(false);
        DataSaveLoad.instance.SaveData(GameManager.instance.listMyEmp, "MyEmp");
    }
}
