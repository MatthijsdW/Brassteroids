using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttachedEquipment : MonoBehaviour
{
    public GameObject attachedEquipment;
    private GameObject equipmentInstance;

    private void Start()
    {
        attachedEquipment.transform.position = new Vector3(0, 0);
        equipmentInstance = Instantiate(attachedEquipment);
        equipmentInstance.transform.parent = transform;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        equipmentInstance?.GetComponent<Equipment>().UseEquipment();
    }
}
