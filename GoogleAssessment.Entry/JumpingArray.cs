using System.Collections.Generic;
using System.Linq;

namespace GoogleAssessment.Entry
{
    public class JumpingArray
    {
        private readonly IEnumerable<int> array;

        public JumpingArray(int[] array)
        {
            this.array = array.ToList();
        }

        public int GetJumpsUntilEnd()
        {
            var possibilities = 1;

            for (var currentIndex = 0; currentIndex < array.Count() - 1; currentIndex++)
            {
                var currentJump = 1;
                var canJump = true;

                var jump = new Jump(array.ElementAt(currentIndex), currentIndex);
                while (canJump)
                {
                    var jumpResult = JumpFrom(jump, currentJump);

                    if (jumpResult.Index == jump.Index)
                    {
                        canJump = false;
                    }

                    if (jumpResult.Index == array.Count() - 1)
                    {
                        canJump = false;
                        possibilities++;
                    }

                    jump = jumpResult;
                    currentJump++;
                }
            }

            return possibilities;

        }

        private Jump JumpFrom(Jump currentValue, int jumpCount)
        {
            if (jumpCount % 2 == 0)
            {
                return EvenJumpFrom(currentValue);
            }

            return OddJumpFrom(currentValue);
        }

        private Jump OddJumpFrom(Jump currentValue)
        {
            var possibleJumps = array.Select((x, i) => new Jump(x, i))
                .Where(x => x.Index > currentValue.Index)
                .Where(x => x.Value > currentValue.Value);

            if (!possibleJumps.Any())
            {
                return currentValue;
            }

            var minimumDifference = possibleJumps.Min(x => x.Value - currentValue.Value);
            return possibleJumps.First(j => j.Value - currentValue.Value == minimumDifference);
        }

        private Jump EvenJumpFrom(Jump currentValue)
        {
            var possibleJumps = array.Select((x, i) => new Jump(x, i))
                .Where(x => x.Index > currentValue.Index)
                .Where(x => currentValue.Value > x.Value);

            if (!possibleJumps.Any())
            {
                return currentValue;
            }

            var minimumDifference = possibleJumps.Min(x => currentValue.Value - x.Value);
            return possibleJumps.First(j => currentValue.Value - j.Value == minimumDifference);
        }
    }

    public class Jump
    {
        public Jump(int value, int index)
        {
            Value = value;
            Index = index;
        }

        public int Value { get; }

        public int Index { get; }
    }
}