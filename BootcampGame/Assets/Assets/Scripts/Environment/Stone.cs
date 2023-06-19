using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool testtt = false;
    private GameObject stone_wall_1;
    private GameObject stone_wall_2;
    private GameObject stone_bricks;
    [SerializeField] private GameObject[] _bricks;

    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        stone_wall_1 = gameObject.transform.GetChild(0).gameObject;
        stone_wall_2 = gameObject.transform.GetChild(1).gameObject;
        stone_bricks = gameObject.transform.GetChild(2).gameObject;
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BigBox"))
        {
            stone_wall_1.SetActive(false);
            stone_wall_2.SetActive(true);
            stone_bricks.SetActive(true);

            Vector3 force = new Vector3(5f, 0f, 0f);
            foreach (GameObject i in _bricks)
            {
                Rigidbody rb = i.GetComponent<Rigidbody>();
                rb.AddForce(force);
            }
            boxCollider.enabled = false;
        }
    }


}
