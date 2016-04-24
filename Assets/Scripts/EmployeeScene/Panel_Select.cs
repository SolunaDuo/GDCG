using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Panel_Select : Singleton<Panel_Select>
{
    List<Employeeitems> listSelectEmployee = new List<Employeeitems>();  // 직원 리스트(현재 보여지는 실제 게임 오브젝트)

    List<ST_EMPLOYEE_INFO> listSelectEmployee_01 = new List<ST_EMPLOYEE_INFO>();  // 프로그래밍 직원 리스트
    List<ST_EMPLOYEE_INFO> listSelectEmployee_02 = new List<ST_EMPLOYEE_INFO>();  // 그래픽 직원 리스트
    List<ST_EMPLOYEE_INFO> listSelectEmployee_03 = new List<ST_EMPLOYEE_INFO>();  // 기획 직원 리스트

    public GameObject pfEmpItem;
    public GameObject panel_grid;

    public RectTransform tr_Grid;
    private float fItemHegit = -100f;

    // Use this for initialization
    void Start () {
        // 직원 리스트 초기화, 후에 직원 최대 값으로 변경
        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.Range(1, 11), Random.Range(1, 11), 0.0f, 0.0f, 0, "Test",
                                     (JOB)Random.Range(0, 3), EmployeeInfo.instance.GetRandomIdx());

            CreatSelectEmployee(temp);
        }

        for (int i = 0; i < 10; ++i)
        {
            SetSelectEmp(listSelectEmployee[i].StInfo, 0);
        }

        Enable(false);
    }

    public void Enable(bool onoff)
    {
        if (onoff)
        {
            gameObject.GetComponent<Animator>().Play("ShowPopup");
        }
        else
        {
            transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
        }
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
    public void SetSelectEmp(ST_EMPLOYEE_INFO temp,int job)
    {
        if (job == 0)
            SetEmpData(ref listSelectEmployee_01, temp);
        else if (job == 1)
            SetEmpData(ref listSelectEmployee_02, temp);
        else if (job == 2)
            SetEmpData(ref listSelectEmployee_03, temp);

        for (int i=0; i< listSelectEmployee.Count;++i)
        {
            if( !listSelectEmployee[i].isActive && listSelectEmployee[i] != null )
            {
                listSelectEmployee[i].isActive = true;
                listSelectEmployee[i].SetMyInfo(temp);
                listSelectEmployee[i].gameObject.SetActive(true);
                //listSelectEmployee[i].StInfo = temp;
                break;
            }
        }
    }

    public void DeleteEmployee(Employeeitems temp,int job)
    {
        if (job == 0)
            DeleteEmpData(ref listSelectEmployee_01, temp.StInfo);
        else if (job == 1)
            DeleteEmpData(ref listSelectEmployee_02, temp.StInfo);
        else if (job == 2)
            DeleteEmpData(ref listSelectEmployee_03, temp.StInfo);

        for (int i = 0; i < listSelectEmployee.Count; ++i)
        {
            if (listSelectEmployee[i].isActive)
            {
                if (temp.nNum == listSelectEmployee[i].nNum)
                {
                    listSelectEmployee[i].isActive = false;
                    listSelectEmployee[i].gameObject.SetActive(false);
                }
            }
            else
                continue;
        }
    }
    //

    public void BuyEmp(Employeeitems items)
    {
        // 해당 직원 삭제
        DeleteEmployee(items,(int)items.StInfo.MyJob);
        // 직원 다시 복구
        ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.Range(1, 11), Random.Range(1, 11), 0.0f, 0.0f, 0, "Test",
               (JOB)Random.Range(0, 3), EmployeeInfo.instance.GetRandomIdx());
        SetSelectEmp(temp, (int)items.StInfo.MyJob);

        GameManager.instance.listMyEmp.Add(items.StInfo);
        GameManager.instance.PlusMyMoney(items.StInfo.Money);
        DataSaveLoad.instance.SaveData(GameManager.instance.listMyEmp, LTEXT.GetKey(KEYSTR.K_EMP));
    }

    public void ChangeJob(int job)
    {
        // 초기화 안됐을 경우 초기화 시켜줌
        if (listSelectEmployee_01.Count == 0)
        {
            ReSetEmpData(ref listSelectEmployee_01, 0);
        }
        if (listSelectEmployee_02.Count == 0)
        {
            ReSetEmpData(ref listSelectEmployee_02, 0);
        }
        if (listSelectEmployee_03.Count == 0)
        {
            ReSetEmpData(ref listSelectEmployee_03, 0);
        }

        for (int i = 0; i < 10; ++i)
        {
            listSelectEmployee[i].isActive = false;

            if (job == 0)
            {
                SetSelectEmp(listSelectEmployee_01[i], 0);
            }
            else if (job == 1)
            {
                SetSelectEmp(listSelectEmployee_02[i], 1);
            }
            else if (job == 2)
            {
                SetSelectEmp(listSelectEmployee_03[i], 2);
            }
        }
    }

    void ReSetEmpData(ref List<ST_EMPLOYEE_INFO> templist,int job)
    {
        templist.Clear();
        for (int i = 0; i < 10; ++i)
        {
            ST_EMPLOYEE_INFO temp = new ST_EMPLOYEE_INFO(Random.Range(1, 11), Random.Range(1, 11), 0.0f, 0.0f, 0, "Test",
                                    (JOB)job, EmployeeInfo.instance.GetRandomIdx());

            templist.Add(temp);
        }
    }

    void SetEmpData(ref List<ST_EMPLOYEE_INFO> templist, ST_EMPLOYEE_INFO temp)
    {
        templist.Add(temp);
    }

    void DeleteEmpData(ref List<ST_EMPLOYEE_INFO> templist, ST_EMPLOYEE_INFO temp)
    {
        templist.Remove(temp);
    }
}
