using System;
using System.IO;
using System.Linq;
using _2LABORAS.Classes;

namespace _2LABORAS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const string data1 = "~/App_Data/U16a.txt";
        private const string data2 = "~/App_Data/U16b.txt";


        protected void Page_Load(object sender, EventArgs e)
        {
            File.Delete(Server.MapPath(@"App_data/Rezultatai.txt"));
            InOutUtils.ServiceTable(Table1);
            InOutUtils.ResidentTable(Table2);         
            ServiceList services = InOutUtils.ReadServices(Server.MapPath(data1));
            ResidentList residents = InOutUtils.ReadResidents(Server.MapPath(data2));
            InOutUtils.InsertServices(Table1, services);
            InOutUtils.InsertResidents(Table2, residents);
            InOutUtils.PrintServices(services);
            InOutUtils.PrintResidents(residents);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            hidden.Style["visibility"] = "visible";
            ServiceList services = InOutUtils.ReadServices(Server.MapPath(data1));
            ResidentList residents = InOutUtils.ReadResidents(Server.MapPath(data2));
            
            Resident cheapestmonth = TaskUtils.LeastPaid(residents, services);           
            double amount = Calcs.TotalAmountPaid(residents, services);
            Label2.Text = "Pigiausias mėnesis - " + cheapestmonth.Month;
            Label4.Text = "Pigiausi mokesčiai buvo - " + cheapestmonth.Service;
            Label3.Text = "Visų gyventojų išleisti pinigai - " + amount.ToString();
            Label1.Text = "Gyventojai, kurie sumokėjo mažesnę sumą mokesčių už vidurkį";
                   
            ResidentList residentsaverage = TaskUtils.PaidLessThanAvg(residents, services);
          
            InOutUtils.TableForLessAvg(Table3);
            InOutUtils.TableInsertLessAvg(Table3, residentsaverage);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            hidden.Style["visibility"] = "visible";
            ServiceList services = InOutUtils.ReadServices(Server.MapPath(data1));
            ResidentList residents = InOutUtils.ReadResidents(Server.MapPath(data2));
            Label5.Text = "Pašalintas sąrašas";
            string month = TextBox1.Text;
            string serviceid = TextBox2.Text;          
            ResidentList residentsaverage = TaskUtils.PaidLessThanAvg(residents, services);
            ResidentList notpaidservices = TaskUtils.DidntPay(residentsaverage, services, month, serviceid);
            InOutUtils.TableForLessAvg(Table3);
            ResidentList removedlist = TaskUtils.ResidentRemoval(residentsaverage, notpaidservices);
            InOutUtils.TableInsertLessAvg(Table3, removedlist);
            

        }
    }
}