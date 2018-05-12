using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed = 2;
    public int direction = 1;
    public int facing = 0;
    public Transform init;
    public bool godMode = false;
    bool jumping = false;
    Vector3 posToGo;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void LateUpdate () {
        //this.transform.position += transform.GetChild(0).right * Time.deltaTime * speed * direction;
        if (jumping)
        {
            transform.RotateAround(transform.position, transform.GetChild(0).forward, -5);

        }
        posToGo = this.transform.position + transform.GetChild(0).right * speed * direction;
        this.transform.position = Vector3.Lerp(this.transform.position, posToGo, Time.deltaTime);
        //this.GetComponent<Rigidbody>().velocity = transform.GetChild(0).right * speed * direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Corner")
        {
            facing++;
            if (facing > 3) facing = 0;
            transform.rotation = Quaternion.Euler(0, facing * 90, 0);
            speed += 0.1f;
            //transform.Rotate(Vector3.up, 90);
            // Mathf.Clamp(facing++, 0, 4);
            //transform.rotation = Quaternion.Euler(0, 0, facing * 90);
        }
        if (collision.collider.tag == "Obstacle")
        {
            jumping = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "DownLevel")
        {
            //transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 500, ForceMode.Acceleration);
            jumping = true;
            //posToGo = col.gameObject.GetComponent<Jump>().targetPos.transform.position;
        }
       
    }

}
