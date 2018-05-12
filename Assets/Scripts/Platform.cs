using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    Vector2 initialMousePos;
    public bool selected = false;
    float speed = 5;
    bool moving;
    Vector3 newPos, startPos;
    float moveTime = 0;
    public int maxUp = 1;
    public int maxDown = -1;
    public int index = 0;
    public Vector3 original;

    // Use this for initialization
    void Start () {
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
        newPos = startPos = Vector3.zero;
        original = transform.position;
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
        if(Input.GetKeyDown("up") && selected && index+1 <= maxUp)
        {
            startPos = transform.position;
            newPos = startPos + Vector3.up;
            moving = true;
            moveTime = 0;
            index++;
        }
        else if (Input.GetKeyDown("down") && selected && index-1 >= maxDown)
        {
            startPos = transform.position;
            newPos = startPos - Vector3.up;
            moving = true;
            moveTime = 0;
            index--;
        }

        if (moving)
        {
            moveTime += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, newPos, moveTime);
            if(Vector3.Distance(transform.position, newPos) < 0.05f)
            {
                Snap();
                moving = false;
            }
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
