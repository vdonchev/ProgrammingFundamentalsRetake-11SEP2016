namespace _02.TrophonTheGrumpyCat
{
    using System;
    using System.Linq;
    using System.Numerics;

    public static class TrophonTheGrumpyCat
    {
        public static void Main()
        {
            var prices = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var entryPointIndex = int.Parse(Console.ReadLine());
            var itemType = Console.ReadLine();
            var priceRating = Console.ReadLine();

            var initialItem = prices[entryPointIndex];
            
            BigInteger leftSum = 0;
            for (int i = entryPointIndex - 1; i >= 0; i--)
            {
                leftSum += GetNumberToSum(prices[i], initialItem, itemType, priceRating);
            }

            BigInteger rightSum = 0;
            for (int i = entryPointIndex + 1; i < prices.Length; i++)
            {
                rightSum += GetNumberToSum(prices[i], initialItem, itemType, priceRating);
            }

            Console.WriteLine(leftSum >= rightSum ? $"Left - {leftSum}" : $"Right - {rightSum}");
        }

        private static int GetNumberToSum(int price, int initialPrice, string itemType, string priceRating)
        {
            if (itemType == "cheap")
            {
                if (priceRating == "positive")
                {
                    if (price < initialPrice && price > 0)
                    {
                        return price;
                    }
                }
                else if (priceRating == "negative")
                {
                    if (price < initialPrice && price < 0)
                    {
                        return price;
                    }
                }
                else
                {
                    if (price < initialPrice)
                    {
                        return price;
                    }
                }
            }
            else
            {
                if (priceRating == "positive")
                {
                    if (price >= initialPrice && price > 0)
                    {
                        return price;
                    }
                }
                else if (priceRating == "negative")
                {
                    if (price >= initialPrice && price < 0)
                    {
                        return price;
                    }
                }
                else
                {
                    if (price >= initialPrice)
                    {
                        return price;
                    }
                }
            }

            return 0;
        }
    }
}
