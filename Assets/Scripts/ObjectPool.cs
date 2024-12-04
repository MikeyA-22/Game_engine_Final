using System.Collections.Generic;
using UnityEngine;



    public class ObjectPool: MonoBehaviour
    {
        private Queue<GameObject> objectspool = new Queue<GameObject>();
    
        public static int poolsize = 4;
        [SerializeField]private int maxpoolsize = 4;
        [SerializeField] private GameObject prefab;
        void Start()
        {
            for (int i = 0; i < poolsize; i++)
            { 
                GameObject objects = Instantiate(prefab, this.transform);
                objectspool.Enqueue(objects);
                objects.SetActive(false);
            }
        
        }
    
        public GameObject GetObject()
        {
            if (objectspool.Count < maxpoolsize)
            {
                
                if (objectspool.Count > 0)
                {
                    GameObject objects = objectspool.Dequeue();
                    objects.SetActive(true);
                    return objects;
                }
                else
                {
                    GameObject objects = Instantiate(prefab, this.transform);
                    return objects;
                }    
                
            }
            else
            {
                return objectspool.Dequeue();
                //return null;
            }
        }
    
        public void ReturnObject(GameObject objects)
        {
            objectspool.Enqueue(objects);
            objects.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }