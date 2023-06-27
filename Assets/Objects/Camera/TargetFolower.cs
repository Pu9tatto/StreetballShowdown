using UnityEngine;

public class TargetFolower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetRotation;

    [SerializeField] private float _smoothSpeed = 0.125f;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _lookAtOffset;

    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;

    private Vector3 desiredPosition;
    private Vector3 desiredLookAtPosition;

    private void LateUpdate()
    {
        if (_target != null)
        {
            desiredPosition = _target.position + _offset;

            desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minX, _maxX);
            desiredPosition.z = Mathf.Clamp(desiredPosition.z, _minZ, _maxZ);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

            transform.position = smoothedPosition;

            desiredLookAtPosition = _targetRotation.position + _lookAtOffset;

            Quaternion desiredRotation = Quaternion.LookRotation(desiredLookAtPosition - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, _smoothSpeed);
        }
    }
}
