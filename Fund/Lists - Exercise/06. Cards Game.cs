using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game
{
	class CardsGame
	{
		static sbyte CompareHand(int first, int second)
		{
			if (first > second)
			{
				return 1;
			}
			else if (first < second)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}//byte CompareHand(firstHand[0], secondHand[0])

		static void ListManipulator(List<int> first, List<int> second)
		{
			first.Add(first[0]);
			first.Add(second[0]);
			first.RemoveAt(0);
			second.RemoveAt(0);
		}

		static void Main(string[] args)
		{
			List<int> firstHand = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
			List<int> secondHand = Console.ReadLine()
				.Split(' ', StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			bool isFirstWin = false;
			bool isSecondWin = false;

			while ((!isFirstWin) && (!isSecondWin))
			{
				sbyte compare = CompareHand(firstHand[0], secondHand[0]);

				if (compare > 0)
				{
					ListManipulator(firstHand, secondHand);
				}
				else if (compare < 0)
				{
					ListManipulator(secondHand, firstHand);
				}
				else
				{
					firstHand.RemoveAt(0);
					secondHand.RemoveAt(0);
				}

				if (firstHand.Count == 0)
				{
					isSecondWin = true;
				}

				if (secondHand.Count == 0)
				{
					isFirstWin = true;
				}
			}

			string s = string.Empty;
			if (isFirstWin)
			{
				s = $"First player wins! Sum: {firstHand.Sum()}";
			}
			else
			{
				s = $"Second player wins! Sum: {secondHand.Sum()}";
			}

			Console.WriteLine(s);
		}
	}
}
//You will be given two hands of cards, which will be integer numbers. Assume that you have two players. You have to find out the winning deck and respectively the winner.
//You start from the beginning of both hands. Compare the cards from the first deck to the cards from the second deck. The player, who has the bigger card, takes both cards and puts them at the back of his hand - the second player’s card is last, and the first person’s card (the winning one) is before it (second to last) and the player with the smaller card must remove the card from his deck. If both players’ cards have the same values - no one wins, and the two cards must be removed from the decks. The game is over, when one of the decks is left without any cards. You have to print the winner on the console and the sum of the left cards: "{First/Second} player wins! Sum: {sum}".
//	Ще ви бъдат дадени две ръце от карти, които ще бъдат цели числа.
//	Да предположим, че имате двама играчи.
//	Трябва да разберете печелившата и съответно победителя.
//Започваш от началото на двете ръце. Сравнете картите от първото тесте до картите от второто тесте.
//Играчът, който има по-голяма карта, взема двете карти и ги поставя на гърба на ръката си -
//последната е последната карта на втория играч, а картата на първия човек (печелившата) е преди нея (на второ място)
//и играчът с по-малка карта трябва да извади картата от тестето.
//Ако картите на двамата играчи имат еднакви стойности - никой не печели и двете карти трябва да бъдат премахнати от тестетата.
//Играта свършва, когато един от тестетата е оставен без никакви карти.
//Трябва да отпечатате победителя на конзолата и сумата от лявата карти: "{Победители първи/Втори} играч! Сума: {sum}".
