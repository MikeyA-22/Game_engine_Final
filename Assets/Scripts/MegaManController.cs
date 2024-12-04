using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]


public class MegaManController : MonoBehaviour
{
    public static Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _jumpHeight = 280f;
    float moveHorizontal;
    JumpCommand jumpCommand;
    ICommand command;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        _rigidbody = GetComponent<Rigidbody>();
        jumpCommand = new JumpCommand(_jumpHeight, _jumpForce);  
        
        EnemyBullet.messThingsUp += changeCommands;

    }

    // Update is called once per frame
    void Update()
    {
        
        moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) & transform.position.y < _jumpHeight)
        {
            
            CommandManager.Instance.AddCommand(jumpCommand);
        }
        //_rigidbody.velocity = new Vector3(moveHorizontal * _speed, _rigidbody.velocity.y, 0);
        if (moveHorizontal != 0)
        {
            command = new MoveCommand(moveHorizontal, _speed);
            CommandManager.Instance.AddCommand(command);
        }
    }

    void changeCommands()
    {
        _jumpHeight = 0;
        moveHorizontal = moveHorizontal * -1;
        Debug.Log("Command Change");
        command = new ReverseMoveCommand(moveHorizontal, _speed);
        jumpCommand = new JumpCommand(_jumpHeight, _speed);
    }
}
