using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CS_SpawnThunder_NM_1 : MonoBehaviour {

    public GameObject thunder;
    public Transform spawnPoint;
    public GameObject tornado;
    public Transform cursorPosition;

    private void Update()
    {
        bool shoot = Input.GetButtonDown("Thunder_Fire");

        if (shoot) Instantiate(thunder, spawnPoint.position, spawnPoint.rotation);

        //sollte eigene Funktion sein:

        bool spawn = Input.GetButtonDown("spawnTornado");

        Quaternion noRot = new Quaternion(0, 0, 180, 1); 
        if (spawn) Instantiate(tornado, cursorPosition.position, noRot);

        //Debug.Log("Shoot" + shoot);
    }

}
