using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //手动绑定player 视角移动
        transform.position = new Vector3(player.position.x, player.position.y,transform.position.z);
    }
}
