using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        this.difference = player.transform.position.x - this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.player.transform.position.x - difference, 1,-10);
    }
}
