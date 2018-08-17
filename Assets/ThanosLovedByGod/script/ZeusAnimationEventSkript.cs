using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusAnimationEventSkript : MonoBehaviour
{

	private ZeusController zc;

	void Start ()
	{
		zc = GetComponentInParent<ZeusController>();
	}

	public void spawnTornado()
	{
		zc.SpawnTornadoEvent();
	}

	public void spawnStone()
	{
		zc.SpawnStoneEvent();
	}

	public void spawnGrab()
	{
		zc.SpawnGrabEvent();
	}

	public void spawnLightning()
	{
		zc.SpawnLighningEvent();
	}
	
}
