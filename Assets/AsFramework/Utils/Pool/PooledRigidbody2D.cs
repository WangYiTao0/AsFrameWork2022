using UnityEngine;

namespace RobotGame.Utils
{
	/// <summary>This component will automatically reset a Rigidbody2D when it gets spawned/despawned.</summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public class PooledRigidbody2D : MonoBehaviour, IPoolable
	{
		public void OnSpawn()
		{
		}

		public void OnDespawn()
		{
			var rigidbody2D = GetComponent<Rigidbody2D>();

			rigidbody2D.velocity        = Vector2.zero;
			rigidbody2D.angularVelocity = 0.0f;
		}
	}
}