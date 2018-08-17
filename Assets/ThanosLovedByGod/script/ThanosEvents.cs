using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanosEvents : MonoBehaviour {

    public Animator anim;

    void SetAttackOn()
    {
        anim.SetBool("isAttacking", true);
    }
    void SetAttackOff()
    {
        anim.SetBool("isAttacking", false);
    }

}
