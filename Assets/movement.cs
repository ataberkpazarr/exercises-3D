using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;

    private Vector3 lastVisitedPointPosition; //storing last passed point position of path, in order to decide to the rotation of enemy

    int currentPosOfPath;
    private Vector3 nextPos;
    private waypoint waypoint_;
    // Start is called before the first frame update
    void Start()
    {
        currentPosOfPath = 0;
        waypoint_ = GetComponent<waypoint>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        nextPos = waypoint_.GetWaypointPosition(currentPosOfPath);
        move();
        checkIfNextPositionReached();

        
    }*/

    private void checkIfNextPositionReached()
    {
        float distanceToNextPointPos = (transform.position - nextPos).magnitude;

        if (distanceToNextPointPos < 0.1f)
        {
            lastVisitedPointPosition = transform.position;
            currentPosOfPath++;
        }
    }

    private void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
    
    private void FixedUpdate()
    {
       // Vector3 nextpos = transform.position + new Vector3(0,0,1);

        //option 1

        /*
        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed * Time.deltaTime);
        */

        //option 2 with Lerp
        /*
        float elapsedTime = 0f;
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp(elapsedTime / 0.1f, 0f, 1f); //so with this, object will change its position stage by stage while time elapses
        t = t * t * (3 - 2 * t);
        transform.position = Vector3.Lerp(transform.position,nextpos,t);
        */

        //option 3 with applying continous force to rigidbody
        /*
        //iskinematic false olmalı
        Vector3 direction = Vector3.forward ;
        rb.AddForce(direction * speed * Time.deltaTime);*/
    }

}
