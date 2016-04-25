using UnityEngine;
using System.Collections;

public class Test : BehaviourBase
{

    public override void Awake()
    {
        base.Awake();
        Debug.Log( "Awake" );
    }

    public override void Start()
    {
        base.Start();
        Debug.Log( "Start" );
    }

    public override void Update()
    {
        base.Update();
        Debug.Log( "Update" );
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log( "FixedUpdate" );
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        Debug.Log( "LateUpdate" );
    }
}
