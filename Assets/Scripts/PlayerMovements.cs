using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    public static PlayerMovements instance;

    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private SaveSystem saveSystem;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        saveSystem = SaveSystem.instance;
    }

    private void Start()
    {
        if (SaveSystem.instance.HasASave())
        {
            transform.position = new Vector3( saveSystem.data.playerInfo.x, saveSystem.data.playerInfo.y, 0 );
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }


    }
}
