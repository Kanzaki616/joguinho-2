using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public Animator anim;
    static readonly int WalkLFT = Animator.StringToHash("Mushroom_walkLFTSmile");
    static readonly int WalkRGT = Animator.StringToHash("Mushroom_walkRGTSmile");
    static readonly int WalkFWD = Animator.StringToHash("Mushroom_walkFWDSmile");
    static readonly int WalkBWD = Animator.StringToHash("Mushroom_walkBWDSmile");
    static readonly int JumpAnim = Animator.StringToHash("Mushroom_VictorySmile");
    static readonly int Idle = Animator.StringToHash("Mushroom_IdleNormalSmile");
    public GameObject cube;
    public float pulo;
    RaycastHit hit; 
    float tempo, tempoanim;
    int animatual,animdesejada;
    // Start is called before the first frame update
    void Start()
    {    
     tempoanim=0;
     tempo=0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      animdesejada=Idle;
       Vector3 botoes=new Vector3 (0,0,0);
       if(Input.GetKey(KeyCode.D))
       {
        botoes+=cube.transform.right;
        //anim.CrossFade(WalkRGT,0);
        animdesejada=WalkRGT;
       }
       if(Input.GetKey(KeyCode.A))
       {
        botoes-=cube.transform.right;
        //anim.CrossFade(WalkLFT,0);
        animdesejada=WalkLFT;
       }
        if(Input.GetKey(KeyCode.W))
       {
        botoes+=cube.transform.forward;
        //anim.CrossFade(WalkFWD,0);
        animdesejada=WalkFWD;
       }
       if(Input.GetKey(KeyCode.S))
       {
        //anim.CrossFade(WalkBWD,0);
        animdesejada=WalkBWD;
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
       if(Input.GetKey(KeyCode.Space)&& hit.distance<0.51f&&tempo<=Time.time)
       {
        cube.GetComponent<Rigidbody>().AddForce(new Vector3 (0,pulo,0)); 
        //anim.CrossFade(JumpAnim,0);
        animdesejada=JumpAnim;
        

        //Debug.Log ("oi"); 
        tempo=Time.time+0.5f;
       }
       if (animatual!=animdesejada&&tempoanim<=Time.time)
       {
        animatual=animdesejada;
        anim.CrossFade(animdesejada,0);
        if (animatual==JumpAnim)
        {
          tempoanim=Time.time+1.5f;
        } 
          
        
       }
    }



}
