using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Survival
{


    public class CameraController : SingletonBase<CameraController>
    {
        public Camera mainCamera;
        public Cinemachine.CinemachineVirtualCamera followCamera;
        public Cinemachine.CinemachineFreeLook freeLookCamera;
        public float freeLookSpeed;

        public void SetActiveFreeLookCamera(bool isActive)
        {
            freeLookCamera.gameObject.SetActive(isActive);
        }

        public void CameraRotate(float x, float y)
        {
            freeLookCamera.m_XAxis.m_InputAxisValue += x * freeLookSpeed * Time.deltaTime;
            freeLookCamera.m_YAxis.m_InputAxisValue += y * freeLookSpeed * Time.deltaTime;
        }
    }
}


