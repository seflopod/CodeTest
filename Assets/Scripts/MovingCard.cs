using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class MovingCard : MonoBehaviour
{
	public Sprite CardBack;
	public Sprite CardFace;

	public void SwapToFace()
	{
		(renderer as SpriteRenderer).sprite = CardFace;
	}

	public void SwapToBack()
	{
		(renderer as SpriteRenderer).sprite = CardBack;
	}

	public void SetMoveCardToFalse()
	{
		SwapToBack();
		GetComponent<Animator>().SetBool("shouldMoveCard", false);
	}
}
