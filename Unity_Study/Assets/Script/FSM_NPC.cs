using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_NPC : MonoBehaviour {


    enum ENEMYSTATE
    {

        IDLE=0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD

    }
    ENEMYSTATE enemyState = ENEMYSTATE.IDLE;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                {
                }
                break;
            case ENEMYSTATE.MOVE:
                {
                }
                break;
            case ENEMYSTATE.ATTACK:
                {
                }
                break;
            case ENEMYSTATE.DAMAGE:
                {
                }
                break;
            case ENEMYSTATE.DEAD:
                {
                }
                break;
        }


    }
}
