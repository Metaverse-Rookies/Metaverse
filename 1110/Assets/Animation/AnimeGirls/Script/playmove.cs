using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmove : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 5f;
    public float runspeed = 7f;
    public float finalspeed;
    public bool toggleCameraRotation;
    public bool run;
    public float smootheness = 10f;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt)){
            toggleCameraRotation = true;
        } else {
            toggleCameraRotation = false;
        }

        if (Input.GetKey(KeyCode.LeftShift)){
            run = true;
        } else {
            run = false;
        }
        Inputmove();

    }

    void LateUpdate()
    {
        if(toggleCameraRotation != true)
        {
            
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smootheness);
        }
    }

    void Inputmove()
    {
        finalspeed = (run) ? runspeed : speed;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");
        _controller.Move(moveDirection.normalized * finalspeed * Time.deltaTime);

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
    }




}
