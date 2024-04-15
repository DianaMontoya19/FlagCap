using UnityEngine;
using UnityEngine.TextCore.Text;


public  class FlagObject : MonoBehaviour
{
    private static FlagObject _instance;
    public static FlagObject Instance => _instance;
    public bool follow = false;
    private FlagObject _flag;
    //private Rigidbody _rb;
    //public Rigidbody Rb => _rb;
    private Transform _transform;
    public Transform Transform => _transform;
    protected void Awake()
    {
        _instance = this;
        //_rb = GetComponent<Rigidbody>();
        _transform = transform;
    }

    public void Flags(FlagObject flag, Transform transform)
    {
        
        _flag = Instantiate(flag, transform);
        
    }
    //    private void OnCollisionEnter(Collision collision)

         
    //{
    //    _flag.gameObject.SetActive(false);
    //}
 

}

