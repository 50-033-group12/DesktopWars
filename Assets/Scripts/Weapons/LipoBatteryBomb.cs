using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LipoBatteryBomb : MonoBehaviour
{
    public AudioClip sfx;
    //adjust later
    public int damage = 100;
    public float radius = 3f;
    public float timeToWait = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bombTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator bombTimer(){
        yield return new WaitForSeconds(timeToWait);
        explode();
    }

    public void explode(){
        Debug.Log("BOOM");

        //get all collider within radius
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach(Collider c in hitColliders){
            // playe rlayer is 6
            if(c.gameObject.layer == 6){
                Debug.Log("Player hit");
                DamageRequest req = new DamageRequest(damage, false, this.gameObject);
                c.GetComponentInParent<IDamageable>().AfflictDamage(req);
            }
        }
        this.GetComponent<AudioSource>().PlayOneShot(sfx);
        Destroy(gameObject, sfx.length);
    }
}
