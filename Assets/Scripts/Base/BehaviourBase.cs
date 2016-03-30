using UnityEngine;
using System.Collections;

public class BehaviourBase : MonoBehaviour
{
    public virtual void Awake() { }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    public virtual void FixedUpdate() { }
}
