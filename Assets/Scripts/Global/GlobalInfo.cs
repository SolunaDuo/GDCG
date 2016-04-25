using System;

/*
제작자  : 서형준
만든 날 : 2016-03-23
기능    : 정보 구조체
*/

public enum JOB
{
    J_PRO = 0,
    J_GRAP,
    J_PLANER,
};

// 게임이 가지고 있는 정보
[Serializable]
public class ST_GAME_INFO
{
    public float State1;   // 스테이스 3개
    public float State2;
    public float State3;

    public int Money;      // 판매 머니
    public int Rank;       // 게임 등급
    public int Taget;      // 타겟층

    public ST_GAME_INFO()
    {
    }
    public ST_GAME_INFO(float st1, float st2, float st3, int money, int rank, int taget)
    {
        State1 = st1;
        State2 = st2;
        State3 = st3;

        Money = money;
        Rank = rank;
        Taget = taget;
    }
}

[Serializable]
public class ST_EMPLOYEE_INFO
{
    public float State1;   // 스테이스 4개
    public float State2;
    public float State3;
    public float State4;

    public float MaxState1;   // 스테이스 4개 max값.. 처음 초기화 하고 변하지 않음
    public float MaxState2;
    public float MaxState3;
    public float MaxState4;

    public float Money;      // 연봉
    public string Name;    // 이름

    public JOB MyJob;

    public int MyFaceidx;


    public ST_EMPLOYEE_INFO(float st1, float st2, float st3, float st4, int money, string name, JOB myjob,int myfaceidx)
    {
        State1 = st1;
        State2 = st2;
        State3 = st3;
        State4 = st4;

        MaxState1 = st1;
        MaxState2 = st2;
        MaxState3 = st3;
        MaxState4 = st4;

        Money = money;
        Name = name;

        MyJob = myjob;

        MyFaceidx = myfaceidx;
    }

    public ST_EMPLOYEE_INFO(ST_EMPLOYEE_INFO temp)
    {
        State1 = temp.State1;
        State2 = temp.State2;
        State3 = temp.State3;
        State4 = temp.State4;

        MaxState1 = temp.State1;
        MaxState2 = temp.State2;
        MaxState3 = temp.State3; 
        MaxState4 = temp.State4;

        Money = temp.Money;
        Name = temp.Name;

        MyJob = temp.MyJob;

        MyFaceidx = temp.MyFaceidx;
    }
}