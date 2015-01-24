using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Ammo))]
public class PlayerInput : MonoBehaviourExtend
{
    [SerializeField] private bool isGamepad = false;
    private CharacterController characterController = null;
    private Ammo ammo = null;

	void Start ()
	{
	    characterController = GetComponent<CharacterController>();
	    ammo = GetComponent<Ammo>();
	}
	
	void Update ()
	{
	    float vertical = isGamepad ? Input.GetAxis("VerticalGP") : Input.GetAxis("Vertical");
	    float horizontal = isGamepad ? Input.GetAxis("HorizontalGP") : Input.GetAxis("Horizontal");

	    characterController.Direction = Vector3.zero;
        characterController.Direction += vertical * Vector3.forward;
        characterController.Direction += horizontal * Vector3.right;

	    /*
	    vertical = (int) Input.GetAxisRaw("Vertical");
	    horizontal = (int) Input.GetAxisRaw("Horizontal");
*/
	    //if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
	    if (!Mathf.Approximately(vertical, 0) || !Mathf.Approximately(horizontal, 0))
	    {
	        TransformCached.rotation = Quaternion.LookRotation(characterController.Direction, Vector3.up);
	    }

	    if (Input.GetButtonDown("Plant"))
	    {
	        Instantiate(ammo.RegularAmmoPrefab, TransformCached.position, Quaternion.identity);
            audio.Play();
	    }
	}
}
