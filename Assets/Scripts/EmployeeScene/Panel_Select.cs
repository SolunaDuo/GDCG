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
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f, 0.0f, 0.0f, 0.0f, 0, "", (JOB)Random.Range(0, 3),0);

            CreatSelectEmployee(temp);
        }

        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.Range(1,11), Random.Range(1, 11), 0.0f, 0.0f, 0, "Test",
                (JOB)Random.Range(0, 3), EmployeeInfo.instance.GetRandomIdx());

            SetSelectEmp(temp);
        }

        Enable(false);
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
        ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(0.0f, 0.0f, 0.0f, 0.0f, 0, "", (JOB)Random.Range(0, 3), EmployeeInfo.instance.GetRandomIdx());
        Panel_Employee.instance.gameObject.SetActive(true);

        Panel_Employee.instance.SetMyEmployee(temp,false);
    }
    // 직원 리스트를 만들어줌
    public void CreatSelectEmployee(ST_EMPLOYEE_INFO temp)
    {
        Employeeitems Metemp = new Employeeitems();
        // Employee Setting
        Metemp.isActive = false;
        Metemp.nNum = listSelectEmployee.Count + 1;
        Metemp.StInfo = new ST_EMPLOYEE_INFO(temp);
        Metemp.StInfo.Money = (Metemp.StInfo.State1 / 2f) + (Metemp.StInfo.State2 / 2f);

        // 프리팹 만들어줌
        GameObject tempobj = (GameObject)Instantiate(pfEmpItem);
        tempobj.GetComponent<Employeeitems>().SetMyInfo(Metemp);
        tempobj.transform.parent = panel_grid.transform;
        tempobj.transform.localScale = Vector3.one;
        tempobj.transform.localPosition = Vector3.one;
        listSelectEmployee.Add(tempobj.GetComponent<Employeeitems>());

        //패널 크기 세팅 필요
        if (listSelectEmployee.Count % 2 == 0)
        {
            tr_Grid.anchoredPosition = new Vector2(tr_Grid.anchoredPosition.x, (fItemHegit * (listSelectEmployee.Count ) ));
            tr_Grid.sizeDelta = new Vector2(tr_Grid.sizeDelta.x, Mathf.Abs((fItemHegit * (listSelectEmployee.Count))) / 2f);
        }
        else
        {
            tr_Grid.anchoredPosition = new Vector2(tr_Grid.anchoredPosition.x, (fItemHegit * (listSelectEmployee.Count + 1)));
            tr_Grid.sizeDelta = new Vector2(tr_Grid.sizeDelta.x, Mathf.Abs((fItemHegit * (listSelectEmployee.Count + 1))) / 2f);
        }
        //


    }
    // 만들어든 직원 리스트에 세팅을하는 부분
    public void SetSelectEmp(ST_EMPLOYEE_INFO temp)
    {
        for(int i=0; i< listSelectEmployee.Count;++i)
        {
            if( !listSelectEmployee[i].isActive && listSelectEmployee[i] != null )
            {
                listSelectEmployee[i].isActive = true;
                listSelectEmployee[i].SetMyInfo(temp);
                //listSelectEmployee[i].StInfo = temp;
                break;
            }
        }
    }

    public void BuyEmp(ST_EMPLOYEE_INFO stinfo)
    {
        GameManager.instance.listMyEmp.Add(stinfo);
        DataSaveLoad.instance.SaveData(GameManager.instance.listMyEmp, "MyEmp");
    }

    public void ChangeJob(int job)
    {
        for (int i = 0; i < 10; ++i)
        {
            listSelectEmployee[i].isActive = false;
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.Range(1, 11), Random.Range(1, 11), 0.0f, 0.0f, 0, "Test", (JOB)job, EmployeeInfo.instance.GetRandomIdx());
        
            SetSelectEmp(temp);
        }
    }
}
