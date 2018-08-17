using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Shield : MonoBehaviour {

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    float realX;
    float realY;
    private ThanosStats ts;
    private Player player;
	private Animator anim;
	
	// Use this for initialization
	void Start ()
    {
        realX = 0;
        realY = 0;
        ts      = GameObject.FindGameObjectWithTag("Thanos").GetComponent<ThanosStats>();
        player  = ReInput.players.GetPlayer(0);
	    anim = GetComponentInParent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float x = player.GetAxis("Shield Horizontal");// >=0 ? player.GetAxis("Shield Horizontal") : 0;
        
        if ((x > realX) && (x > 0))
        {

        }
        float y = player.GetAxis("Shield Vertical");// >=0? player.GetAxis("Shield Vertical"):0;


        if (!(y == 0) || !(x == 0))
        {
            Vector2 direction = new Vector2(x, y).normalized;
            
	        anim.SetFloat("blockFloat", Mathf.Clamp(y, 0, 0.9f));
	        
            transform.up = Vector2.Lerp(transform.up, direction, Time.fixedDeltaTime * 10);
            transform.up = new Vector2(Mathf.Clamp(transform.up.x,xMin,xMax), Mathf.Clamp(transform.up.y,yMin,yMax));
        }
            
    }
}
