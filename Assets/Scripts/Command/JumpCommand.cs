using UnityEngine;

namespace Command
{
    public class JumpCommand: ICommand
    {
        private float jumpHeight;
        private float jumpPower;

        public JumpCommand(float jumpHeight, float jumpPower)
        {
            this.jumpHeight = jumpHeight;
            this.jumpPower = jumpPower;
        }


        public void Execute()
        {
            MegaManController._rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}