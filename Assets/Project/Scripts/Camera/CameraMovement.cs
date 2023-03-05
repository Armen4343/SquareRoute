using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform _player;
    [SerializeField]
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(Mathf.Lerp(transform.position.x, _player.position.x, delay * Time.deltaTime), Mathf.Lerp(transform.position.y, _player.position.y, delay * Time.deltaTime), transform.position.z);
        transform.position = newPosition;
    }
}
