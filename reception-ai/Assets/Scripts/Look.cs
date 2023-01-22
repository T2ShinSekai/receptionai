using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Look : MonoBehaviour
{

    public GameObject target;
    public GameObject face;
    public GameObject nearestObject;
    public float smoothTime = 1;
    public List<GameObject> objectsInsight;

    private Vector3 currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTargetLookAt();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) return;

        if (nearestObject == null)
        {
            nearestObject = other.gameObject;
        }

        if(!objectsInsight.Contains(other.gameObject))
        {
            objectsInsight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInsight.Contains(other.gameObject))
        {
            objectsInsight.Remove(other.gameObject);
        }

        if (other.gameObject == nearestObject)
        {
            FindNearestObject();
        }
    }

    private void MoveTargetLookAt()
    {
        if(nearestObject == null)
        {
            target.transform.position = Vector3.SmoothDamp(target.transform.position,
                nearestObject.transform.position, ref currentVelocity, smoothTime * Time.deltaTime);
        }
        else
        {
            target.transform.position = Vector3.SmoothDamp(target.transform.position,
                face.transform.position + new Vector3(0, 1.5f, 1f), ref currentVelocity, smoothTime * Time.deltaTime);

        }
    }


    private void FindNearestObject()
    {
        if (objectsInsight.Count == 0)
        {
            nearestObject = null;
        }
        else if (objectsInsight.Count == 1)
        {
            nearestObject = objectsInsight[0];
        }
        else
        {
            nearestObject = objectsInsight[0];

            var nearestObjectDistance = getDistance(face.transform.position, nearestObject.transform.position);

            for (int i = 1; i < objectsInsight.Count; i++)
            {
                if (getDistance(face.transform.position, objectsInsight[i].transform.position)
                    < getDistance(face.transform.position, nearestObject.transform.position))
                {
                    nearestObject = objectsInsight[i];

                    nearestObjectDistance = getDistance(face.transform.position, nearestObject.transform.position);
                }
            }
        }
    }

    private float getDistance(Vector3 a, Vector3 b)
    {
        return (a - b).sqrMagnitude;
    }


}
