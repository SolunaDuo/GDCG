using UnityEngine;
using System.Collections;

public class EmployeeInfo : Singleton<EmployeeInfo>
{
    public Sprite[] EmpFace;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite GetEmpFace(int idx)
    {
        if (EmpFace.Length < idx)
            return null;

        return EmpFace[idx];
    }

    public int GetRandomIdx()
    {
        // 0은 아무것도 없는 이미지..
        return Random.Range(1, EmpFace.Length);
    }
}
