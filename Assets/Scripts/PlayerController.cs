using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //Bace Var
    public static PlayerController Player;
    public GameObject BallTarget;

    //Paddle Var    
    [Tooltip("The Refrence to the Left Paddle")]
    public GameObject paddleL;
    [Tooltip("The Refrence to the Right Paddle")]
    public GameObject paddleR;
    [Tooltip("Controlles the speed that the Paddles move, this affect's the velocity emparted to the ball")]
    public float paddleSwingSpeed;
    HingeJoint2D paddleHingeL;
    HingeJoint2D paddleHingeR;
    JointMotor2D paddleMotorL;
    JointMotor2D paddleMotorR;


    // Use this for initialization
    void Start () {
        //Setting PlayerController Singleton.
        Player = this;

        //Calling All releveant parts for The paddles
        paddleHingeL = paddleL.GetComponent<HingeJoint2D>();
        paddleMotorL = paddleHingeL.motor;
        paddleHingeR = paddleR.GetComponent<HingeJoint2D>();
        paddleMotorR = paddleHingeR.motor;

    }
	void Update()
    {
        PaddleInput();
    }

    void FixedUpdate()
    {
        
    }

    //Handles the player inputs
    void PaddleInput()
    {
        //handles Input by cheking states, Then using those states to set the velocity of the motors.
        if (Input.GetButton("Left") == true)
        {
            PaddleSwing(paddleHingeL, paddleMotorL, paddleSwingSpeed*-1);
        }
        else
        {
            PaddleSwing(paddleHingeL, paddleMotorL, paddleSwingSpeed );
        }
        
        if (Input.GetButton("Right") == true)
        {
            PaddleSwing(paddleHingeR, paddleMotorR, paddleSwingSpeed );
        }
        else
        {
            PaddleSwing(paddleHingeR, paddleMotorR, paddleSwingSpeed * -1);
        }

    }
    //swings Paddles
    void PaddleSwing(HingeJoint2D _hinge, JointMotor2D _motor, float _speed)
    {
        // Swings paddles by calling to the motor of the Hing2D and changing the speed.
        _motor.motorSpeed = _speed;
        _hinge.motor = _motor;
    }
}
