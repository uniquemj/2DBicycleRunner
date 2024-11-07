using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlatformController : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float width = 40f;
    public Vector3 startposition;

    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPostion = Mathf.Repeat(Time.time * scrollSpeed, width);
        transform.position = startposition + Vector3.left * newPostion;
    }
}
