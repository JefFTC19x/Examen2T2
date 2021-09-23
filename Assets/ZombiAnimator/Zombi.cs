using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{   
    public int vida =10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("simple"))
        {
           vida-=2;      
           Debug.Log(vida);      
        } 
        if (collision.gameObject.CompareTag("medio"))
        {
           vida-=5;      
           Debug.Log(vida);      
        }  
        if (collision.gameObject.CompareTag("grande"))
        {
           vida=0;      
           Debug.Log(vida);      
        }    
        if(vida<0)
        {
            vida=0;
        }   
        if (vida ==0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
