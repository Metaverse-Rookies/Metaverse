using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [Range(0f, 1f)]
    public float maxLength;

    public LayerMask groundedLayer;
    private enum SetMoveType
    {
        Direct,
        LookCam,
        BackWalk
    }
    [SerializeField] private SetMoveType setMoveType = SetMoveType.Direct; // 각 움직임 타입
    [SerializeField] private float moveSpeed = 4f; // 캐릭터 이동 속도
    [SerializeField] private float jumpFoce =  5f; // 캐릭터 점프 
    [SerializeField] private float turnSpeed = 200f; // 캐릭터 회전 속도
    [SerializeField] private bool isGrounded = false; // 땅 체크

    private readonly float walkScale = 0.33f; // 걷는 속도 제한
    private readonly float backWalkScale = 0.55f; // 뒤로 걷는 속도 제한
    private readonly float backRunScale = 0.88f; // 뒤로 뛰는 속도 제한
    private readonly float interpolation = 10f; // 그래프 배율

    private float currentV = 0; // 현재 Vertical 값
    private float currentH = 0; // 현재 Horizontal 값
    private Vector3 currentDirection = Vector3.zero; // 현재 정면 기준 백터

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Animator playerAnimator;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 땅에 닿았는 가?
        CheckGround();
    }


    private void FixedUpdate()
    {
        // 각 타입에 맞는 
        switch (setMoveType)
        {
            case SetMoveType.Direct:
                DirectMove();
                break;
            case SetMoveType.LookCam:
                LookCamMove();
                break;
            case SetMoveType.BackWalk:
                BackWalkMove();
                break;
        }
    }

    private void DirectMove()
    {
        float v = playerInput.verticalInput;
        float h = playerInput.horizontalInput;

        // 달리기를 하지 않으면 속도 제한
        if (!playerInput.runInput)
        {
            v *= walkScale;
            h *= walkScale;
        }

        // 부드러운 이동 속도 증가를 위한 로직
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolation);

        // 기준 정면 값
        // - 해당 방향이 정면이 됨
        Vector3 direction = new Vector3(currentH, 0, currentV);

        // 이동 중 이라면
        if (direction != Vector3.zero)
        {
            // 부드러운 회전을 위한 보간
            currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * interpolation);

            // 캐릭터의 정면을 넣어줌
            transform.forward = currentDirection;

            // Rigidbody의 MovePosition 메소드로 캐릭터 이동
            // - transfrom.position을 사용해도 되지만 얇은 벽등을 통과할 문제등이 생길 수 있다.
            // - 객체의 충돌을 유지하면서 이동하기 위해 MovePosition을 사용 했다.
            playerRigidbody.MovePosition(playerRigidbody.position + currentDirection * Time.deltaTime * moveSpeed);

            // currentDirection은 Vector값 이기 때문에 magnitude로 길이를 반환한다.
            // playerInput의 최대값은 1이기 때문에 currentDirection 또한 최대 값 1이 반환됨.
            playerAnimator.SetFloat("MoveSpeed", currentDirection.magnitude);
        }

        // 점프 로직
        Jump();
    }

    private void LookCamMove()
    {
        float v = playerInput.verticalInput;
        float h = playerInput.horizontalInput;

        Transform mainCam = Camera.main.transform;

        if (!playerInput.runInput)
        {
            v *= walkScale;
            h *= walkScale;
        }

        // 부드러운 이동 속도 증가를 위한 로직
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolation);

        // 정면 방향을 카메라의 기준으로 설정
        Vector3 direction = mainCam.forward * currentV + mainCam.right * currentH;

        // y축은 고정
        direction.y = 0;

        // 움직임이 있다면
        if (direction != Vector3.zero)
        {
            // 부드러운 회전을 위한 보간
            currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * interpolation);

            // 캐릭터의 정면 설정
            transform.forward = currentDirection;

            // 캐릭터의 움직임
            playerRigidbody.MovePosition(playerRigidbody.position + currentDirection * Time.deltaTime * moveSpeed);

            // 캐릭터의 애니메이션
            playerAnimator.SetFloat("MoveSpeed", currentDirection.magnitude);
        }

        Jump();
    }

    private void BackWalkMove()
    {
        float v = playerInput.verticalInput;
        float h = playerInput.horizontalInput;
        bool run = playerInput.runInput; // 걷는지 확인을 위한 변수

        // 만약 수직 입력이 뒤 방향 이면
        // - v의 음수는 캐릭터 정면이 반대 방향이다.
        if (v < 0)
        {
            // 걷는 지 뛰는 지 확인
            if (!run)
            {
                // 뒤로 걷고 있다면 속도를 제한
                v *= backWalkScale;
            }
            else
            {
                // 뒤로 뛰고 있다면 속도를 제한
                v *= backRunScale;
            }
        }
        // 만약 뒤로 걷지 않고 앞으로 걷고 있을 경우
        // 뛰고 있지 않다면 걷는 속도 제한
        else if (!run)
        {
            v *= walkScale;
        }

        // 스피드를 보간 해주고
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolation);

        // 플레이어 움직임
        // (transform.forward * currentV * moveSpeed * Time.deltaTime)
        // 플레이어의 앞쪽 방향 * 수직 입력 값 * 움직임 값 * 프레임 보정
        playerRigidbody.MovePosition(transform.position +
                                    (transform.forward * currentV * moveSpeed * Time.deltaTime));

        // 플레이어 y축을 기준으로 회전
        // (0, currentH * turnSpeed * Time.deltaTime, 0)
        // (0, 수평 입력 값 * 회전 값 * 프레임 보정, 0 )
        transform.Rotate(0, currentH * turnSpeed * Time.deltaTime, 0);

        playerAnimator.SetFloat("MoveSpeed", currentV);

        Jump();
    }

    private void Jump()
    {
        // 점프키를 입력 받으면서 땅에 닿아 있을 경우
        if (playerInput.jumpInput && isGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpFoce, ForceMode.Impulse);
            playerAnimator.SetBool("Jump", playerInput.jumpInput);
        }
    }

    private void CheckGround()
    {
#if UNITY_EDITOR
        Debug.DrawRay(transform.position + new Vector3(0, 0.05f, 0), Vector3.down * maxLength, Color.red);
#endif
        // 플레이어의 조금 위쪽 부터 아래로 0.2f 만큼 레이를 발사
        // 레이마스크를 씌워 해당 레이에만 검출
        if (Physics.Raycast(transform.position + new Vector3(0, 0.05f, 0), Vector3.down, maxLength, groundedLayer))
        {
            // 만약 있다면
            Debug.Log("감지!");
            isGrounded = false;
        }
        else
        {
            // 검사가 안되면
            Debug.Log("감지되지 않음!");
            isGrounded = true;
        }
    }

    
}