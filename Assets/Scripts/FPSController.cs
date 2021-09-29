using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    [SerializeField] private float _yawSpeed;
    [SerializeField] private float _pitchSpeed;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private GameObject _pitchController;
    [SerializeField] private bool _invertPitch;
    [SerializeField] private bool _invertYaw;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _frontKey;
    [SerializeField] private KeyCode _backKey;
    [SerializeField] private KeyCode _rightKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _shift;
    [SerializeField] private float _runMultiplier;

    [Header("Jump")]
    [SerializeField] private KeyCode _space;
    [SerializeField] private float _timeToMaxHeight;
    [SerializeField] private float _height;
    [SerializeField] private bool _onGround;
    [SerializeField] private bool _onContactCeiling;

    float _verticalSpeed;
    float _currYaw;
    float _currPitch;
    float _gravity;
    float _jumpSpeed;
    void Awake()
    {
        _currYaw = transform.rotation.eulerAngles.y;
        _currPitch = _pitchController.transform.rotation.eulerAngles.x;

        _gravity = -2 * _height / (_timeToMaxHeight * _timeToMaxHeight);
        _jumpSpeed = 2 * _height / _timeToMaxHeight;
    }

    //TODO: Calcular els inputs en el update.

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Rotate();
    }

    private void Move()
    {
        /*
         * Computes the forward and right vector by trigonometry.
         * If _currYaw is 0, forward would be (0,0,1), if _currYaw is 90 degrees then forward is (1,0,0).
         * The same applies with right vector, only with a 90 degree offset.
         */
        Vector3 forward = new Vector3(Mathf.Sin(_currYaw*Mathf.Deg2Rad), 0.0f ,Mathf.Cos(_currYaw*Mathf.Deg2Rad));
        Vector3 right = new Vector3(Mathf.Sin((_currYaw + 90.0f) * Mathf.Deg2Rad), 0.0f, Mathf.Cos((_currYaw + 90.0f) * Mathf.Deg2Rad));
        Vector3 lMovement = new Vector3();
        
        /*
         * Get the front/back input. If going backwards magnitude is the same but with inverse direction
         * (represented with a substraction)
         */
        if(Input.GetKey(_frontKey))
        {
            lMovement += forward;
        } else if (Input.GetKey(_backKey))
        {
            lMovement -= forward;
        }

        /*
         * The same applies here
         */
        if (Input.GetKey(_leftKey))
        {
            lMovement -= right;
        } else if (Input.GetKey(_rightKey))
        {
            lMovement += right;
        }

        if (_onGround && Input.GetKey(_space)) _verticalSpeed = _jumpSpeed;

        /*
         * Make sure vector always has magnitude <= 1. If not, we could be going faster by going diagonally,
         * as magnitude of (1,0,1) is NOT 1.
         */
        lMovement.Normalize();

        /*
         * lMovement is our direction. We can now multiply it by a scalar number to increase the magnitude,
         * and with that, the speed of our character.
         */
        lMovement *= _moveSpeed * Time.fixedDeltaTime * (Input.GetKey(_shift) ? _runMultiplier : 1);

        _verticalSpeed += _gravity * Time.fixedDeltaTime;

        lMovement.y = _verticalSpeed * Time.fixedDeltaTime;

        //Apply the movement of the vector to our character controller.
        CollisionFlags colls = _characterController.Move(lMovement);

        _onGround = (colls & CollisionFlags.Below) != 0;
        _onContactCeiling = (colls & CollisionFlags.Above) != 0;

        if (_onGround) _verticalSpeed = 0.0f;
        if (_onContactCeiling && _verticalSpeed > 0.0f) _verticalSpeed = 0.0f;


    }
    private void Rotate()
    {
        /*
         * Get the difference between frames of mouse position. Both axis. DO NOT
         * USE delta time after, you are already using frame specific results.
         */
        float xMousePos = Input.GetAxis("Mouse X");
        float yMousePos = Input.GetAxis("Mouse Y");

        /*
         * Use the mouse variables to change the angles of our character.
         * If invert variables == true, then the result will be multiplied by -1
         * Clamp is to limit a number between a minimum and a maximum (avoids the WIIIIII effect)
         */
        _currYaw += xMousePos * _yawSpeed * (_invertYaw ? -1 : 1);
        _currPitch -= yMousePos * _pitchSpeed * (_invertPitch ? -1 : 1);
        _currPitch = Mathf.Clamp(_currPitch, _minPitch, _maxPitch);

        /*
         * Set final yaw angle to our player character.
         * IMPORTANT: We set the pitch angle to our pitch controller INSTEAD of our character
         */
        transform.rotation = Quaternion.Euler(0.0f, _currYaw, 0.0f);
        _pitchController.transform.localRotation = Quaternion.Euler(_currPitch, 0, 0);
    }

    private void OnEnable()
    {
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
    }
}
