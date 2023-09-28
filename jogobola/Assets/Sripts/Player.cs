using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour


{

    public int forcaPulo = 9;
    public int velocidade = 8;
    private Rigidbody rb;
    public bool noChao; 


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        TryGetComponent(out rb);
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
        

	    Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        
        if(Input.GetKeyDown(KeyCode.Space) && noChao)
        {
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
