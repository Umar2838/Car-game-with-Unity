using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider backRightWheelCollider;
    public WheelCollider backLeftWheelCollider;

    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform backRightWheelTransform;
    public Transform backLeftWheelTransform;

    public Transform carCentreOfMassTransform;
    public Rigidbody rigidBody;
    
    public float motorForce = 100f;
    public float steeringAngle = 30f;
    public float brakeForce = 1000f;

    float veticalInput;
    float horizontalInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody.centerOfMass = carCentreOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBrakes();
    }
    void GetInput(){
        // GetAxis method is used to take input from keyboard vertical for up , down , W , S and Horizontal for right , left , A , D
        veticalInput =  Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

    } 
    void ApplyBrakes(){
        if (Input.GetKey(KeyCode.Space)){
        frontRightWheelCollider.brakeTorque = brakeForce;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        backRightWheelCollider.brakeTorque = brakeForce;
        backLeftWheelCollider.brakeTorque = brakeForce;
        }
        else{
                 frontRightWheelCollider.brakeTorque = 0f ;
        frontLeftWheelCollider.brakeTorque = 0f;
        backRightWheelCollider.brakeTorque = 0f;
        backLeftWheelCollider.brakeTorque = 0f;
        }
        
    }
    void MotorForce() {
        // Move the collider by motorTorque
        frontRightWheelCollider.motorTorque = motorForce * veticalInput;
        frontLeftWheelCollider.motorTorque = motorForce * veticalInput;
    }
    void Steering(){
        frontRightWheelCollider.steerAngle = steeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steeringAngle * horizontalInput;
    }
    void UpdateWheels(){
        RotateWheel(frontRightWheelCollider,frontRightWheelTransform);
        RotateWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        RotateWheel(backRightWheelCollider,backRightWheelTransform);
        RotateWheel(backLeftWheelCollider,backLeftWheelTransform);


    }
    void RotateWheel(WheelCollider wheelCollider,Transform transform){

        Vector3 pos;
        Quaternion rot;
        // Get the position and rotaion of wheel collider by GetWorldPose
        wheelCollider.GetWorldPose(out pos , out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
