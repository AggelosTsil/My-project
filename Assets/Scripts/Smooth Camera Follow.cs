using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    #region Variables
    
        private Vector3 _offset;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime;
        private Vector3 _currentVelocity = Vector3.zero;
        public bool LookAtTarget = true;
        public Transform targetobject;
        
    #endregion
    
    #region Unity callbacks
    
        private void Awake() => _offset = transform.position - target.position;

        private void LateUpdate()
        {
           Vector3 targetPosition = target.position + _offset;
           transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
            //transform.rotation = target.rotation; //it cant be this easy
            if (LookAtTarget){
                transform.LookAt(targetobject);
            }
            
        }
        
    #endregion
}
