using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UchebPrackt326.Compnent
{
   public partial class Service
    {
        public  string FulCost
        {
            get
            {         
                    return $"{Cost - Cost * (decimal)Discount} рублей за {DurationInSeconds/60} минут";
            }
           
        }
        public decimal CostDisc
        {
            get
            {
                if(Discount == 0)
                {
                    return Cost;
                }
                else
                {
                    return Cost - Cost * (decimal)Discount;
                }
               
            }

        }
        public Visibility CostVisabiliti
        {
            get
            {
                if(Discount == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public string DiscountPart
        {
            get
            {
                return $"* скидка {Discount*100}%";
            }

        }
        public string CollorDisc
        {
            get
            {
                if(Discount > 0)
                {
                    return $"#FFE7FABF";
                }
                else
                {
                    return "";
                }
                
            }

        }

        public Visibility ADminMod
        {
            get
            {
                if (App.Admin == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
    }
}
