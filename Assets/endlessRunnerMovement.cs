using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessRunnerMovement : MonoBehaviour
{
    public MeshRenderer MR;
    public SC_GroundGenerator sc;
    public ParticleSystem ps;

    beatHitter bh;
    public GameObject instancePoint;
    public GameObject hitText, missText;

    public ParticleSystem engine;
    // Start is called before the first frame update
    void Start()
    {
        bh = FindObjectOfType<beatHitter>();
        sc = FindObjectOfType<SC_GroundGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sc.gameOver)
        {
            MR.enabled = false;
            ps.Play();
        }

        if (bh.hitTime)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.z < 2)
            {
                //Debug.Log("Moving Left");
                gameObject.transform.position = transform.position + new Vector3(0, 0, 1);
                bh.hitTime = false;
                Debug.Log("Moved on beat");
                bh.hitCount++;
                Instantiate(hitText, gameObject.transform.position, instancePoint.transform.rotation);
                engine.Emit(20);
                bh.chainCount++;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.z > -2)
            {
                //Debug.Log("Moving right");
                gameObject.transform.position = transform.position + new Vector3(0, 0, -1);
                bh.hitTime = false;
                Debug.Log("Moved on beat");
                bh.hitCount++;
                Instantiate(hitText, gameObject.transform.position, instancePoint.transform.rotation);
                engine.Emit(20);
                bh.chainCount++;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && gameObject.transform.position.y < 4)
            {
                //Debug.Log("Moving Left");
                gameObject.transform.position = transform.position + new Vector3(0, 1, 0);
                bh.hitTime = false;
                Debug.Log("Moved on beat");
                bh.hitCount++;
                Instantiate(hitText, gameObject.transform.position, instancePoint.transform.rotation);
                engine.Emit(20);
                bh.chainCount++;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.transform.position.y > 0)
            {
                //Debug.Log("Moving right");
                gameObject.transform.position = transform.position + new Vector3(0, -1, 0);
                bh.hitTime = false;
                Debug.Log("Moved on beat");
                bh.hitCount++;
                Instantiate(hitText, gameObject.transform.position, instancePoint.transform.rotation);
                engine.Emit(20);
                bh.chainCount++;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.z < 4)
            {
                Debug.Log("Tried to move off beat");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.z > -4)
            {

                Debug.Log("tried to move off beat");
            }
        }
    }
}
