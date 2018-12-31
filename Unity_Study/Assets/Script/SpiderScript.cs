using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderScript : MonoBehaviour {

    enum SPIDERSTATE
    {
        none=-1,
        idle=0,
        move,
        attack,
        damage,
        dead

    }
    public int score = 10;


    SPIDERSTATE spiderState = SPIDERSTATE.idle;
    public AudioClip clip;
    delegate void stateFunc();
    Dictionary<SPIDERSTATE, stateFunc> dicState = new Dictionary<SPIDERSTATE, stateFunc>();
    public float idleStateMaxTime = 2.0f;
    public float stateTime = 0.0f;
    public float speed = 5.0f;
    public float attackRange = 2.5f;
    public float attackTime = 2.0f;
    public float distance = 0.0f;
    float DeadTime = 0.0f;
    public int hp = 5;
    public GameObject explosionPaticle = null;
    public GameObject deadObject = null;
    Transform target;
    // PlayerState playerState;
    PlayerController playerState;
    CharacterController characterController;
    int i = 0;
    public delegate void Test();
    Test TestCall;
    void Awake()
    {
        InitSpider();
    }
    void a()
    {
        Debug.Log("A");

    }
    void B()
    {
        Debug.Log("B");
    }
    void C()
    {
        Debug.Log("C");
    }
   
    void Start()
    {
        TestCall += B;
        TestCall += a;
        TestCall += C;
        dicState[SPIDERSTATE.idle] = Idle;
        dicState[SPIDERSTATE.move] = Move;
        dicState[SPIDERSTATE.attack] = Attack;
        dicState[SPIDERSTATE.damage] = Damage;
        dicState[SPIDERSTATE.dead] = Dead;

        target = GameObject.Find("Player").transform;
        playerState = target.GetComponent<PlayerController>();
        // playerState = target.GetComponent<PlayerState>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if ( spiderState==SPIDERSTATE.none)
            return;

        dicState[spiderState]();
        
        if (i < 1)
        {
            TestCall();
            i = 1;
        }
        
        

    }

    void Idle()
    {
        stateTime += Time.deltaTime;

        if(stateTime>idleStateMaxTime)
        {
            stateTime=0.0f;
            spiderState=SPIDERSTATE.move;
        }
        
       
    }

    void Move()
    {
      //  animation.Play("walk");
           distance =(target.position-transform.position).magnitude;

        if (distance<attackRange)
        {
            spiderState=SPIDERSTATE.attack;
            stateTime = attackTime;
        }

        else
        {
            Vector3 dir = target.position-transform.position;
            dir.y=0.0f;

            dir.Normalize();

            characterController.SimpleMove(dir*speed);

            transform.rotation=Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir),speed*Time.deltaTime);
            
        }
        
    }
    void Attack()
    {
        stateTime += Time.deltaTime;
        
        if (stateTime > attackTime)
        {
            stateTime = 0.0f;
          //  animation.Play("attack_Melee");
          //  animation.PlayQueued("iddle", QueueMode.CompleteOthers);

          //  playerState.DamageByEnemy();
            
        }
            distance =(target.position-transform.position).magnitude;
        if (distance > attackRange)
        {
            spiderState = SPIDERSTATE.idle;
        }

        
    }
    void Damage()
    {
        --hp;

       // AudioManager.Instance().PlaySfx(clip);
      //  animation["damage"].speed = 0.5f;
      //  animation.Play("damage");

      // animation.PlayQueued("iddle", QueueMode.CompleteOthers);
        stateTime=0.0f;
        spiderState = SPIDERSTATE.idle;

        if (hp < 0)
        {
            spiderState = SPIDERSTATE.dead;

           
        }
    }
    void Dead()
    {
      


        //DeadTime += Time.deltaTime;
        //animation["death"].speed = 0.5f;
        //animation.Play("death");

        StartCoroutine(DeadProcess());
        spiderState = SPIDERSTATE.none;

      //  ScoreManager.Instance().myScore += score;
    //    if(DeadTime>1.0f)
    //  {

    //    Destroy(gameObject);
    //}
    }


    void InitSpider()
    {
        hp = 5;
        spiderState = SPIDERSTATE.idle;
       // animation.Play("iddle");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (spiderState == SPIDERSTATE.none || spiderState == SPIDERSTATE.dead)
            return;

        if (collision.gameObject.layer == LayerMask.NameToLayer("boom"))
        {
            spiderState = SPIDERSTATE.damage;

        }
    }



   
    IEnumerator DeadProcess()
    {
        DeadTime += Time.deltaTime;
      //  animation["death"].speed = 0.5f;
      //  animation.Play("death");
        //while (animation.isPlaying)
        //{
        //    yield return new WaitForEndOfFrame();
        //}
        //yield return new WaitForSeconds(1.0f);
        GameObject explosionObj = Instantiate(explosionPaticle) as GameObject;

        Vector3 explosionObjPos = transform.position;
        explosionObjPos.y = 0.6f;
        explosionObj.transform.position = explosionObjPos;


        yield return new WaitForSeconds(0.5f);
        GameObject deadObj = Instantiate(deadObject) as GameObject;
        Vector3 deadObjPos = transform.position;
        deadObjPos.y = 0.6f;
        deadObj.transform.position = deadObjPos;

        float rotationY = Random.Range(-180.0f, 180.0f);
        deadObj.transform.eulerAngles = new Vector3(0.0f, rotationY, 0.0f);

        InitSpider();
        gameObject.SetActive(false);
        
        //Destroy(gameObject);

    }


}

