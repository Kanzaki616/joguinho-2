using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public Animator anim;
    static readonly int WalkLFT = Animator.StringToHash("Mushroom_walkLFTSmile");
    public GameObject cube;
    public float pulo;
    RaycastHit hit;
    float tempo; 
    // Start is called before the first frame update
    void Start()
    {    
     tempo=0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       tempo-=Time.deltaTime;
       if(tempo<0)
       {
        tempo=0;
       }
       Vector3 botoes=new Vector3 (0,0,0);
       if(Input.GetKey(KeyCode.D))
       {
        botoes+=cube.transform.right;
        anim.CrossFade("Mushroom_walkLFTSmile",0);
       }
       if(Input.GetKey(KeyCode.A))
       {
        botoes-=cube.transform.right;
        anim.CrossFade("Mushroom_walkRGTSmile",0);
       }
        if(Input.GetKey(KeyCode.W))
       {
        botoes+=cube.transform.forward;
        anim.CrossFade("Mushroom_walkFWDSmile",0);
       }
       if(Input.GetKey(KeyCode.S))
       {
        anim.CrossFade("Mushroom_walkBWDSmile",0);
        botoes-=cube.transform.forward;
       }
       //Debug.Log(botoes);
       //Debug.Log (botoes.normalized);
       cube.transform.position+=botoes.normalized/10;
       
         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
       {
        Debug.Log (hit.distance);
       } 
       Debug.Log (tempo);
       Debug.Log (Input.GetKey(KeyCode.Space));
       if(Input.GetKey(KeyCode.Space)&& hit.distance<0.51f&&tempo==0)
       {
        cube.GetComponent<Rigidbody>().AddForce(new Vector3 (0,pulo,0)); 
        anim.CrossFade("Mushroom_VictorySmile",0);

        //Debug.Log ("oi"); 
        tempo=0.5f;
       }
    }



}
