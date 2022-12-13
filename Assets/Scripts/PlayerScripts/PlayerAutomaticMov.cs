using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutomaticMov : MonoBehaviour
{
    public GameObject player;
    public float targetDistance;
    public float allowedDistance = 0.1f;
    public GameObject follower;
    public float startSpeed;
    private float followSpeed;
    public RaycastHit hit;

    private void Update()
    {
        transform.LookAt(player.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit))
        {
            targetDistance = hit.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = startSpeed;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed*Time.deltaTime);
            }
            else
            {
                followSpeed = 0f;
            }
        }
    }

}
