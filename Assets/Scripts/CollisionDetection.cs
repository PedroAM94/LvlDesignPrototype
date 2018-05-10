using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public Transform init;

    private void Update()
    {
        transform.rotation = transform.parent.rotation *  Quaternion.AngleAxis(-transform.parent.rotation.eulerAngles.z, Vector3.forward);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("Death");
            transform.parent.GetComponent<Character>().facing = 0;
            transform.parent.rotation = Quaternion.Euler(0, 0, 0);
            transform.parent.position = transform.parent.GetComponent<Character>().init.position;
            transform.parent.GetComponent<Character>().speed = 3.5f;
        }

        if (other.tag == "DirChanger")
        {
            Debug.Log("Cambio direccion");
            this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x * -1, this.GetComponent<BoxCollider>().center.y, 0);
            this.transform.parent.GetComponent<Character>().direction *= -1;
        }
    }

}
