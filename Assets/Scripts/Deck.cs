using UnityEngine;
using System.Collections.Generic;

//assumes a standard poker deck for playing
[RequireComponent(typeof(SpriteRenderer))]
public class Deck : MonoBehaviour
{
	[SerializeField]
	private Card[] _cards = new Card[52];

	private int _cardIdx = 0;
	private Sprite _baseSprite;

	private void Start()
	{
		_baseSprite = (renderer as SpriteRenderer).sprite;
	}

	public void Shuffle()
	{
		for(int i=_cardIdx;i<_cards.Length;++i)
		{
			int rndIdx = Random.Range(i,_cards.Length);
			Card tmp = _cards[rndIdx];
			_cards[rndIdx] = _cards[i];
			_cards[i] = tmp;
		}
	}

	public Card DealCard()
	{
		if(_cardIdx < _cards.Length)
		{
			if(_cardIdx == _cards.Length - 1)
			{
				(renderer as SpriteRenderer).sprite = null;
			}

			return _cards[_cardIdx++];
		}
		return null;
	}

	public void Reset()
	{
		_cardIdx = 0;
		System.Array.Sort(_cards, (c1, c2) => {
			int ret = c1.Suit.CompareTo(c2.Suit);
			if(ret == 0)
			{
				ret = c1.FaceValue.CompareTo(c2.FaceValue);
			}
			return ret;
		});
		(renderer as SpriteRenderer).sprite = _baseSprite;
	}
}
