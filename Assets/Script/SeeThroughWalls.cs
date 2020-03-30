using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SeeThroughWalls : MonoBehaviour
{
    public GameObject Wall = null;
    public float seeWall = 3f;
    void OnTriggerEnter(Collider collider)
        {
            if(IsCharacter(collider))
            {
                SetMaterialTransparent();
                iTween.FadeTo(Wall, 0, 1);
            }
        }
    private bool IsCharacter(Collider collider)
    {
        Ray castWall = new Ray(transform.position,Vector3.back);
        RaycastHit hitWall;
        if (Physics.Raycast(castWall, out hitWall, seeWall))
        {
            if (hitWall.collider.tag == "InvisibelWall")
            {
                return true;
            }
        }
        return false;
    }
    private void SetMaterialTransparent()
    {
        foreach (Material m in Wall.GetComponent<Renderer>().materials)
        {
            m.SetFloat("_Mode", 2);
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            m.SetInt("_ZWrite", 0);
            m.DisableKeyword("_ALPHATEST_ON");
            m.EnableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = 3000;
        }
    }
    private void SetMaterialOpaque()
    {
        foreach (Material m in Wall.GetComponent<Renderer>().materials)
        {
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            m.SetInt("_ZWrite", 1);
            m.DisableKeyword("_ALPHATEST_ON");
            m.DisableKeyword("_ALPHABLEND_ON");
            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            m.renderQueue = -1;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (IsCharacter(collider))
        {
            // Set material to opaque
            iTween.FadeTo(Wall, 1, 1);
            Invoke("SetMaterialOpaque", 1.0f);
        }
    }
}
