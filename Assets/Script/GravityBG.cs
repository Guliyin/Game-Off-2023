using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBG : MonoBehaviour
{
    [SerializeField] Color up;
    [SerializeField] Color down;

    MeshRenderer m_Renderer;
    private void Awake()
    {
        EventCenter.AddListener<float>(FunctionType.UpdateGravityBG, UpdateBG);
    }
    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    void UpdateBG(float scale)
    {
        m_Renderer.material.SetColor("_Color", scale >= 0 ? down : up);
        m_Renderer.material.SetFloat("_Dir", scale >= 0 ? 1: -1);
        m_Renderer.material.SetFloat("_Alpha", 0.05f * Mathf.Abs(scale));
        m_Renderer.material.SetFloat("_Speed", Mathf.Abs(scale));
    }

    private void OnDisable()
    {
        EventCenter.RemoveListener<float>(FunctionType.UpdateGravityBG, UpdateBG);
    }
}
