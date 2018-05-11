using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform player;       //Public variable to store a reference to the player game object

    // Use this for initialization
    void Start()
    {
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        //transform.position = new Vector3(0,player.position.y + 3,-10);
        transform.position = Vector3.Lerp(transform.position, new Vector3(0, player.position.y + 3, -10), Time.deltaTime);
        //transform.position = new Vector3(transform.position.x,  player.position.y + 3, transform.position.z);
        transform.LookAt(player);
    }
}
