using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
public float speed=1;

private Vector3 direccion;

private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direccion = (playerRigidbody.transform.position - transform.position).normalized;
           transform.Translate(direccion*speed*Time.deltaTime);
    }
}
