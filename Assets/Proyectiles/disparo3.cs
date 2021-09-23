using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo3 : MonoBehaviour
{

    public float velocityx = 5f;
    private const string EnemyTag = "Zombi";
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5 /*Duración*/); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityx, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {     
        
        if(other.gameObject.CompareTag(EnemyTag))
        {           
            Destroy(this.gameObject);
            
                        
        }
    }
}
