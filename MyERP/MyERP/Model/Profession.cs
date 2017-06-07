using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyERP.Model
{
    public class Profession:Person
    {
        public Departament Department { get; set; }
        public Position Position { get; set; }
        public double Salory { get; set; }
        public List<Order> ListOrder { get; set; }
        public double Rating { get; set; }
        public string GetPosition(Position e)
        {
            string str = string.Empty;
            switch(e)
            {
                case Position.HeadOfDepartment:
                    str = "Начальник отдела";
                    break;
                case Position.DeputyDirector:
                    str = "Зам. директора";
                    break;
                case Position.Director:
                    str = "Директор";
                    break;
                case Position.Disigner:
                    str = "Дизайнер";
                    break;
                case Position.Manager:
                    str = "Менеджер";
                    break;
                case Position.Working:
                    str = "Рабочий";
                    break;
                default:
                    break;
            }
            return str;
        }
        public string GetDepartment(Departament d)
        {
            string str = string.Empty;
            switch (d)
            {
                case Departament.Disigners:
                    str = "Дизайнерский отдел";
                    break;
                case Departament.Managers:
                    str = "Отдел маркетинга";
                    break;
                case Departament.Production:
                    str = "Производственный отдел";
                    break;
                case Departament.Shipping:
                    str = "Отдел отгрузки";
                    break;
                default:
                    break;
            }
            return str;
        }

    }
    public enum Departament
    {
        Production,
        Managers,
        Disigners,
        Shipping
    }

    public enum Position
    {
        Director,
        DeputyDirector,
        Manager,
        Disigner,
        HeadOfDepartment,
        Working
    }

}
