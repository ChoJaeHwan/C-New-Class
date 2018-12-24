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

    Transform target = null;
    CharacterController characterController = null;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackRange = 3.5f;
    public float attackStateMaxTime = 2.0f;

    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;

    public Animation anim;
    public Animator anime;
    void Awake()
    {
        Init_NPC();
        anime = GetComponent<Animator>();
    }

    void Init_NPC()
    {
        enemyState = ENEMYSTATE.IDLE;

    }

    void PlayIdleAnim()
    {
        if (!anim)
        {
           // anim["Idle"].speed = 3.0f;
           // anim.Play("Idle");
        }
    }
    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player").transform;
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {


        FSM_Switch();
   
        //if(characterController.isGrounded ==true)
        //{

        //    characterController.transform.position = new Vector3(characterController.transform.position.x, 0.0f, characterController.transform.position.z);

        //}
    }


    void FSM_Switch()
    {
       
        switch (enemyState)
        {
            case ENEMYSTATE.IDLE:
                {
                    stateTime += Time.deltaTime;
                    if(stateTime >idleStateMaxTime)
                    {
                        stateTime = 0.0f;
                        enemyState = ENEMYSTATE.MOVE;

                    }
                }
                break;
            case ENEMYSTATE.MOVE:
                {
                    //      anim["Run"].speed = 2.0f;
                       // anim.CrossFade("Run");
                  //  anime.Play("Run");
                    Debug.Log("달린다");
                    float distance = (target.position - transform.position).magnitude;
                    if (distance < attackRange)
                    {
                        enemyState = ENEMYSTATE.ATTACK;

                        stateTime = attackStateMaxTime;
                    }
                    else
                    {
                        Vector3 dir = target.position - transform.position;
                        dir.y = 0.0f;
                        dir.Normalize();
                        characterController.SimpleMove(dir * moveSpeed);
                        transform.rotation = Quaternion.Lerp(transform.rotation,
                        Quaternion.LookRotation(dir),
                        rotationSpeed * Time.deltaTime);
                    }

                }
                break;
            case ENEMYSTATE.ATTACK:
                {

                    stateTime += Time.deltaTime;
                    if (stateTime > attackStateMaxTime)
                    {
                        stateTime = 0.0f;
                        //  anim["Attack"].speed = -0.5f;
                        //  anim["Attack"].time = anim["Attack"].length;
                        // anim.Play( "Attack" );
                      //  anime.Play("Attack");
                        Debug.Log("어택중");
                    }
                    float distance = (target.position - transform.position).magnitude;
                    if (distance > attackRange)
                    {
                        enemyState = ENEMYSTATE.IDLE;
                        Debug.Log("어택종료 아이들");
                    }
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
