using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
제작자  : 서형준
만든 날 : 2016-03-31
기능    : 직원 관리 팝업 패널 스크립트.
*/

struct MyEmployee
{
    public bool isActive;
    public int     nNum; // 몇번째 인지 체크

    public ST_EMPLOYEE_INFO StInfo;


};

public class Panel_Employee : MonoBehaviour {
    public static Panel_Employee instance = null;

    List<MyEmployee> listMyEmployee;  // 직원 리스트
    public GameObject pfEmpItem;

    public GameObject panel_grid;   // 그리드 패널
    

    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetMyEmployee(ST_EMPLOYEE_INFO temp)
    {
        MyEmployee Metemp = new MyEmployee();
        // Employee Setting
        Metemp.isActive = true;
        Metemp.nNum = listMyEmployee.Count;
        Metemp.StInfo = new ST_EMPLOYEE_INFO(temp);
        // 프리팹 만들어줌
        GameObject tempobj = (GameObject)Instantiate(pfEmpItem);
        tempobj.transform.parent = panel_grid.transform;

        //패널 크기 세팅 필요

        listMyEmployee.Add(Metemp);
    }
}
