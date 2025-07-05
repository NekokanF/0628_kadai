using UnityEngine;

public class Enemy2 : MonoBehaviour
{
	public Transform player; // プレイヤーの位置
	public float Viewangle = 20f; // 視野角40度
	public float rotationSpeed = 10f; // 1フレームの最大回転角度
	public float moveSpeed = 0.2f; // 1フレームの移動距離

	void Update()
	{
		// 敵からプレイヤーへ向かうベクトル
		// player.position = プレイヤーの位置
		// transform.position = 敵の位置
		// player.position - transform.position = 敵からプレイヤーへの方向ベクトル
		Vector3 directionToPlayer = player.position - transform.position;

		directionToPlayer.y = 0f; // Y軸は無視して水平面での方向に限定

		// プレイヤーとの角度を求める(Vector3.Angleは2つのベクトル間の角度を求める関数)
		// angleToPlayer = プレイヤーが敵の正面から何度ずれているのか
		// transform.forward = 敵が今正面を向いてる方向
		// directionToPlayer = 敵からプレイヤーへのベクトル
		float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

		// プレイヤーが視野内にいる場合、回転して移動する
		if (angleToPlayer <= Viewangle) 
		{
			// 目標の方向を向くための回転を計算
			// Quaternion.LookRotation = 指定した方向を向く回転(Quarternion)を作る関数(今回の場合はプレイヤーの方向)
			Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

			// 指定した最大回転角度(rotationSpeed)で現在のRotationから目標への回転を行う
			// transform.rotation = 敵の現在のRotation
			// targetRotation = 上で作ったQuaternion
			// Quaternion.RotateTowards = 現在のRotationから目標の回転をrotationSpeed(最大回転角度)分だけ回転させる
			transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed); 

			//移動処理
			transform.position += transform.forward * moveSpeed;
		}
	}
}
