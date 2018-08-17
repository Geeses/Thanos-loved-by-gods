using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationsoundevents : MonoBehaviour
{
    public AudioClip OgreWalk;
    public AudioClip Slothbend;
    public AudioClip Slothshoot;
    public AudioClip Thanosattack;        
    public AudioClip ZeusBurp;
    public AudioClip ZeusDrink;
    public AudioClip ZeusGrap;
    public AudioClip ZeusStone;
    public AudioClip ZeusTornado;

    public bool canStep;

    private void PlayOgreWalk()
    {
        //verlegt auf drunter liegendes Ogre Objekt, da beim neuimportieren der Animator auf dem anderen Objekt war
    }
    private void PlaySlothBend()
    {
        SoundManager.instance.PlaySingle(Slothbend);
    }
    private void PlaySlothShoot()
    {
        SoundManager.instance.PlaySingle(Slothshoot);
    }
    private void PlayThanosattack()
    {
        SoundManager.instance.PlaySingle(Thanosattack);
    }
    private void PlayZeusBurp()
    {
        SoundManager.instance.PlaySingle(ZeusBurp);
    }
    private void PlayZeusDrink()
    {
        SoundManager.instance.PlaySingle(ZeusDrink);
    }
    private void PlayZeusGrab()
    {
        SoundManager.instance.PlaySingle(ZeusGrap);
    }
    private void PlayZeusTornado()
    {
        SoundManager.instance.PlaySingle(ZeusTornado);
    }
    private void PlayZeusStone()
    {
        SoundManager.instance.PlaySingle(ZeusStone);
    }
}
