using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider_B : MonoBehaviour
{
    public float speed = 5.0f; // 이동속도
    public float gravityMultiplier = 1.0f; // 중력에 영향을 받는 경우를 처리
    public List<XRController> controllers = null;
    private CharacterController characterController = null; // VRRig의 캐릭터 컨트롤러
    private GameObject head = null; //카메라의 헤드 위치
    //public AudioClip swing;
    //AudioSource swingaudioSource;

    

    private void Awake()
    {
        //캐릭터 컨트롤러 할당 및 카메라 위치 설정
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;

    }
    // Start is called before the first frame update
    void Start()
    {        
        //swingaudioSource = GetComponent<AudioSource>();
        //초기 설정을 처리
        PositionController();

    }

    // Update is called once per frame
    void Update()
    {
        PositionController(); // 현재 위치에 맞게 위치를 설정
        CheckForInput();
        ApplyGravity();
    }
    void PositionController()
    {
        //부드러운 이동을 위해서 1(최소) 2(최대)에서 head의  y값이 결정되도록 함
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //새로운 센터 위치를 얻어옴
        Vector3 newCenter = Vector3.zero;
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        characterController.center = newCenter;
    }
    void CheckForInput()
    {
        //설정된 컨트롤ㄹ러 중에서 인풋 입력이 있다면 이동처리를 함
        foreach(XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }
    void CheckForMovement(InputDevice device)
    {
        //레버는 primary2DAxis 값으로 읽어들일 수 있음
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            StartMove(position);
    }
    void StartMove(Vector2 position)
    {
        //이동을 위한 방향을 설정
        Vector3 direction = new Vector3(position.x, 0, position.y);//y축은 영향 받지 않음
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);// 머리의 회전 방향을 적용
        direction = Quaternion.Euler(headRotation) * direction;
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);//
    }
    void ApplyGravity()
    {
        //밑으로 떨어지는 경우 중력을 적용
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);
    }
}
