using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Panel_Select : Singleton<Panel_Select>
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

        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.RandomRange(1.0f,10.0f), Random.RandomRange(1.0f, 10.0f), 0.0f, 0.0f, 0, "Test");

            SetSelectEmp(temp);
        }

        //Enable(false);
    }
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.A))
        {
            Panel_MessageBox.instance.ShowMessage("Test!!", "Set", gameObject);
        }
	}

    public void Enable(bool onoff)
    {
        if (onoff)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void Set()
    {
        ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f, 0.0f, 0.0f, 0.0f, 0, "");
        Panel_Employee.instance.gameObject.SetActive(true);

        Panel_Employee.instance.SetMyEmployee(temp,false);
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
        listSelectEmployee.Add(tempobj.GetComponent<Employeeitems>());

        //패널 크기 세팅 필요
        tr_Grid.anchoredPosition = new Vector2(tr_Grid.anchoredPosition.x, (fItemHegit * listSelectEmployee.Count));
        tr_Grid.sizeDelta = new Vector2(tr_Grid.sizeDelta.x, Mathf.Abs((fItemHegit * listSelectEmployee.Count)) * 2f);
        //


    }

    public void SetSelectEmp(ST_EMPLOYEE_INFO temp)
    {
        for(int i=0; i< listSelectEmployee.Count;++i)
        {
            if( !listSelectEmployee[i].isActive && listSelectEmployee[i] != null )
            {
                listSelectEmployee[i].isActive = true;
                listSelectEmployee[i].StInfo = temp;
                break;
            }
        }
    }
}
