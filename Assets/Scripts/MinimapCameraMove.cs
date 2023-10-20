using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMove : MonoBehaviour
{

    public GameObject followedPlayer;
    public float height;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
        followedPlayer.transform.position.x, height,
        followedPlayer.transform.position.z
        );
    }
}
