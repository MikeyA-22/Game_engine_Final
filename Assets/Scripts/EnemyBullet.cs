using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    [SerializeField] GameObject target = null;
    [SerializeField] ObjectPool pool;
    [SerializeField] GameObject firstPoint;
    bool first = false;

    public static Action messThingsUp;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        pool = GameObject.FindGameObjectWithTag("Pool").GetComponent<ObjectPool>();
        firstPoint = GameObject.FindGameObjectWithTag("FirstPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            transform.position = firstPoint.transform.position;    
        }
        

        if (transform.position.y >  3)
        {
            
                first = false;
                transform.LookAt(target.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);    
            
            
        }
        
                
        
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pool.ReturnObject(this.gameObject);
            messThingsUp?.Invoke();
        }

        if (other.tag == "FirstPoint")
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
        }
    }
}
