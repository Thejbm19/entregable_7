using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 10f;

    private PlayerController playerControllerScript;


    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); //trobar es script des player
    }


    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver) // ! es per dir si aixo es false
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // moure a esquerra
        }

    }


}
