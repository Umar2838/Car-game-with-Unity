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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
    }
    void MotorForce() {
        // Move the collider by motorTorque
        frontRightWheelCollider.motorTorque = 10f;
        frontLeftWheelCollider.motorTorque = 10f;
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
