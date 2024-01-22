using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public GameObject visao;
    public float distancia,altura;
    Vector3 Offset=new Vector3(0,2,-3);
    // Start is called before the first frame update
    void Start()
    {
    Cursor.lockState=CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
    visao.transform.position=player.transform.position+Offset;
    Debug.Log(Input.GetAxis("Mouse X"));
    player.transform.RotateAround(player.transform.position, Vector3.up,  Input.GetAxis("Mouse X"));
    visao.transform.position=player.transform.position-player.transform.forward*distancia+Vector3.up*altura;
    visao.transform.LookAt(player.transform.position);
    }
}
