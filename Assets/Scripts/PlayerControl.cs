using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character2D
{
    [RequireComponent(typeof(Movement))]
    public class PlayerControl : MonoBehaviour
    {
        private Movement movement;

        private bool jump;

        private int attack;

        private void Awake()
        {
            movement = GetComponent<Movement>();
        }

        private void Update()
        {
            if (!jump)
            {
                jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w");
            }
            CheckAttack();
        }


        private void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            movement.Move(moveHorizontal, jump, attack);
            jump = false;
            attack = 0;
        }

        private void CheckAttack()
        {
            if (attack == 0)
            {
                if (Input.GetKeyDown("i"))
                {
                    attack = 1;
                }
                else if (Input.GetKeyDown("o"))
                {
                    attack = 2;
                }
                else if (Input.GetKeyDown("p"))
                {
                    attack = 3;
                }
            }
        }
    }
}