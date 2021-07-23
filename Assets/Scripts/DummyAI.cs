using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAI : MonoBehaviour
{
     Animator Dummy;
    // Start is called before the first frame update
    void Start()
    {
        Dummy = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Dummy.SetTrigger("Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
