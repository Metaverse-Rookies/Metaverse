using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{
    //private Vector3 velocityCamSmooth = Vector3.zero;
    /*[SerializeField]
    private float camSmoothDampTime = 0.1f;


    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private Transform followXform;
*/

    //private Vector3 lookDir;
    //private Vector3 targetPosition;


    public float mindist = 0.5f;
    public float maxdist = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDIr;
    public Vector3 dollyDirAdjusted;
    public float distance;

    private void Awake()
    {
        dollyDIr = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {

            /*Vector3 desiredCamraPos = transform.parent.parent.TransformPoint(dollyDIr * maxdist);

            Vector3 dir = transform.parent.parent.position - desiredCamraPos;
            Ray ray = new Ray(transform.parent.position, dir.normalized);


            int layer = 1 << gameObject.layer;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, ~layer))
            {
                transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * smooth);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, dollyDIr * distance, Time.deltaTime * smooth);

            }*/


            Vector3 desiredCamraPos = transform.parent.TransformPoint(dollyDIr * maxdist);
            Debug.DrawRay(this.transform.position, desiredCamraPos, Color.green);
            RaycastHit hit;

            if (Physics.Linecast(transform.parent.position, desiredCamraPos - new Vector3(1, 0, 2), out hit))
            {
                distance = Mathf.Clamp(hit.distance, mindist, maxdist);

            }
            else
            {
                distance = maxdist;
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDIr * distance, Time.deltaTime * smooth);
        }
    }
    private void LateUpdate()
    {
        /*Vector3 characterOffset = followXform.position + new Vector3(0f, distanceUp, 0f);
        Debug.Log(followXform);
        Debug.Log(characterOffset);
   

        lookDir.y = 0;
        lookDir.Normalize();
        Debug.DrawRay(this.transform.position, lookDir, Color.green);

        targetPosition = characterOffset + followXform.up * distanceUp - lookDir * distanceAway;
        Debug.Log(targetPosition);
        Debug.DrawLine(followXform.position, targetPosition, Color.magenta);

        CompenSateForWalls(characterOffset, ref targetPosition);

        smoothPosition(this.transform.position, targetPosition);
        transform.LookAt(characterOffset);*/
    }



    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        //this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
    }




    private void CompenSateForWalls(Vector3 fromObjct, ref Vector3 toTarget)
    {
       /* Debug.DrawLine(fromObjct, toTarget, Color.cyan);
        // Compensate for wa lls between camera.
        RaycastHit wallHit = new RaycastHit();
        if (Physics.Linecast(fromObjct, toTarget, out wallHit))
        {
            Debug.DrawLine(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }*/
    }
}
