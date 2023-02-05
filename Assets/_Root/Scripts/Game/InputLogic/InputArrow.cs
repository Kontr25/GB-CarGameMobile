using UnityEngine;

namespace Game.InputLogic
{
    internal class InputArrow : BaseInputView
    {
        protected override void Move()
        {
            Vector3 direction = CalcDirection();
            float moveValue = Speed * Time.deltaTime * direction.x;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else
                OnLeftMove(abs);
        }

        private Vector3 CalcDirection()
        {
            Vector3 direction = Vector3.zero;
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector3.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector3.left;
            }

            return direction;
        }
    }
}