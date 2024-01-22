using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
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
    void Update()
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
       }
       if(Input.GetKey(KeyCode.A))
       {
        botoes-=cube.transform.right;
       }
        if(Input.GetKey(KeyCode.W))
       {
        botoes+=cube.transform.forward;
       }
       if(Input.GetKey(KeyCode.S))
       {
        botoes-=cube.transform.forward;
       }
       Debug.Log(botoes);
       Debug.Log (botoes.normalized);
       cube.transform.position+=botoes.normalized/10;
       
         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
       {
        //Debug.Log (hit.distance);
       } 
       if(Input.GetKey(KeyCode.Space)&& hit.distance<0.51f&&tempo==0)
       {
        cube.GetComponent<Rigidbody>().AddForce(new Vector3 (0,pulo,0)); 
        Debug.Log ("oi"); 
        tempo=0.5f;
       }
    }



}
