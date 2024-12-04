using UnityEngine;

namespace Command
{
    public class ReverseMoveCommand: ICommand
    {
        private float movementX;
        private float speed;
        
        public ReverseMoveCommand(float movementX, float speed)
        {
            this.movementX = movementX;
            this.speed = speed;
            
        }

        public void Execute()
        {
            MegaManController._rigidbody.MovePosition(MegaManController._rigidbody.position -  new Vector3(movementX * speed * -1, 0, 0));
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}