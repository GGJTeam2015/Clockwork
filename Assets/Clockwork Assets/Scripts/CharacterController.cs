using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviourExtend
{
    public Vector3 Direction = Vector3.zero;
    public float MovementSpeed = 10.0f;
    public float RotationSpeed = 5.0f;
    public float CurrentSpeed = 0f;

    private Vector3 velocity;
	
	void Start () {
	
	}


    void LateUpdate()
    {
        velocity = Direction.normalized*MovementSpeed;
        velocity.y = RigidbodyCached.velocity.y;
        RigidbodyCached.velocity = velocity;
    }
}
