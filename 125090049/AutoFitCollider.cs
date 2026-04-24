using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class AutoFitCollider : MonoBehaviour
{
    [Header("碰撞体厚度（前后方向，Z轴，局部坐标）")]
    public float colliderThickness = 0.2f;

    [Header("栏杆高度（相对于楼梯模型，单位：米）")]
    public float railingHeight = 0.8f; // 栏杆本身的高度，0.7-1.0刚好

    [ContextMenu("自动生成斜楼梯栏杆碰撞体")]
    void AutoFitBoxCollider()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.mesh == null)
        {
            Debug.LogWarning("没有找到 Mesh 或 MeshFilter");
            return;
        }

        // 移除旧碰撞体
        Collider oldCollider = GetComponent<Collider>();
        if (oldCollider != null) DestroyImmediate(oldCollider);

        // 添加新碰撞体
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        Bounds bounds = mf.mesh.bounds;

        // 核心：只在楼梯顶部生成栏杆碰撞体，不包楼梯本体
        collider.center = new Vector3(
            bounds.center.x,
            bounds.max.y - railingHeight / 2, // 碰撞体中心在栏杆中间（楼梯顶部往下一半高度）
            bounds.center.z
        );
        collider.size = new Vector3(
            bounds.size.x, // 长度和楼梯一致
            railingHeight, // 高度只取栏杆部分
            colliderThickness // 厚度固定，只包栏杆
        );

        Debug.Log("斜楼梯栏杆碰撞体生成完成！完美贴合，不挡路！");
    }

    void Start()
    {
        AutoFitBoxCollider();
    }
}