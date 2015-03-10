using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private Deck _deck;
	private Hand _hand;
	private MovingCard _mover;
	private bool _isDrawingCard = false;
	private int _moveCardHash;

	private void Start()
	{
		_deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();
		_hand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<Hand>();
		_mover = GameObject.FindGameObjectWithTag("MovingCard").GetComponent<MovingCard>();
		_moveCardHash = Animator.StringToHash("shouldMoveCard");

		_deck.Shuffle();
	}

	public void ResetAll()
	{
		_deck.Reset();
		_hand.Reset();
	}

	public void DrawCard()
	{
		if(_isDrawingCard)
		{
			return;
		}

		Card newCard = _deck.DealCard();
		if(newCard != null)
		{
			StartCoroutine(moveCard(newCard));
		}
	}

	private IEnumerator moveCard(Card newCard)
	{
		_mover.CardFace = newCard.FaceSprite;
		Animator moveAnimator = _mover.GetComponent<Animator>();
		moveAnimator.SetBool(_moveCardHash, true);
		_isDrawingCard = true; //cannot draw again until this is done

		//wait until the animation is done to actually set and display the card.
		while(moveAnimator.GetBool(_moveCardHash))
		{
			yield return new WaitForEndOfFrame();
		}

		_isDrawingCard = false;
		_hand.AddCard(newCard);
	}

	public void ShuffleDeck()
	{
		_deck.Shuffle();
	}
}
