using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviourExtend
{
    [SerializeField] private GameObject regularAmmoPrefab = null;

    public GameObject RegularAmmoPrefab
    {
        get { return regularAmmoPrefab; }
    }
}
