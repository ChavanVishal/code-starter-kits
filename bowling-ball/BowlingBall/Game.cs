using BowlingBall.Model;
using System.Collections.Generic;
using System.Linq;

namespace rollingBall
{
    public class Game
    {
        public int score;

        /// <summary>
        /// Execute Bolling game
        /// </summary>
        /// <param name="frameList"></param>
        public void Execute(List<Frame> frameList)
        {
            score = 0;
            for (int frameIndex = 0; frameIndex < frameList.Count(); frameIndex++)
            {

                if (frameIndex < 9)
                {
                    //strike
                    if (IsStrike(frameList, frameIndex))
                    {
                        StrikeCalculation(frameList, frameIndex);
                    }
                    //spare
                    else if (IsSpare(frameList, frameIndex))
                    {
                        SpareCalulation(frameList, frameIndex);
                    }
                    //normal
                    else if (IsNormal(frameList, frameIndex))
                    {
                        score = score + frameList[frameIndex].Roll1 + frameList[frameIndex].Roll2;
                    }
                }
                else
                {
                    LastFrame(frameList, frameIndex);
                }

                frameList[frameIndex].Score = score;
            }
        }

        /// <summary>
        /// Last Frame
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frameIndex"></param>
        private void LastFrame(List<Frame> frameList, int frameIndex)
        {
            if (frameList[frameIndex].Roll1 == 10)
            {
                score = score + frameList[frameIndex].Roll1 + frameList[frameIndex].Roll2 + frameList[frameIndex].Extraroll + 10;
            }
            else
            {
                score = score + frameList[frameIndex].Roll1 + frameList[frameIndex].Roll2 + frameList[frameIndex].Extraroll;
            }
        }

        /// <summary>
        /// Check Is Normal
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private static bool IsNormal(List<Frame> frameList, int frameIndex)
        {
            return (frameList[frameIndex].Roll1 + frameList[frameIndex].Roll2) < 10;
        }

        /// <summary>
        /// Check Is Spare
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private static bool IsSpare(List<Frame> frameList, int frameIndex)
        {
            return (frameList[frameIndex].Roll1 + frameList[frameIndex].Roll2) == 10;
        }

        /// <summary>
        /// Check Is Strike
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frameIndex"></param>
        /// <returns></returns>
        private static bool IsStrike(List<Frame> frameList, int frameIndex)
        {
            return frameList[frameIndex].Roll1 == 10;
        }

        /// <summary>
        /// Spare Calculation
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frame"></param>
        private void SpareCalulation(List<Frame> frameList, int frame)
        {
            score = score + frameList[frame].Roll1 + frameList[frame].Roll2 + frameList[frame + 1].Roll1;
        }

        /// <summary>
        /// Strike Calculation
        /// </summary>
        /// <param name="frameList"></param>
        /// <param name="frameIndex"></param>
        private void StrikeCalculation(List<Frame> frameList, int frameIndex)
        {
            int firstRoll;
            int secondRoll;

            if (frameList[frameIndex + 1].Roll1 == 10)
            {
                firstRoll = 10;
            }
            else
            {
                firstRoll = frameList[frameIndex + 1].Roll1;
            }

            if (frameIndex + 2 < frameList.Count() && frameList[frameIndex + 2].Roll1 == 10)
            {
                secondRoll = 10;
            }
            else
            {
                if (frameIndex + 2 < frameList.Count())
                {
                    secondRoll = frameList[frameIndex + 2].Roll1;
                }
                else
                {
                    secondRoll = 10;
                }
            }
            if (frameList[frameIndex + 1].Roll1 < 10)
            {
                firstRoll = frameList[frameIndex + 1].Roll1;
            }
            if (frameIndex + 2 < frameList.Count() && frameList[frameIndex + 2].Roll2 > 0 && frameList[frameIndex + 2].Roll2 < 10)
            {
                secondRoll = frameList[frameIndex + 1].Roll2;
            }
            else
            {
                if (secondRoll == 0)
                {
                    secondRoll = 10;
                }
            }
            score = score + frameList[frameIndex].Roll1 + firstRoll + secondRoll;
        }
        /// <summary>
        /// Get Score
        /// </summary>
        /// <returns></returns>
        public int Score()
        {
            return score;
        }
    }
}
