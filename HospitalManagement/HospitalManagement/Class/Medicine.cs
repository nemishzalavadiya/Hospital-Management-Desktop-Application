using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HospitalManagement.Class
{
    class Medicine : iHospital
    {
        private string name;
        private int price;
        private int quantity;
        private DateTime date1;
        private DateTime date2;
        public Medicine()
        { 
        
        }
        public Medicine(string name, int price, int quantity, DateTime date1, DateTime date2)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.date1 = date1;
            this.date2 = date2;
        }
        public object show()
        {
            return this;
        }
        public string insert()
        {
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                Medicine_details m = new Medicine_details();
                m.Name = name;
                m.price = price;
                m.Quantity = quantity;
                m.Mfg_date = date1;
                m.Expiry_date = date2;
                context.Medicine_details.Add(m);
                context.SaveChanges();
                return m.Medicine_Id.ToString();
            }
            catch (Exception e)
            {
                return "All Values are required";
            }
        }
        public IEnumerable<Medicine_details> getAll()
        {
            HospitalManagementEntity context = new HospitalManagementEntity();
            return context.Medicine_details.ToList();
        }
        public IEnumerable<Medicine_details> order()
        {
            HospitalManagementEntity context = new HospitalManagementEntity();
            return context.Medicine_details.Where(m => m.Quantity < 10).ToList();
        }
        public string delete(string patientid)
        {
            try { 
            int id = Convert.ToInt32(patientid);
            HospitalManagementEntity context = new HospitalManagementEntity();
            context.Medicine_details.Remove(context.Medicine_details.Where(x => x.Medicine_Id == id).FirstOrDefault());
            context.SaveChanges();
               
                return "Deletion Successfull";
            }
            catch (Exception e)
            {
                return "Can't Record With This ID";
            }
            
        }
        public string update(string Patient_id, string name, string price, string e_date, string m_date, string quantity)
        {
          
            try { 
            HospitalManagementEntity context = new HospitalManagementEntity();
            Medicine_details u = context.Medicine_details.Find(Convert.ToInt32(Patient_id));
            u.Mfg_date = Convert.ToDateTime( m_date);
            u.Medicine_Id = Convert.ToInt32(Patient_id);
            u.Name = name;
            u.Expiry_date = Convert.ToDateTime(e_date);
            u.price = Convert.ToInt32(price);
            u.Quantity = Convert.ToInt32(quantity);
            context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
                
                return "Updation Successfull";
            }
            catch (Exception e)
            {
               return "Can't Update Record Id's";
            }
            
        }
    }
}
