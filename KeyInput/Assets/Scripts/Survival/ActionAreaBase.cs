using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survival
{
    

    public class ActionAreaBase : MonoBehaviour
    {
        public ActionType actionType;
        public Transform actionPos;

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Player"))
            {

                SurvivalCharacter character = other.GetComponent<SurvivalCharacter>();
                character.NotifyInteraction(actionType, true);
                character.transform.position = actionPos.position;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            
            if (other.CompareTag("Player"))
            {

                SurvivalCharacter character = other.GetComponent<SurvivalCharacter>();
                character.NotifyInteraction(actionType, false);
            }

        }

    }

}


