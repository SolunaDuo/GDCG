using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
제작자  : 서형준
만든 날 : 2016-03-31
기능    : 직원 관리 팝업 패널 스크립트.
*/



public class Panel_Employee : Singleton<Panel_Employee> {
   // public static Panel_Employee instance = null;

    List<Employeeitems> listMyEmployee = new List<Employeeitems>();  // 직원 리스트
    public GameObject pfEmpItem;

    public GameObject panel_grid;   // 그리드 패널

    public Text tName;

    public Text[] tStates;

    public RectTransform tr_Grid;

    [SerializeField]
    private Image iFace;

    private float fItemHegit = -100f;

    private int nSeleteNum = -1;

    // 코드 위치는 보기 좋은곳으로...
    public Employeeitems GetEmployee( int index )
    {
        return listMyEmployee[ index ];
    }
    // 코드 위치는 보기 좋은곳으로...
	// Use this for initialization
	void Start () {

        InitMyEmpList();

        Enable(false);
    }

    public void Enable(bool onoff)
    {
        if (onoff)
        {
            ReSetEmpData();
            tr_Grid.anchoredPosition = new Vector2(tr_Grid.anchoredPosition.x, -500f);
            gameObject.GetComponent<Animator>().Play("ShowPopup");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("idle");
        }
    }
    // 내 직원 리스트 세팅 bact 가 flase일 경우에는 프리팹을 새로 만들어줌
    // true일 경우에는 기본 프리팹에서 정보만 업데이트
    public void CreatMyEmployee(ST_EMPLOYEE_INFO temp)
    {
        Employeeitems Metemp = new Employeeitems();
        // Employee Setting
        Metemp.isActive = false;
        Metemp.nNum = listMyEmployee.Count+1;
        Metemp.StInfo = new ST_EMPLOYEE_INFO(temp);
        // 프리팹 만들어줌
       
        GameObject tempobj = (GameObject)Instantiate(pfEmpItem);
        tempobj.GetComponent<Employeeitems>().SetMyInfo(Metemp);
        tempobj.transform.parent = panel_grid.transform;
        tempobj.transform.localScale = Vector3.one;
        tempobj.transform.localPosition = Vector3.one;
        listMyEmployee.Add(tempobj.GetComponent< Employeeitems>());

        //패널 크기 세팅 필요
        tr_Grid.anchoredPosition = new Vector2(tr_Grid.anchoredPosition.x, (fItemHegit * listMyEmployee.Count) /2f);
        tr_Grid.sizeDelta = new Vector2(tr_Grid.sizeDelta.x, Mathf.Abs( (fItemHegit * listMyEmployee.Count)));
            //
    }

    public void InitMyEmpList()
    {
        listMyEmployee.Clear();

        // 직원 리스트 초기화, 후에 직원 최대 값으로 변경
        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f, 0.0f, 0.0f, 0.0f, 0, "Test", (JOB)Random.Range(0, 3), 0);

            CreatMyEmployee(temp);
        }

        for (int i = 0; i < GameManager.instance.listMyEmp.Count; ++i)
        {
            AddMyEmp(GameManager.instance.listMyEmp[i]);
        }
    }

    // 한개만 삭제
    public void DeleteEmployee(int nNum)
    {
        for(int i=0; i< listMyEmployee.Count;++i)
        {
            if (listMyEmployee[i].isActive)
            {
                if (listMyEmployee[i].nNum == nNum)
                {
                    listMyEmployee[i].isActive = false;
                    listMyEmployee[i].ReSetInfo();
                }
            }
            else
                continue;
        }
    }
    // 리스트중 한개만 추가
    public bool AddMyEmp(ST_EMPLOYEE_INFO temp)
    {
        for (int i = 0; i < listMyEmployee.Count; ++i)
        {
            if (!listMyEmployee[i].isActive)
            {
                listMyEmployee[i].isActive = true;
                listMyEmployee[i].SetMyInfo(temp);
                return true;
            }
        }
        return false;
    }
    // 안에 있는 데이터만 삭제
    void ReSetEmpData()
    {
        for (int i = 0; i < listMyEmployee.Count; ++i)
        {
            listMyEmployee[i].isActive = false;
            listMyEmployee[i].ReSetInfo();
        }

        for (int i = 0; i < GameManager.instance.listMyEmp.Count; ++i)
        {
            if (!listMyEmployee[i].isActive)
            {
                listMyEmployee[i].isActive = true;
                listMyEmployee[i].SetMyInfo(GameManager.instance.listMyEmp[i]);
            }
        }
    }

    public void ShowInfo(Employeeitems temp)
    {
        tName.text = temp.StInfo.Name;

        tStates[0].text = temp.StInfo.State1.ToString();
        tStates[1].text = temp.StInfo.State2.ToString();
        tStates[2].text = temp.StInfo.State3.ToString();
        tStates[3].text = temp.StInfo.State4.ToString();

        tStates[4].text = temp.StInfo.Money.ToString();

        iFace.sprite = EmployeeInfo.instance.GetEmpFace(temp.StInfo.MyFaceidx);

        nSeleteNum = temp.nNum;
    }

    public void AddEmp(ST_EMPLOYEE_INFO stinfo)
    {
        GameManager.instance.listMyEmp.Add(stinfo);
        DataSaveLoad.instance.SaveData(GameManager.instance.listMyEmp, LTEXT.GetKey(KEYSTR.K_EMP));
    }

    public void Fire()
    {
        DeleteEmployee(nSeleteNum);
        GameManager.instance.listMyEmp.RemoveAt(nSeleteNum-1);
        DataSaveLoad.instance.SaveData(GameManager.instance.listMyEmp, LTEXT.GetKey(KEYSTR.K_EMP));
        ReSetEmpData();
    }
}
