using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionControl : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void SetExpression_Default()
    {
        anim.SetTrigger("Default");
    }

    public void SetExpression_Joy()
    {
        anim.SetTrigger("Joy");
    }

    public void SetExpression_Surprised()
    {
        anim.SetTrigger("Surprised");
    }

    public void SetExpression_Suspicion()
    {
        anim.SetTrigger("Suspicion");
    }

}
