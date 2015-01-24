using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Ammo))]
public class PlayerInput : MonoBehaviourExtend
{
    [SerializeField] private bool isGamepad = false;
    [SerializeField] private float plantCooldown = 1.0f;

    private CharacterController characterController = null;
    private Ammo ammo = null;

    private float coolingTimePassed = 0.0f;

	void Start ()
	{
	    characterController = GetComponent<CharacterController>();
	    ammo = GetComponent<Ammo>();
        coolingTimePassed = plantCooldown;
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

	    bool hasPlanted = isGamepad ? Input.GetButtonDown("PlantGP") : Input.GetButtonDown("Plant");
	    if (hasPlanted)
	    {
            Plant();
	    }

        coolingTimePassed -= Time.deltaTime; // Update cooldown time passed
	}

    void Plant()
    {
        if (coolingTimePassed < 0.0f)
        {
            Instantiate(ammo.RegularAmmoPrefab, TransformCached.position, Quaternion.identity);
            audio.Play();
            coolingTimePassed = plantCooldown;
        }
    }
}
