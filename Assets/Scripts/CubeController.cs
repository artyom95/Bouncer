using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeController : MonoBehaviour
{
    [SerializeField] 
    private GameObject _plane;

    [SerializeField]
    private GameObject _prefabCube;

   

    private GameObject _cube;
    private Rigidbody _cubeRigidBody;
    public Color _color;    // сделать синглтон;
    const float Force = 250f;

    private const float LineBorder = 9.5f;

    // Start is called before the first frame update
    void Start()
    {
        InstanceCube();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void InstanceCube()
    {
        _cube = Instantiate(_prefabCube);
        _cube.transform.SetParent(_plane.transform);
        _cube.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        _cubeRigidBody = _cube.GetComponent<Rigidbody>();
        _color = _cube.GetComponent<MeshRenderer>().material.color;
        
    }

    public void CheckPosition()
    {
        if (_cube != null)
        {
            if (_cube.transform.position.x > LineBorder || _cube.transform.position.x < -LineBorder ||
                _cube.transform.position.z > LineBorder || _cube.transform.position.z < -LineBorder)
            {
                Destroy(_cube);
                InstanceCube();
            }
        }
    }

    public void MoveCube(Vector3 mousePoint)
    {
        _cubeRigidBody.AddForce((mousePoint - _cube.transform.position).normalized * Force, ForceMode.Force);
    }
    
  
}