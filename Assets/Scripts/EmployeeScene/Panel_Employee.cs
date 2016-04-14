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

    // 코드 위치는 보기 좋은곳으로...
    public Employeeitems GetEmployee( int index )
    {
        return listMyEmployee[ index ];
    }
    // 코드 위치는 보기 좋은곳으로...


    void Awake()
    {
    //    instance = this;
    }
	// Use this for initialization
	void Start () {
        // 직원 리스트 초기화, 후에 직원 최대 값으로 변경
        for (int i=0; i<10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f,0.0f,0.0f,0.0f,0,"");

            SetMyEmployee(temp);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetMyEmployee(ST_EMPLOYEE_INFO temp,bool bact = false)
    {
        Employeeitems Metemp = new Employeeitems();
        // Employee Setting
        Metemp.isActive = bact;
        Metemp.nNum = listMyEmployee.Count+1;
        Metemp.StInfo = new ST_EMPLOYEE_INFO(temp);
        // 프리팹 만들어줌
        if (!bact)
        {
            GameObject tempobj = (GameObject)Instantiate(pfEmpItem);
            tempobj.GetComponent<Employeeitems>().SetMyInfo(Metemp);
            tempobj.transform.parent = panel_grid.transform;
            tempobj.transform.localScale = Vector3.one;
            tempobj.transform.localPosition = Vector3.one;
            listMyEmployee.Add(Metemp);

            //패널 크기 세팅 필요
            tr_Grid.GetComponent<Rect> = 1000.0f;
            //


        }
        else
        {
            for(int i=0; i< listMyEmployee.Count; ++i)
            {
                if (!listMyEmployee[i].isActive)
                    listMyEmployee[i].SetMyInfo(Metemp);
            }
        }
    }

    public void DeleteEmployee(ST_EMPLOYEE_INFO temp)
    {
        for(int i=0; i< listMyEmployee.Count;++i)
        {
            if (listMyEmployee[i].isActive)
            {
                if (temp.Name.Equals(listMyEmployee[i].StInfo.Name))
                {
                    listMyEmployee[i].isActive = false;
                    listMyEmployee.Remove(listMyEmployee[i]);
                }
            }
            else
                continue;
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
    }
}
