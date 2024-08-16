using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [Header("Info")]
    private float speed = 8.0f;     //�̵� �ӵ�
    private float jumpForce = 2.5f; //���� ��
    private float gravity = -10f;   //�߷� ��(�ݵ�� ����������)

    [Header("State")]
    bool isRun; //�޸��� ���� ��

    private Vector3 moveDirection;  //�̵� ����

    [SerializeField] private Transform cameraTransform;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        //�� ��ġ�� �浹�� üũ�� �浹 ���̶�� true �ƴϸ� false
        if (characterController.isGrounded == false)
        {
            //�߷� ����
            moveDirection.y += gravity * Time.deltaTime;
        }
        //moveDirection�� �������� isRun�� �ǰ� speed�� �ӵ��� �̵�
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// ���� ������ �Ű������� �޾ƿ��� ���� ������ moveDirection�� ����
    /// </summary>
    public void MoveTo(Vector3 direction)
    {
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void JumpTo()
    {
        //�� ��ġ�� �浹�� üũ�� �浹 ���̶�� true �ƴϸ� false
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}