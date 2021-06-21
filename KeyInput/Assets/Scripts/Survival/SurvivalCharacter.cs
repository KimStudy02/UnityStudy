using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Survival
{
    public enum ActionType
    {
        Cook,
        Shake,

    }

    public class SurvivalCharacter : MonoBehaviour
    {
        

        public float speed;
        public Animator animator;
        public bool isMove;       
        public bool isInteractable;        
        public ActionType interactableType;
        public GameObject insteractableImg;


        private void Update()
        {
            isMove = false;

            if (Input.GetKey(KeyCode.W))
            {
                transform.position = transform.position + (transform.forward * speed * Time.deltaTime);
                isMove = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position + (-transform.right * speed * Time.deltaTime);
                isMove = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = transform.position + (-transform.forward * speed * Time.deltaTime);
                isMove = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position + (transform.right * speed * Time.deltaTime);
                isMove = true;
            }

            if(isInteractable == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    PlayInteractableAction();
                }
            }

            if(isMove)
            {
                bool isAction = animator.GetBool("isAction");
                if(isAction)
                {
                    animator.SetBool("isAction", false);
                }
            }
            

            animator.SetBool("isMove", isMove);

        }

        public void NotifyInteraction(ActionType action, bool interactable)
        {
            isInteractable = interactable;
            interactableType = action;
            insteractableImg.SetActive(isInteractable);


        }

        public void PlayInteractableAction()
        {
            animator.SetBool("isAction", true);

            switch (interactableType)
            {
                case ActionType.Cook:
                    animator.SetTrigger("triggerCook");
                    break;
                case ActionType.Shake:
                    animator.SetTrigger("triggerShake");
                    break;
            }
        }
    }

}

