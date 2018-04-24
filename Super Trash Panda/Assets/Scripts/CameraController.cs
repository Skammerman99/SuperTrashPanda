using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 position;
    public float moveSpeed = 5f;

    private static bool exists;

    // Use this for initialization
    void Start()
    {
        if (!exists)
        {
            DontDestroyOnLoad(transform.gameObject);
            exists = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, position, moveSpeed * Time.deltaTime);
    }
}
