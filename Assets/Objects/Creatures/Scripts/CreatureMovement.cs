using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CreatureMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void Move(Vector2 direction, float speed)
    {
        _characterController.Move(new Vector3(direction.x * speed * Time.deltaTime, 0, direction.y * speed * Time.deltaTime));
        TryRotate(direction);
    }

    private void TryRotate(Vector2 direction)
    {
        if (direction.x != 0 || direction.y != 0)
        {
            Vector3 rotateDirection = _characterController.velocity;
            rotateDirection.y = 0;

            if (rotateDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(rotateDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
