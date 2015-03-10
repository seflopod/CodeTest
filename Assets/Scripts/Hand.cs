using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class Hand : MonoBehaviour
{
	private Stack<Card> _hand = new Stack<Card>(52);

	public void AddCard(Card c)
	{
		if(c != null)
		{
			_hand.Push(c);
			(renderer as SpriteRenderer).sprite = c.FaceSprite;
		}
	}

	public void Reset()
	{
		_hand.Clear();
		(renderer as SpriteRenderer).sprite = null;
	}

	public Card RemoveCard()
	{
		if(_hand.Count >= 1)
		{
			Card ret = _hand.Pop();
			(renderer as SpriteRenderer).sprite = _hand.Peek().FaceSprite;
			return ret;
		}
		return null;
	}
}
