using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{

    public int _speed = 10;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



    }
}
