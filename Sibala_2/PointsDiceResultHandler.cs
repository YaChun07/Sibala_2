using System.Linq;

namespace Sibala_2
{
    internal class PointsDiceResultHandler : IDiceResultHandler
    {
        public void Handle(Dice dice)
        {
            dice.Type = DiceType.Points;
            var diceGrouping = dice._dices.GroupBy(x => x);
            if (diceGrouping.Count() == 2)
            {
                var maxPoint = dice._dices.Max();
                dice.Points = maxPoint * 2;
                dice.MaxPoint = maxPoint;
            }
            else
            {
                var duplicatePoint = diceGrouping.First(x => x.Count() == 2).Key;
                var dicesOfPoints = dice._dices.Where(x => x != duplicatePoint);
                dice.Points = dicesOfPoints.Sum();
                dice.MaxPoint = dicesOfPoints.Max();
            }
        }
    }
}