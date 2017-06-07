using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Model
{
    public class Rating
    {
        //эффективность работы в команде
        public static double EffectivenessOfTeamWork { get; set; }

        //эффективность выполнения задания в срок
        public static double EffectivenessOfImplementation { get; set; }

        //эффективность качества выполнения
        public static double EffectivenessOfQuality { get; set; }

        //эффективность отработанного времени
        public static double EfficiencyOfTimeWorked { get; set; }

        //соответствие квалификации занимаемой должности
        public static double EffectivenessOfQualifications { get; set; }

        //расчет рейтинга
        public static double GetRating(double effctivImplementation,double effectivQualification,
                                       double effectivQuality,double effectivTeamWork,
                                       double effectivTimeWorked)
        {
            EffectivenessOfTeamWork = effectivTeamWork;
            EffectivenessOfImplementation = effctivImplementation;
            EffectivenessOfQuality = effectivQuality;
            EfficiencyOfTimeWorked = effectivTimeWorked;
            EffectivenessOfQualifications = effectivQualification;

            return (EffectivenessOfImplementation + EffectivenessOfQualifications +
                    EffectivenessOfQuality + EffectivenessOfTeamWork +
                    EfficiencyOfTimeWorked) / 5;
        }
    }
}
