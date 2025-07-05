using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Miss : MonoBehaviour
{
	/// <summary>
	/// 視野角(角度)
	/// </summary>
	[SerializeField]
	private float viewAngle_ = 10.0f;

	/// <summary>
	/// 視野角(ラジアン)
	/// </summary>
	public float viewRadian { get => viewAngle_ * Mathf.Deg2Rad; }

	/// <summary>  
	/// プレイヤー  
	/// </summary>  
	[SerializeField] private Player player_ = null;

    /// <summary>  
    /// ワールド行列   
    /// </summary>  
    private Matrix4x4 worldMatrix_ = Matrix4x4.identity;
	public Matrix4x4 worldMatrix { get => worldMatrix_; }

	/// <summary>  
	/// ターゲットとして設定する  
	/// </summary>  
	/// <param name="enable">true:設定する / false:解除する</param>  
	public void SetTarget(bool enable)
    {
        // マテリアルの色を変更する  
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.materials[0].color = enable ? Color.red : Color.white;
    }

	/// <summary>
	/// 開始処理
	/// </summary>
	public void Start()
    {
		
    }

    /// <summary>  
    /// 更新処理  
    /// </summary>  
    public void Update()
    {
		var normalZ = new Vector3(0, 0, 1);
		var EnemyForward = worldMatrix * normalZ;

		// エネミーの視野角の Cos 値
		var EnemyViewCos = Mathf.Cos(viewRadian);
		Debug.Log(EnemyViewCos);


		//// プレイヤーから敵までの向きを単位ベクトルで取得する
		//var playerToEnemy = (enemies_[i].transform.position - player_.transform.position).normalized;
		//// 内積を取得する
		//var dot = Vector3.Dot(EnemyForward, playerToEnemy);
	}
}
