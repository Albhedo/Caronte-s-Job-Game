using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float speed;

    int nextWaypoint = 0;

    float changeDirDistance = 0.2f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wayPoints.Count);

        if(wayPoints.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextWaypoint].position, speed * Time.deltaTime);
             if(Vector3.Distance(transform.position, wayPoints[nextWaypoint].position) < changeDirDistance)
            {
                
                nextWaypoint++;

                //Si el siguiente punto no existe (es mayor o igual al tamaño de la lista) reiniciamos al primer punto
                if(nextWaypoint >= wayPoints.Count)
                {
                 nextWaypoint--;
                }
            }
        }
    }
}
