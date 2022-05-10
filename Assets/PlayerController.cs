using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private new Rigidbody2D rigidbody2D;
    private DistanceJoint2D distanceJoint2D;
    private bool isDistanceJointEnabled = false;
    private int addSpeedBoot = 25;
 
    // Update is called once per frame
    private void Awake()
    {
        distanceJoint2D = GetComponent<DistanceJoint2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        Debug.Log(rigidbody2D.velocity);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                rigidbody2D.velocity = CalculateProjectileVelocity(transform.position, 
                    hit2D.point, 1f);;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (isDistanceJointEnabled)
            {
                isDistanceJointEnabled = false;
                distanceJoint2D.enabled = isDistanceJointEnabled;
            }
            else
            {
                if (hit2D.collider != null)
                {
                    isDistanceJointEnabled = true;
                    distanceJoint2D.enabled = isDistanceJointEnabled;
                    distanceJoint2D.connectedAnchor = hit2D.point;
                    if (rigidbody2D.velocity.x > 0)
                    {
                        //rigidbody2D.velocity += new Vector2(addSpeedBoot, 0);
                        rigidbody2D.AddForce(new Vector2(addSpeedBoot, 0),ForceMode2D.Impulse);
                    }
                    else
                    {
                        //rigidbody2D.velocity += new Vector2(-addSpeedBoot, 0);
                        rigidbody2D.AddForce(new Vector2(-addSpeedBoot, 0),ForceMode2D.Impulse);
                    }
                }
            }
            
        }

        if (isDistanceJointEnabled)
        {
            lineRenderer.SetPositions(new Vector3[] {transform.position,distanceJoint2D.connectedAnchor});
        }
        else
        {
            lineRenderer.SetPositions(new Vector3[] {Vector3.zero,Vector3.zero});
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance2D = target - origin;
        Vector2 distance = distance2D;
        distance.y = 0;

        float distX = distance.magnitude;
        float distY = distance2D.y;

        float velocityX = distX / time;
        float velocityY = distY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 result = distance.normalized;
        result *= velocityX;
        result.y = velocityY;
        return result;
    }
}
