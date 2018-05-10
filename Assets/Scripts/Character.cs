using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed = 2;
    public int direction = 1;
    public int facing = 0;
    public Transform init;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        //this.transform.position += transform.GetChild(0).right * Time.deltaTime * speed * direction;
        this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + transform.GetChild(0).right * speed * direction, Time.deltaTime);
        //this.GetComponent<Rigidbody>().velocity = transform.GetChild(0).right * speed * direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Corner")
        {
            Debug.Log("MEEEEEEE");
            facing++;
            if (facing > 3) facing = 0;
            transform.rotation = Quaternion.Euler(0, facing * 90, 0);
            speed += 0.1f;
            //transform.Rotate(Vector3.up, 90);
            // Mathf.Clamp(facing++, 0, 4);
            //transform.rotation = Quaternion.Euler(0, 0, facing * 90);
        }
    }


}
