using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Seat : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private InputControls _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _input = new InputControls();
    }

    private void OnEnable()
    {
        _input.Enable();

        _input.Joints.swing.performed += context => Swing();
    }

    private void OnDisable()
    {
        _input.Disable();

        _input.Joints.swing.performed -= contex => Swing();
    }

    private void Swing()
    {
        _rigidbody.AddForce(transform.up * 10, ForceMode.Impulse);
    }
}
