using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerInput : IMovable
{
    private readonly Team _team;
    private readonly float _sensRotation;
    private readonly Rigidbody _rb;
    private readonly Transform _transform;
    private readonly float _vel;
    public float _velX;
    public float _velY;
    private bool _mine = false;

    public PlayerInput(float sensRotation, Rigidbody rb, Transform transform, float vel)
    {
        _sensRotation = sensRotation;
        _rb = rb;
        _transform = transform;
        _vel = vel;
    }

    public void Update()
    {
        _velX = Input.GetAxis("Horizontal");
        _velY = Input.GetAxis("Vertical");

        Character.Instance.WalkAnimations(_velY, _velX);

    }



    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(0f, 0f, _velY).normalized * _vel * Time.deltaTime;
        _transform.Translate(movement);

        float rotation = _velX * _sensRotation * Time.deltaTime;
        _transform.Rotate(0f, rotation, 0f);
    }


    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out FlagObject flag))
        {
            FlagManager.Instance.CaptureFlag(Character.Instance.transform,true);
            _mine = true;
        }
    }

    public void OnCollisionExit(Collision collision) {}

    public void OnTriggerEnter(Collider other) {

        if(other.tag == "PlayerFlag" && _mine)
        {
            FlagManager.Instance.Point(Team.Blue);
            _mine = false;
        }
    
    
    }

    public void OnTriggerExit(Collider other) {}

}