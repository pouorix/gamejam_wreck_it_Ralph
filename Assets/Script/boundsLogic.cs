using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundsLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boundR;
    public GameObject boundL;
    public bool isLeft;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Flix"))
        {
            if (isLeft)
            {
                other.transform.position = new Vector3(boundR.transform.position.x - 1, other.transform.position.y,
                    other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(boundL.transform.position.x +1, other.transform.position.y,
                    other.transform.position.z);
            }
        }
    }
}