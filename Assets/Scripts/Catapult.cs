using UnityEngine;

[RequireComponent(typeof(SpringJoint), typeof(Rigidbody))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private float _launchSpringCount = 60;
    [SerializeField] private float _chargeSpringCount = 0;
    [SerializeField] private Rigidbody _spoon;
    [SerializeField] private Spawner _spawner;

    private SpringJoint _joint;
    private InputControls _input;

    private void Awake()
    {
        _joint = GetComponent<SpringJoint>();
        _input = new InputControls();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Joints.launch.performed += context => Launch();
        _input.Joints.сharge.performed += context => Charge();
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Joints.launch.performed -= context => Launch();
        _input.Joints.сharge.performed -= context => Charge();
    }

    private void Launch()
    {
        _joint.spring = _launchSpringCount;
        _spoon.WakeUp();
    }

    private void Charge()
    {
        _joint.spring = _chargeSpringCount;
        _spawner.StartTimer();
    }
}
