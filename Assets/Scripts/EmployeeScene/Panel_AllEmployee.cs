using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_AllEmployee : Singleton<Panel_AllEmployee>
{
    public Image iHp;
    public Image iAbility;

    float fAllHp = 0f;
    float fAllAbility = 0f;

    float fCurHp = 0f;
    float fCurAbility = 0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetAll(int job = 0)
    {
        fAllHp = 0;
        fAllAbility = 0;
        for (int i=0; i<GameManager.instance.listMyEmp.Count;++i)
        {
            if (job == (int)GameManager.instance.listMyEmp[i].MyJob)
            {
                fAllHp += GameManager.instance.listMyEmp[i].MaxState1;
                fAllAbility += GameManager.instance.listMyEmp[i].MaxState2;
            }
        }
        SetBar();
    }

    public void SetCur(int job = 0)
    {
        fCurHp = 0;
        fCurAbility = 0;
        for (int i = 0; i < GameManager.instance.listMyEmp.Count; ++i)
        {
            if (job == (int)GameManager.instance.listMyEmp[i].MyJob)
            {
                fCurHp += GameManager.instance.listMyEmp[i].State1;
                fCurAbility += GameManager.instance.listMyEmp[i].State2;
            }
        }
        SetBar();
    }

    public void SetBar()
    {
        iHp.fillAmount = fCurHp / fAllHp;
        iAbility.fillAmount = fCurAbility / fAllAbility;
    }

     public void Enable(bool onoff)
    {
        if (onoff)
        {
            ChangeJob(0);
            gameObject.GetComponent<Animator>().Play("ShowPopup");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("idle");
        }
    }

    public void ChangeJob(int job)
    {
        SetAll(job);
        SetCur(job);
    }
}
