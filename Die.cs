using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [Header("User Settings")]
    public Transform playerBody;
    public float throwForce = 8f;
    public float torqueForce = 30f;
    

    [Header("Die Mapping Settings")]
    public DieFace selectedFace;
    public int selectedVector;
    public DieFace[] vectorValues;
    public Vector3[] vectorPoints;

    private Rigidbody _rb;
    private Transform _mainCam;
    private DiceGame _diceGame;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCam = Camera.main.transform;
        _diceGame = FindObjectOfType<DiceGame>();
        
    }

    public void ThrowDie(Vector3 direction)
    {
        //Convert local object space vector into world space vector 
        //Vector3 currWorldSpaceVectorTest = transform.TransformVector(direction);
        //Vector3 currWorldSpaceVector = transform.localToWorldMatrix.MultiplyVector(playerBody.forward);
        _rb.AddForce((direction) * Random.Range((throwForce/2), throwForce), ForceMode.Impulse);
        _rb.AddTorque((direction) * Random.Range((torqueForce/2), torqueForce), ForceMode.Impulse);
    }

    /**
     * Gets the dot product of each of the die's faces (vectors pointing out from each side). Returns the face
     * with the highest dot product (in other words, the side that is facing upward).
     */
    public int GetFaceUp()
    {
        float bestDot = -1f;

        for (int i = 0; i < vectorPoints.Length; ++i)
        {
            //Get the current vector we are checking
            Vector3 currVectorValue = vectorPoints[i];

            //Convert local object space vector into world space vector 
            Vector3 currWorldSpaceVector = transform.localToWorldMatrix.MultiplyVector(currVectorValue);
            //Gets the dot product between vector and the up direction(dot = 1[exact], dot = 0[perpendicular], dot = -1[opposite])
            float dot = Vector3.Dot(currWorldSpaceVector, Vector3.up);

            if (dot > bestDot)
            {
                bestDot = dot;
                selectedVector = i;
            }
        }
        selectedFace = vectorValues[selectedVector];

        return (int)selectedFace;
    }
}

public enum DieFace
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6
}