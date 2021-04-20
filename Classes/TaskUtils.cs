using System;
using System.Collections.Generic;
using System.Linq;


namespace _2LABORAS.Classes
{
    public class TaskUtils
    {
        
        // 
        /// <summary>
        /// to find out which resident paid the least amount 
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static Resident LeastPaid(ResidentList residentlist, ServiceList servicelist)
        {
            residentlist.Beginning();
            Resident temp = residentlist.Get();
            Resident resident = new Resident();
            Resident residents = new Resident();
            double temp1 = Calcs.HowMuchPaid(temp, servicelist);
            double temp2 = 0;
            if (residentlist.getCount() == 1)
            {
                residents = new Resident(residentlist.Get().Name, residentlist.Get().Surname, servicelist.Get().Title, residentlist.Get().Month);
                return residents;
            }

            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                 temp2 = Calcs.HowMuchPaid(residentlist.Get(), servicelist);
                 if(temp2 < temp1)
                 {
                    resident = new Resident(residentlist.Get().Name, residentlist.Get().Surname, servicelist.Get().Title, residentlist.Get().Month);                 
                    temp1 = temp2;
                 }                                    
            }         
            return resident;
        }


        /// <summary>
        /// to find the list of the residents who paid less than average for the services
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <returns></returns>
        public static ResidentList PaidLessThanAvg(ResidentList residentlist, ServiceList servicelist)
        {
            ResidentList residentaverage = new ResidentList();

            residentlist.Beginning();
            double avg = Calcs.AveragePrice(residentlist, servicelist);
            residentlist.Beginning();
            
            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                
                if (Calcs.HowMuchPaid(residentlist.Get(), servicelist) < avg)
                {
                    
                    residentaverage.PutData(residentlist.Get());
                }
            }
            return residentaverage;
        }

        
        /// <summary>
        /// to find out which resident didnt pay for the chosen month
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="servicelist"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static ResidentList DidntPay(ResidentList residentlist, ServiceList servicelist, string month, string serviceid)
        {
            ResidentList notpaidservices = new ResidentList();
            for(residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                if(residentlist.Get().Month != month || residentlist.Get().ServiceId != serviceid )
                {
                    notpaidservices.PutData(residentlist.Get());
                }
            }
            return notpaidservices;
        }

        /// <summary>
        /// method to remove people, who didnt pay for the month and service
        /// </summary>
        /// <param name="residentlist"></param>
        /// <param name="notpaidservices"></param>
        /// <returns></returns>
        public static ResidentList ResidentRemoval(ResidentList residentlist, ResidentList notpaidservices)
        {           
            for (residentlist.Beginning(); residentlist.Exist(); residentlist.Next())
            {
                for (notpaidservices.Beginning(); notpaidservices.Exist(); notpaidservices.Next())
                {
                    if(residentlist.Get() == notpaidservices.Get())
                    {
                        residentlist.Remove(residentlist.GetNode());
                    }                  
                }               
            }
            return residentlist;
        }

    }
}