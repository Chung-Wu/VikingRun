using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Normal_1;     //0
    public GameObject Normal_2;     //1
    public GameObject Normal_3;     //2
    public GameObject Normal_4;     //3
    public GameObject Normal_5;     //4
                                   
    public GameObject Corner_1;     //5
    public GameObject Corner_2;     //6
    public GameObject Corner_3;     //7
    private GameObject player;

    public int Count = 10;

    private int steps = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Normal_1, new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));
        create_floor();

    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void create_floor()
    {
        steps = Random.Range(1, 11);
        Debug.Log("steps : " + steps);
        int i = 0;
        int rand = 0;

        for(i=0; i<steps-1; i++)
        {
            rand = Random.Range(0, 8);

            Debug.Log("i" + i);
            Debug.Log("rand" + rand);
            GameObject temp = Instantiate(Normal_1, transform.forward *8*i, Quaternion.Euler(0, 90, 0));

            Transform parent_trans = this.transform;
            temp.transform.parent = parent_trans;
            temp.AddComponent<MapGenerator>();
            //temp.GetComponent<MapGenerator>().Normal_1 = Normal_1;
        }

        //create the corner 
        /*
        rand = Random.Range(5, 8);
        Debug.Log("the corner: " + rand);
        if(rand == 5)
        {
            Instantiate(Corner_1, transform.forward * 10, Quaternion.identity);
        }
        else if(rand == 6)
        {
            Instantiate(Corner_1, transform.forward * 10, Quaternion.identity);
        }
        else if(rand == 7)
        {
            Instantiate(Corner_1, transform.forward * 10, Quaternion.identity);
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        steps--;
        if(steps <= 1)
        {
            create_floor();
        }
    }
}
