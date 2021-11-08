using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform objectTofollow;
    public float followSpeed = 2f;
    public float sensitivity = 30f;
    public float clampAngle = 40f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 dirNormalized;
    public Vector3 finalDir;
    public float mindist;
    public float maxdist;
    public float finaldist;
    public float smoothness = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finaldist = realCamera.localPosition.magnitude;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
        //rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        //rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        //Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
       // transform.rotation = rot;

    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position,
            followSpeed * Time.deltaTime);
        finalDir = transform.TransformPoint(dirNormalized * maxdist);

        RaycastHit hit;

        if(Physics.Linecast(transform.position, finalDir, out hit))
        {
            finaldist = Mathf.Clamp(hit.distance, mindist, maxdist);
        } else
        {
            finaldist = maxdist;
        }
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finaldist, Time.deltaTime * smoothness);
    }
}
