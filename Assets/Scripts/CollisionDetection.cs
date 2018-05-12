using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
    
    public GameObject PiezasLevel;

    private void Update()
    {
        transform.rotation = transform.parent.rotation *  Quaternion.AngleAxis(-transform.parent.rotation.eulerAngles.z, Vector3.forward);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            if (!transform.parent.GetComponent<Character>().godMode)
            {
                Debug.Log("Death");
                transform.parent.GetComponent<Character>().facing = 0;
                transform.parent.rotation = Quaternion.Euler(0, 0, 0);
                transform.parent.position = transform.parent.GetComponent<Character>().init.position;
                transform.parent.GetComponent<Character>().speed = 5f;
                PiezasLevel.GetComponent<PiezasMoviles>().Restart();
            }
        }

        if (other.tag == "DirChanger")
        {
            Debug.Log("Cambio direccion");
            this.GetComponent<BoxCollider>().center = new Vector3(this.GetComponent<BoxCollider>().center.x * -1, this.GetComponent<BoxCollider>().center.y, 0);
            this.transform.parent.GetComponent<Character>().direction *= -1;
        }
    }

}
