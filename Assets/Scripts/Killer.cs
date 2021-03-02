using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Killer : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    //Logic if you want
    private void OnCollisionEnter(Collision collision)
    {
        Killable killable = collision.gameObject.GetComponent<Killable>();
        if (killable) killable.Die();
    }
}
