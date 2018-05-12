using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezasMoviles : MonoBehaviour {
    public GameObject[] piezas;

    public void Deselect(GameObject exception)
    {
        foreach (GameObject g in piezas)
        {
            if (g != exception)
            {
                g.GetComponent<Platform>().selected = false;
                g.transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
            }
        }
    }

    public void Restart()
    {
        foreach (GameObject g in piezas)
        {
            g.transform.position = g.GetComponent<Platform>().original;
            g.GetComponent<Platform>().selected = false;
            g.GetComponent<Platform>().index = 0;
            g.transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
        }
    }

}
