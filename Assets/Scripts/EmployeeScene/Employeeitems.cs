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

    public Text tName;
    public Text tHp;
    public Text tAbllity;
    public Image iFace;

    public void SetMyInfo(Employeeitems temp)
    {
        isActive = temp.isActive;
        nNum = temp.nNum;

        StInfo = temp.StInfo;
        tName.text = StInfo.Name;
        tHp.text = StInfo.State1.ToString();
        tAbllity.text = StInfo.State2.ToString();

        StInfo.Money = (StInfo.State1 / 2f) + (StInfo.State2 / 2f) + (StInfo.State3 / 2f) + (StInfo.State4 / 2f);
        //if(!isActive )
            iFace.sprite = EmployeeInfo.instance.GetEmpFace(temp.StInfo.MyFaceidx);
    }

    public void SetMyInfo(ST_EMPLOYEE_INFO temp)
    {
        StInfo = temp;
        StInfo.Money = (temp.State1 / 2f) + (temp.State2 / 2f) + (temp.State3 / 2f) + (temp.State4 / 2f);
        tName.text = temp.Name;
        tHp.text = "체력 : " + temp.State1.ToString();
        tAbllity.text = "역량 : " + temp.State2.ToString();

        iFace.sprite = EmployeeInfo.instance.GetEmpFace(temp.MyFaceidx);
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
        Panel_Select.instance.BuyEmp(GetComponent<Employeeitems>());
        //Panel_MessageBox.instance.ShowMessage(LTEXT.GetUI(LTEXTIDX.T_BUY_EMPLOYEE), "BuyEmp", Panel_Select.instance.gameObject);
    }
}
