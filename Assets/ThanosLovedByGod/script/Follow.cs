using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform TransformToFollow;
    public Vector2 Offset;

	// Update is called once per frame
	void LateUpdate () {

        if(TransformToFollow) this.transform.position = new Vector2(TransformToFollow.position.x + Offset.x, TransformToFollow.position.y + Offset.y);

	}
}
