using Photon.Pun;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private int objNum;
    private Map map;
    public Transform transform;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    void Awake()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        transform = gameObject.transform;
        lastPosition = transform.localPosition;
        lastRotation = transform.localRotation;
    }

    public bool NeedSyncPosition()
    {
        if (transform.localPosition != lastPosition)
        {
            return true;
        }
        return false;
    }

    public bool NeedSyncRotation()
    {
        if (transform.localRotation != lastRotation)
        {
            return true;
        }
        return false;
    }

    public void AfterPositionSync()
    {
        lastPosition = transform.localPosition;
    }

    public void AfterRotationSync()
    {
        lastRotation = transform.localRotation;
    }

    public void UpdPosition(float x, float y, float z)
    {
        transform.localPosition = new Vector3(x, y, z);
        AfterPositionSync();
    }

    public void UpdRotation(float x, float y, float z, float w)
    {
        transform.localRotation = new Quaternion(x, y, z, w);
        AfterRotationSync();
    }

    public void SetNumber(int objNum)
    {
        this.objNum = objNum;
    }
}
