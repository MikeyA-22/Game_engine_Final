using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BlizzardMan : MonoBehaviour
{
    private Rigidbody rb;
    private ObjectPool snowPool;
    [SerializeField] private float range = 5f;
    [SerializeField]private float timeBtwSpawn = 0.1f;
    [SerializeField]private GameObject firstPoint;
    float timeOfLastSpawn;

    private Pauser.Pauser _pauser;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        snowPool = GetComponent<ObjectPool>();
        firstPoint = GameObject.Find("FirstPoint");
        _pauser = GetComponent<Pauser.Pauser>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Player")
            {
                _pauser.OnSlowDown();
                
                //timeOfLastSpawn = 0;
                if (Time.time - timeOfLastSpawn >= timeBtwSpawn)
                {
                    _pauser.OnSlowDown();
                    //fire at player
                    for (int i = 0; i < 4; i++)
                    {
                        //List<GameObject> snowObjects = new List<GameObject>();
                        //snowObjects.Add(snowPool.GetObject());
                        GameObject snow = snowPool.GetObject();
                        snow.transform.position = firstPoint.transform.position + new Vector3(Random.Range(-1, 1), 0, 0);
                            
                    }  
                    timeOfLastSpawn = Time.time;
                }
                
                //rb.position = Vector3.MoveTowards(transform.position, collider.transform.position, Time.deltaTime * 10f);
                

            }
            else
            {
                _pauser.OnPlay();
            }
        }
        
    }
    
    
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
