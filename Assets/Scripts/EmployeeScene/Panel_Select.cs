using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Panel_Select : Singleton<Panel_Employee>
{
    List<Employeeitems> listSelectEmployee = new List<Employeeitems>();  // 직원 리스트

    public GameObject pfEmpItem;
    public GameObject panel_grid;

    public RectTransform tr_Grid;
    private float fItemHegit = -100f;
    // Use this for initialization
    void Start () {
        // 직원 리스트 초기화, 후에 직원 최대 값으로 변경
        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f, 0.0f, 0.0f, 0.0f, 0, "");

            CreatSelectEmployee(temp);
        }
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatSelectEmployee(ST_EMPLOYEE_INFO temp)
    {
        Employeeitems Metemp = new Employeeitems();
        // Employee Setting
        Metemp.isActive = false;
        Metemp.nNum = listSelectEmployee.Count + 1;
        Metemp.StInfo = new ST_EMPLOYEE_INFO(temp);

        // 프리팹 만들어줌
        GameObject tempobj = (GameObject)Instantiate(pfEmpItem);
        tempobj.GetComponent<Employeeitems>().SetMyInfo(Metemp);
        tempobj.transform.parent = panel_grid.transform;
        tempobj.transform.localScale = Vector3.one;
        tempobj.transform.localPosition = Vector3.one;
        listSelectEmployee.Add(Metemp);

        //패널 크기 세팅 필요
        tr_Grid.anchoredPosition = new Vector2(0.0f, (fItemHegit * listSelectEmployee.Count));
        tr_Grid.sizeDelta = new Vector2(0.0f, Mathf.Abs((fItemHegit * listSelectEmployee.Count)) * 2f);
        //
    }

    public void SetSelectEmp(ST_EMPLOYEE_INFO temp)
    {
        for(int i=0; i< listSelectEmployee.Count;++i)
        {
            if(!listSelectEmployee[i].isActive)
            {
                listSelectEmployee[i].gameObject.SetActive(true);
                listSelectEmployee[i].isActive = true;
                listSelectEmployee[i].StInfo = temp;
            }
        }
    }
}
