using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour
{
    public GameObject player;
    public GameObject cacto;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     cacto.transform.position=Vector3.MoveTowards(cacto.transform.position,player.transform.position,Time.deltaTime*velocidade);   
    }
}
