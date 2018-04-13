using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    Vector2 initialMousePos;
    public bool selected = false;
    public float speed = 7;

    // Use this for initialization
    void Start () {
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0) && selected)
        //{
        //    Debug.Log("Moviendo");
        //    Vector3 newPosition = new Vector3(0, Input.mousePosition.y - initialMousePos.y, 0);
        //    //transform.position += newPosition * Time.deltaTime;
        //    Debug.Log(newPosition.magnitude);
        //    if (newPosition.y > 0)
        //    {
        //        //child.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        //        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * Mathf.Clamp(newPosition.magnitude,0,20);
        //    }
        //    else if (newPosition.y < 0)
        //    {
        //        //child.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
        //        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * Mathf.Clamp(newPosition.magnitude, 0, 20);
        //    }

        //    initialMousePos = new Vector2(0, Input.mousePosition.y);
            
        //}
        if(Input.GetKey("up") && selected)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }else if (Input.GetKey("down") && selected)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKeyUp("up") || Input.GetKeyUp("down") && selected)
        {
            Debug.Log("Levantada");
            Snap();
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    selected = false;
            
        //}
       
    }

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pillado");
            //initialMousePos = new Vector2(0, Input.mousePosition.y);
            selected = true;
            transform.parent.GetComponent<PiezasMoviles>().Deselect(this.gameObject);
            if (!transform.GetChild(0).GetComponent<ParticleSystem>().isPlaying)
            {
                transform.GetChild(0).GetComponent<ParticleSystem>().Play(true);
            }
        }
        
    }

    public void Snap()
    {
        transform.position = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y), transform.position.z);
    }

}
