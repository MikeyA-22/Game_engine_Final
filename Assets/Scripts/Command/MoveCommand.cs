using UnityEngine;

    public class MoveCommand: ICommand
    {

        private float movementX;
        private float speed;
        

        public MoveCommand(float movementX, float speed)
        {
            this.movementX = movementX;
            this.speed = speed;
            
        }

        public void Execute()
        {
            MegaManController._rigidbody.MovePosition(MegaManController._rigidbody.position +  new Vector3(movementX * speed, 0, 0));
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }

        
    }