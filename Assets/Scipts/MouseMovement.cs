using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{ 

    public Vector2 turn;
    public float sensitivy = .5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject mover;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivy;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

      


        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.deltaTime;
        mover.transform.Translate(deltaMove);

    }
}
