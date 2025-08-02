using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.SetActive(true);
    }
}
