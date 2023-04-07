using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{ 

    public Vector2 turn;
    public float sensitivyX = 5f;
    public float sensitivyY = 0.3f;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject mover;
    public Transform mainCamera;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCamera.localRotation = Quaternion.Euler(-15, 0, 0);
        turn.y = -15;
    }

    // Update is called once per frame
    void Update()
    {   float mouseY = Input.GetAxis("Mouse Y") * sensitivyY;

        // Move Human on x axis
        turn.x += Input.GetAxis("Mouse X") * sensitivyX;
        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        // Move Camera on y axis
        //Vector3 moveCam = new Vector3(0, Input.GetAxis("Mouse Y") * sensitivy / 800, 0);

        if (turn.y - mouseY < -2 && turn.y - mouseY > -20)
        {
            turn.y -= mouseY;
            mainCamera.localRotation = Quaternion.Euler(turn.y, 0, 0);
        }
        //mainCamera.Translate(moveCam);


        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.deltaTime;
        mover.transform.Translate(deltaMove);

    }
}
