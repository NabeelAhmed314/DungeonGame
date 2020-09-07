using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1->bottom door
    //2->top door
    //3->left door
    //4->right door 

    private RoomTemplate templates;
    private int rand;

    public bool spawned;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }


    private void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("SpawnPoint"))
        {
            if(collision.gameObject.GetComponent<RoomSpawner>() != null)
            {
                if (collision.gameObject.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                    Debug.Log("Object to Destroy=>" + collision.gameObject.name);
                    Destroy(gameObject);
                }
                spawned = true;
            }

        }
    }
}
