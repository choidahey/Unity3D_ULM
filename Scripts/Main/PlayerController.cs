using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    PhotonView PV;

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float turnSpeed = 200;
    [SerializeField] private float jumpForce = 7;

    [SerializeField] private Animator animator = null;
    public Rigidbody rigidBody = null;

    private float currentV = 0;
    private float currentH = 0;

    private readonly float interpolation = 10;
    private readonly float walkScale = 0.33f;

    private bool wasGrounded;
    private Vector3 currentDirection = Vector3.zero;

    private float jumpTimeStamp = 0;
    private float minJumpInterval = 0.25f;
    private bool jumpInput = false;

    private bool isGrounded;

    private List<Collider> collisions = new List<Collider>();


    private void Awake()
    {
        PV = GetComponent<PhotonView>();

        if (!animator) { gameObject.GetComponent<Animator>(); }
        if (!rigidBody) { gameObject.GetComponent<Animator>(); }

        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!collisions.Contains(collision.collider))
                {
                    collisions.Add(collision.collider);
                }
                isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            isGrounded = true;
            if (!collisions.Contains(collision.collider))
            {
                collisions.Add(collision.collider);
            }
        }
        else
        {
            if (collisions.Contains(collision.collider))
            {
                collisions.Remove(collision.collider);
            }
            if (collisions.Count == 0) { isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collisions.Contains(collision.collider))
        {
            collisions.Remove(collision.collider);
        }
        if (collisions.Count == 0) { isGrounded = false; }
    }

    void Update()
    {
        if (!jumpInput && Input.GetKey(KeyCode.Space))
        {
            jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        if(!PV.IsMine) { return; }

        animator.SetBool("Grounded", isGrounded);
        Move();

        wasGrounded = isGrounded;
        jumpInput = false;

    }

    private void Move()
    {
        float v = Input.GetAxis("Vertical");      // 1f까지의 값 받아오고 즉각적인 W, A, S, D의 기능을 수행하기 위해 사용
        float h = Input.GetAxis("Horizontal");    // 1f까지의 값 받아오고 부드러운 점프 모션을 위해 사용

        Transform camera = Camera.main.transform;    // 카메라 컴포넌트 받아옴

        if (Input.GetKey(KeyCode.LeftShift))     // 왼쪽 Shift키를 누르면 걷기(기본적으로 달리기)
        {
            v *= walkScale;
            h *= walkScale;
        }
        
        //카메라의 이전 물리 프레임과 다음 물리프레임 사이 값을 찾아서 선형보간
        currentV = Mathf.Lerp(currentV, v, Time.deltaTime * interpolation);
        currentH = Mathf.Lerp(currentH, h, Time.deltaTime * interpolation);

        Vector3 direction = camera.forward * currentV + camera.right * currentH;  // 카메라의 벡터값 받아와서 캐릭터의 시점으로 받아옴

        float directionLength = direction.magnitude;

        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            currentDirection = Vector3.Slerp(currentDirection, direction, Time.deltaTime * interpolation);

            transform.rotation = Quaternion.LookRotation(currentDirection);
            transform.position += currentDirection * moveSpeed * Time.deltaTime;

            animator.SetFloat("MoveSpeed", direction.magnitude);  // moveSpeed에 따른 애니메이션 출력
        }

        JumpingAndLanding();
        Dance();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - jumpTimeStamp) >= minJumpInterval;  // 점프는 최대 1번으로 제한

        if (jumpCooldownOver && isGrounded && jumpInput)
        {
            jumpTimeStamp = Time.time;
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  // y축으로 중력을 줘서 점프
        }

        // 부드러운 점프 모션을 위해 2가지의 모션 연결
        if (!wasGrounded && isGrounded)
        {
            animator.SetTrigger("Land");
        }

        if (!isGrounded && wasGrounded)
        {
            animator.SetTrigger("Jump");
        }
    }

    private void Dance()   // 특정 키 입력으로 춤 애니메이션 호출 가능
    {
        if (isGrounded && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Alpha2))
        {
            animator.SetTrigger("Dance");
        }

        if (isGrounded && Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.V))
        {
            animator.SetTrigger("Dance2");
        }
    }
}
