using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotlight : MonoBehaviour
{
    int beatnumber = 1; //or 2 or 3 or 4

    public bool islitup = false;

    float crotchet;  //the duration of a crotchet

    public conductor con;

    Renderer cube;

    public float LastBeat;

    void Start()
    {
        con = FindObjectOfType<conductor>();
        crotchet = 60 / con.songBpm;

        cube = gameObject.GetComponent<Renderer>();

       
    }

    void Update()
    {

        if (con.songPositionInBeats > LastBeat + crotchet)
        {
            
                Flash();

            LastBeat += crotchet;

        }

        if (islitup)
            cube.material.SetColor("_Color", Color.blue);
        else
            cube.material.SetColor("_Color", Color.white);
    }


    public void Flash()
    {
        if (islitup)
        {
            islitup = false;
            return;
        }
        else
        {
            islitup = true;
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            SC_GroundGenerator sc = FindObjectOfType<SC_GroundGenerator>();
            sc.gameOver = true;
        }
    }
}
