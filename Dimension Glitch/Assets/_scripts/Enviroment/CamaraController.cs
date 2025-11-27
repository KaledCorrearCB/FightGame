using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();

    public float smoothSpeed = 0.12f;
    public Vector3 offset;

    void LateUpdate()
    {
        // Evita errores antes de que los targets se asignen
        if (targets == null || targets.Count == 0)
            return;

        // Filtra targets nulos
        CleanupTargets();

        if (targets.Count == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 desiredPosition = centerPoint + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    Vector3 GetCenterPoint()
    {
        if (targets == null || targets.Count == 0)
            return transform.position;

        if (targets.Count == 1)
            return targets[0].position;

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);

        foreach (Transform t in targets)
        {
            if (t != null && t.gameObject.activeInHierarchy)
                bounds.Encapsulate(t.position);
        }

        return bounds.center;
    }

    // Agregar players dinámicamente
    public void AddTarget(Transform t)
    {
        if (t != null && !targets.Contains(t))
            targets.Add(t);
    }

    // Limpia targets destruidos o nulos
    void CleanupTargets()
    {
        targets.RemoveAll(t => t == null);
    }
}
