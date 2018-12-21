using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {


    public Transform cameraTransform;
    public GameObject fireObect;
    public float forwardPower = 20.0f;
    public float upPower = 1.0f;
    GameObject obj = null;
    // Use this for initialization
    void Start () {
        //  cameraTransform.position = this.gameObject.transform.position;
          fireObect = Resources.Load("BallPack/Models/AtomBall") as GameObject;
        //fireObect = Resources.Load<GameObject>("Ball Pack/Models/AtomBall");
    }

    // Update is called once per frame
    void Update () {
	
        if(Input.GetButtonDown("Fire1"))
        {
            
             obj = Instantiate(fireObect) as GameObject;
            obj.tag = "Boom";
            obj.transform.position = transform.position;
            obj.GetComponent<Rigidbody>().velocity = (cameraTransform.forward * forwardPower*0.001f) + (Vector3.up * upPower*0.001f);


        }


     
        }

}

  

