using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour


{

    public int forcaPulo = 9;
    public int velocidade = 8;
    private Rigidbody rb;
    private AudioSource source;
    public bool noChao;
    public Transform cameraPivot;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        TryGetComponent(out rb);
        TryGetComponent(out source);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(!noChao && collision.gameObject.tag == "Chao")
        {
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        Vector3 direcao = cameraPivot.forward * v + cameraPivot.right * h;
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        
        if(Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            //pulo
            source.Play();
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    
        
        if(transform.position.y <= -10)
        {
            //Jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
