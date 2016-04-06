﻿using System;

/*
제작자  : 서형준
만든 날 : 2016-03-23
기능    : 정보 구조체
*/

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

    public int Money;      // 연봉
    public string Name;    // 이름


    public ST_EMPLOYEE_INFO(float st1, float st2, float st3, float st4, int money, string name)
    {
        State1 = st1;
        State2 = st2;
        State3 = st3;

        Money = money;
        Name = name;
    }

    public ST_EMPLOYEE_INFO(ST_EMPLOYEE_INFO temp)
    {
        State1 = temp.State1;
        State2 = temp.State2;
        State3 = temp.State3;

        Money = temp.Money;
        Name = temp.Name;
    }
}