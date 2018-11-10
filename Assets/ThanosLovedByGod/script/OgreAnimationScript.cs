using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreAnimationScript : MonoBehaviour
{

	private Smorc smorc;
	private animationsoundevents animEvent;
	private EnemyStats es;
	private Animator anim;

	public Ogre_Atack ogre;
	
	private void Start()
	{
		smorc = GetComponentInParent<Smorc>();
		animEvent = GetComponentInParent<animationsoundevents>();
		es = GetComponentInParent<EnemyStats>();
		anim = GetComponent<Animator>();
	}
	
	public void onFinishedAttack()
	{
		smorc.onFinishedAttack();
	}

	public void startAttack()
	{
		ogre.DamageCollider.enabled = true;
	}

	public void onStep()
	{
		if(!anim.GetBool("inAir"))
			SoundManager.instance.PlaySingle(animEvent.OgreWalk);
	}

	public void ogreDisappear()
	{
		es.ogreDisappear();
	}

	public void exhausted() {
		smorc.enabled = false;
	}

	public void endExhaustion() {
		smorc.enabled = true;
	}
}
