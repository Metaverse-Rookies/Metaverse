using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMainController : MonoBehaviour
{
   

    public enum CameraType { FpCamera, TpCamera };
    
    // Components.
    [Serializable]
    public class Components
    {
        public Camera tpCamera;
        public Camera fpCamera;
        public GameObject chair;
    
        [HideInInspector] public Transform tpRig;
        [HideInInspector] public Transform fpRoot;
        [HideInInspector] public Transform fpRig;

        [HideInInspector] public GameObject tpCamObject;
        [HideInInspector] public GameObject fpCamObject;

        [HideInInspector] public Animator anim;
        [HideInInspector] public Rigidbody rBody;
    }

    // KeyOption.
    [Serializable]    
    public class KeyOption
    {
        public KeyCode moveForward  = KeyCode.W;
        public KeyCode moveBackward = KeyCode.S;
        public KeyCode moveLeft     = KeyCode.A;
        public KeyCode moveRight    = KeyCode.D;
        public KeyCode run          = KeyCode.LeftShift;
        public KeyCode jump         = KeyCode.Space;
        public KeyCode switchCamera = KeyCode.Tab;
        public KeyCode showCursor   = KeyCode.B;
        public KeyCode sitstand     = KeyCode.LeftAlt;
    }

    // State.
    [Serializable]
    public class CharacterState
    {
        // bool 기본값 : false
        public bool isCurrentFp;
        public bool isMoving;
        public bool isRunning;
        public bool isGrounded;
        public bool isCursorActive = true;
    }

    // Animation.
    [Serializable]
    public class AnimatorOption
    {
        public string paramMoveX    = "Move X";
        public string paramMoveZ    = "Move Z";
        public string paramDistY    = "Dist Y";

        public string paramJump     = "Jump";
        public string paramGrounded = "Grounded";
        public string paramSit      = "Sit";
        public string paramStand    = "Stand";
        

    }

    // MoveOption.
    [Serializable]
    public class MovementOption
    {
        [Range(1f, 15f), Tooltip("이동속도")]
        public float speed = 7f;
        [Range(1f, 10f), Tooltip("점프 강도")]
        public float jumpForce = 7f;
        [Tooltip("지면으로 체크할 레이어 설정")]
        public LayerMask groundLayerMask = -1;
        [Range(0.0f, 2.0f), Tooltip("점프 쿨타임")]
        public float jumpCooldown = 1.0f;
        [Range(1f, 5f), Tooltip("달리기 이동속도 증가 계수")]
        public float runningCoef = 1.5f;
    }

    // CameraOption.
    [Serializable]
    public class CameraOption
    {
        [Tooltip("게임 시작 시 카메라")]
        public CameraType initialCamera;

        [Range(1f, 10f), Tooltip("카메라 상하좌우 회전 속도")]
        public float rotationSpeed = 2f;

        [Range(-90f, 0f), Tooltip("올려다보기 제한 각도")]
        public float lookUpDegree = -60f;

        [Range(0f, 75f), Tooltip("내려다보기 제한 각도")]
        public float lookDownDegree = 75f;

        [Range(0f, 3.5f), Space, Tooltip("줌 확대 최대 거리")]
        public float zoomInDistance = 3f;

        [Range(0f, 5f), Tooltip("줌 축소 최대 거리")]
        public float zoomOutDistance = 3f;

        [Range(1f, 30f), Tooltip("줌 속도")]
        public float zoomSpeed = 12f;

        [Range(0.01f, 0.5f), Tooltip("줌 가속")]
        public float zoomAccel = 0.1f;
    }


    #region.
    public Components Com => _components;
    public KeyOption Key => _keyOption;
    public CharacterState State => _state;
    public AnimatorOption AnimOption => _animatorOption;
    public MovementOption MoveOption => _movementOption;
    public CameraOption CamOption => _cameraOption;
    
    [SerializeField] private Components _components = new Components();
    [Space]
    [SerializeField] private KeyOption _keyOption = new KeyOption();
    [Space]
    [SerializeField] private MovementOption _movementOption = new MovementOption();
    [Space]
    [SerializeField] private CameraOption _cameraOption = new CameraOption();
    [Space]
    [SerializeField] private AnimatorOption _animatorOption = new AnimatorOption();
    [Space]
    [SerializeField] private CharacterState _state = new CharacterState();

    [SerializeField]
    private float _distFromGround;
    private float _groundCheckRadius;
   

    // 키보드 입력 받아 움직이는 로컬 이동 벡터.
    private Vector3 _moveDir;

    // 월드 이동 벡터.



    private Vector3 _worldMove;

    // Lerp를 위한 변수들. 애니메이션 파라미터.
    private float _moveX;
    private float _moveZ;
    private float _currentJumpCooldown;

    // 마우스 움직을 통해 얻는 회전 값.
    private Vector2 _rotation;

    private float _deltaTime;

    // TP 카메라 ~ Rig 초기 거리. 
    private float _tpCamZoomInitialDistance;

    // TP 카메라 휠 입력 값.
    private float _tpCameraWheelInput = 0;

    // 선형보간된 현재 휠 입력 값.
    private float _currentWheel;


   


    #endregion.

    #region.
    private void Start()
    {
 
        InitComponents();
        InitSettings();
    }

    private void Update()
    { 
        _deltaTime = Time.deltaTime;

        // 확인, 카메라, 키 입력.
        // ShowCursorToggle();
        CameraViewToggle();
        SetValuesByKeyInput();

        // 카메라 회전, 움지임(앞, 뒤, 위, 아래, 점프, 앉기)
        
        if (stance != "sit")
        {
            Jump();
        }


        Rotate();
        Move();
        SitandStand();
        
        // 업데이트.       
        CheckDistanceFromGround();
        UpdateAnimationParams();
        UpdateCurrentValues();
        TpCameraZoom();
    }
    #endregion

    private void InitComponents()
    {
        LogNotInitializedComponentError(Com.tpCamera, "TP Camera");
        LogNotInitializedComponentError(Com.fpCamera, "FP Camera");
        TryGetComponent(out Com.rBody);

        // 애니메이션 컴포넌트의 하위 객체 중 가장 선두에 존재하는 컴포넌트를 반환.
        Com.anim        = GetComponentInChildren<Animator>();

        Com.tpCamObject = Com.tpCamera.gameObject;
        Com.tpRig       = Com.tpCamera.transform.parent;

        Com.fpCamObject = Com.fpCamera.gameObject;
        Com.fpRig       = Com.fpCamera.transform.parent;
        Com.fpRoot      = Com.fpRig.parent;

        TryGetComponent(out CapsuleCollider cCol);
        _groundCheckRadius = cCol ? cCol.radius : 0.1f;

       
    }

    private void InitSettings()
    {
        // Rigidbody
        if (Com.rBody)
        {
            // 회전은 트랜스폼을 통해 직접 제어할 것이기 때문에 리지드바디 회전은 제한
            Com.rBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        // Camera 변수 할당
        var AllCams = FindObjectsOfType<Camera>();
        foreach (var cam in AllCams)
        {
            cam.gameObject.SetActive(false);  
        }
        // 설정한 카메라 하나만 활성화
        State.isCurrentFp = (CamOption.initialCamera == CameraType.FpCamera);
        Com.fpCamObject.SetActive(State.isCurrentFp);
        Com.tpCamObject.SetActive(!State.isCurrentFp);

        // Zoom
        _tpCamZoomInitialDistance = Vector3.Distance(Com.tpRig.position, Com.tpCamera.transform.position);


    }

    private void LogNotInitializedComponentError<T>(T component, string componentName) where T : Component
    {
        if (component == null)
            Debug.LogError($"{componentName} 컴포넌트를 인스펙터에 넣어주세요");
    }
    
    // 키보드 입력.
    private void SetValuesByKeyInput()
    {
        float h = 0f, v = 0f;

        // Forward.
        if (Input.GetKey(Key.moveForward)) 
            v += 1.0f;
        // Backward.
        if (Input.GetKey(Key.moveBackward)) 
            v -= 1.0f;
        // Left.
        if (Input.GetKey(Key.moveLeft)) 
            h -= 1.0f;
        // Right.
        if (Input.GetKey(Key.moveRight)) 
            h += 1.0f;
          
        Vector3 moveInput = new Vector3(h, 0f, v).normalized;
        _moveDir = Vector3.Lerp(_moveDir, moveInput, MoveOption.speed); // 가속, 감속
        _rotation = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        State.isMoving = _moveDir.sqrMagnitude > 0.01f;
        State.isRunning = Input.GetKey(Key.run);


        // Wheel. --> 3인칭 카메라 휠.
        _tpCameraWheelInput = Input.GetAxisRaw("Mouse ScrollWheel");

        // 숫자 간의 선형 보간. --> Mathf.Lerp(float a, float b, float t)
        // a : The start value. b : The end value. t : The interpolation value between the two floats.
        // 리턴값 : 시작점 a와 끝점 b의 두 값 간의 사이의 값을 보간한 float형.

        _currentWheel = Mathf.Lerp(_currentWheel, _tpCameraWheelInput, CamOption.zoomAccel);      
    }

    // 의자 위치.
    public GameObject Chair;
    private string stance = "stand";
    private void SitandStand()
    {
        // C 입력 and 상태 stand => 앉기
        if (Input.GetMouseButtonDown(0) && stance == "stand")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
            Com.anim.SetTrigger(AnimOption.paramSit);
            //transform.position = Vector3.Lerp(transform.position, Chair.transform.position, 1f);
            Debug.Log(stance);
            stance = "sit";
            print(stance);
            }
        }
        // 
        // C 입력 and 상태 sit => 일어서기
        else if (Input.GetKey(Key.moveRight) | Input.GetKey(Key.moveLeft) | Input.GetKey(Key.moveForward) | Input.GetKey(Key.moveBackward) && stance == "sit") 
        {
            Com.anim.SetTrigger(AnimOption.paramStand);
            transform.position = Com.rBody.position;
            
            Debug.Log(stance);
            stance = "stand";
            print(stance);
        }

    }

    // 카메라 회전.


    private void Rotate()
    {
        if (State.isCurrentFp)
        {   // 1인칭 카메라 전환.
            if (!State.isCursorActive)
                RotateFP();
        }
        else
        {
            if (!State.isCursorActive)
                // 3인칭 카메라 전환.
                RotateTP();
            RotateFPRoot();
        }
    }

    //  1인칭 회전.
    private void RotateFP()
    {
        if (Input.GetMouseButton(1))
        {
        float deltaCoef = Time.deltaTime * 50f;

        // 상하 : FP Rig 회전
        float xRotPrev = Com.fpRig.localEulerAngles.x;
        float xRotNext = xRotPrev + _rotation.y
            * CamOption.rotationSpeed * deltaCoef;

        if (xRotNext > 180f)
            xRotNext -= 360f;

        // 좌우 : FP Root 회전
        float yRotPrev = Com.fpRoot.localEulerAngles.y;
        float yRotNext =
            yRotPrev + _rotation.x
            * CamOption.rotationSpeed * deltaCoef;

        // 상하 회전 가능 여부
        bool xRotatable =
            CamOption.lookUpDegree < xRotNext &&
            CamOption.lookDownDegree > xRotNext;

        // FP Rig 상하 회전 적용
        Com.fpRig.localEulerAngles = Vector3.right * (xRotatable ? xRotNext : xRotPrev);

        // FP Root 좌우 회전 적용
        Com.fpRoot.localEulerAngles = Vector3.up * yRotNext;
        }
    }

    // 3인칭 회전. 
    private void RotateTP()
    {
        if (Input.GetMouseButton(1))
        {
            float deltaCoef = Time.deltaTime * 50f;

            // 상하 : TP Rig 회전
            float xRotPrev = Com.tpRig.localEulerAngles.x;
            float xRotNext = xRotPrev + _rotation.y
                * CamOption.rotationSpeed * deltaCoef;

            if (xRotNext > 180f)
                xRotNext -= 360f;

            // 좌우 : TP Rig 회전
            float yRotPrev = Com.tpRig.localEulerAngles.y;
            float yRotNext =
                yRotPrev + _rotation.x
                * CamOption.rotationSpeed * deltaCoef;

            // 상하 회전 가능 여부
            bool xRotatable =
                CamOption.lookUpDegree < xRotNext &&
                CamOption.lookDownDegree > xRotNext;

            Vector3 nextRot = new Vector3
            (
                xRotatable ? xRotNext : xRotPrev,
                yRotNext,
                0f
            );

            // TP Rig 회전 적용
            Com.tpRig.localEulerAngles = nextRot;
        }
       
    }

    // 3인칭일 경우 FP Root 회전. 
    private void RotateFPRoot()
    {
        
        if (State.isMoving == false) return;

        Vector3 dir = Com.tpRig.TransformDirection(_moveDir);
        float currentY = Com.fpRoot.localEulerAngles.y;
        float nextY = Quaternion.LookRotation(dir, Vector3.up).eulerAngles.y;

        if (nextY - currentY > 180f) nextY -= 360f;
        else if (currentY - nextY > 180f) nextY += 360f;

        Com.fpRoot.eulerAngles = Vector3.up * Mathf.Lerp(currentY, nextY, 0.1f);
        
    }

    private void ShowCursorToggle()
    {
        if (Input.GetKeyDown(Key.showCursor))
            State.isCursorActive = !State.isCursorActive;

        ShowCursor(State.isCursorActive);
    }

    // Cursor의 visible 여부에 따른 카메라 토글 움직임 및 정지.
    private void ShowCursor(bool value)
    {
        Cursor.visible = value;
        Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void CameraViewToggle()
    {
        if (Input.GetKeyDown(Key.switchCamera))
        {
            State.isCurrentFp = !State.isCurrentFp;
            Com.fpCamObject.SetActive(State.isCurrentFp);
            Com.tpCamObject.SetActive(!State.isCurrentFp);
            
            // TP -> FP
            if (State.isCurrentFp)
            {
                Vector3 tpEulerAngle = Com.tpRig.localEulerAngles;
                Com.fpRig.localEulerAngles = Vector3.right * tpEulerAngle.x;
                Com.fpRoot.localEulerAngles = Vector3.up * tpEulerAngle.y;
            }
            // FP -> TP
            else
            {
                Vector3 newRot = default;
                newRot.x = Com.fpRig.localEulerAngles.x;
                newRot.y = Com.fpRoot.localEulerAngles.y;
                Com.tpRig.localEulerAngles = newRot;
            }
        }
    }

    private void TpCameraZoom()
    {
        if (State.isCurrentFp) return;         // TP 카메라만 가능
        if (_tpCameraWheelInput == 0f) return; // 휠 입력 있어야 가능

        Transform tpCamTr = Com.tpCamera.transform;
        Transform tpCamRig = Com.tpRig;

        float zoom = Time.deltaTime * CamOption.zoomSpeed;
        float currentCamToRigDist = Vector3.Distance(tpCamTr.position, tpCamRig.position);
        Vector3 move = Vector3.forward * zoom;

        // Zoom In
        if (_tpCameraWheelInput > 0.01f)
        {
            if (_tpCamZoomInitialDistance - currentCamToRigDist < CamOption.zoomInDistance)
            {
                tpCamTr.Translate(move, Space.Self);
            }
        }
        // Zoom Out
        else if (_tpCameraWheelInput < -0.01f)
        {

            if (currentCamToRigDist - _tpCamZoomInitialDistance < CamOption.zoomOutDistance)
            {
                tpCamTr.Translate(-move, Space.Self);
            }
        }
    }

    private void Move()
    {
        // 이동하지 않는 경우, 미끄럼 방지
        if (State.isMoving == false)
        {
            Com.rBody.velocity = new Vector3(0f, Com.rBody.velocity.y, 0f);
            return;
        }

        // 실제 이동 벡터 계산
        // 1인칭
        if (State.isCurrentFp)
        {
            _worldMove = Com.fpRoot.TransformDirection(_moveDir);
        }
        // 3인칭
        else
        {
            _worldMove = Com.tpRig.TransformDirection(_moveDir);
        }

        _worldMove *= (MoveOption.speed) * (State.isRunning ? MoveOption.runningCoef : 1.2f);

        // Y축 속도는 유지하면서 XZ평면 이동
        Com.rBody.velocity = new Vector3(_worldMove.x, Com.rBody.velocity.y, _worldMove.z);
    }

    // 땅으로부터의 거리 체크.
    private void CheckDistanceFromGround()
    {
        Vector3 ro = transform.position + Vector3.up;
        Vector3 rd = Vector3.down;
        Ray ray = new Ray(ro, rd);

        const float rayDist = 500f;
        const float threshold = 0.01f;

        bool cast = Physics.SphereCast(ray, _groundCheckRadius, out var hit, rayDist, MoveOption.groundLayerMask);

        _distFromGround = cast ? (hit.distance - 1f + _groundCheckRadius) : float.MaxValue;
        State.isGrounded = _distFromGround <= _groundCheckRadius + threshold;
    }

    private void Jump()
    {
        if (!State.isGrounded) return;
        if (_currentJumpCooldown > 0f) return; // 점프 쿨타임

        if (Input.GetKeyDown(Key.jump))
        {
            Debug.Log("JUMP");

            // 하강 중 점프 시 속도가 합산되지 않도록 속도 초기화
            Com.rBody.velocity = Vector3.zero;

            Com.rBody.AddForce(Vector3.up * MoveOption.jumpForce, ForceMode.VelocityChange);

            // 애니메이션 점프 트리거
            Com.anim.SetTrigger(AnimOption.paramJump);

            // 쿨타임 초기화
            _currentJumpCooldown = MoveOption.jumpCooldown;
        }
    }

    private void UpdateCurrentValues()
    {
        if (_currentJumpCooldown > 0f)
            _currentJumpCooldown -= _deltaTime;
    }

    private void UpdateAnimationParams()
    {
        float x, z;

        if (State.isCurrentFp)
        {
            x = _moveDir.x;
            z = _moveDir.z;

            if (State.isRunning)
            {
                x *= 2f;
                z *= 2f;
            }
        }
        else
        {
            x = 0f;
            z = _moveDir.sqrMagnitude > 0f ? 1f : 0f;

            if (State.isRunning)
            {
                z *= 2f;
            }
        }

        // 보간
        const float LerpSpeed = 0.05f;
        _moveX = Mathf.Lerp(_moveX, x, LerpSpeed);
        _moveZ = Mathf.Lerp(_moveZ, z, LerpSpeed);

        Com.anim.SetFloat(AnimOption.paramMoveX, _moveX);
        Com.anim.SetFloat(AnimOption.paramMoveZ, _moveZ);
        Com.anim.SetFloat(AnimOption.paramDistY, _distFromGround);
        Com.anim.SetBool(AnimOption.paramGrounded, State.isGrounded);
    }


}

