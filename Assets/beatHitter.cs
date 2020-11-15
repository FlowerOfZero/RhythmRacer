using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatHitter : MonoBehaviour
{
    public conductor con;

    float crotchet;  //the duration of a crotchet

    public float LastBeat;

    public bool hitTime;

    public int hitCount;

    public int missedCount;

    public GameObject miss;

    public int chainCount;

    public int notesTillNextMultiplier = 4;

    public int multiplier = 1;

    void Start()
    {

        crotchet = 60 / con.songBpm;
    }

    float timeToHit;
    bool changedNote;
    void Update()
    {

        if(chainCount >= notesTillNextMultiplier)
        {
            multiplier = multiplier * 2;
            notesTillNextMultiplier = chainCount * 2;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Beat button hit");
        */
        if (con.songPositionInBeats > LastBeat + crotchet - 0.05 && !hitTime && !changedNote)
        {
            hitTime = true;
            //Debug.Log("time to hit");
            timeToHit = 0;
            changedNote = true;
  
        }


        if (hitTime)
        {
            timeToHit += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("Beat hit");
                hitTime = false;
                hitCount++;
            }

            if(timeToHit > .2)
            {
                Debug.Log("Beat missed");
                hitTime = false;
                missedCount++;
                Instantiate(miss, gameObject.transform.position, gameObject.transform.rotation);
                chainCount = 0;
                multiplier = 1;
                notesTillNextMultiplier = 4;
            }
        }


  

        if (con.songPositionInBeats > LastBeat + crotchet)
        {
            LastBeat += crotchet;
            changedNote = false;
        }
    }
}
