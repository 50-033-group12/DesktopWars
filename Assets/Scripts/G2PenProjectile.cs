using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2PenProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        collission();
        if(col.tag == "Ground" || col.tag == "Obstacles"){
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    public void collission(){
        Debug.Log("Collision behaviour here");
    }
}