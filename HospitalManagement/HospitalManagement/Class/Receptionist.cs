using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HospitalManagement.Class
{
    class Receptionist : iHospital
    {
        private string name;
        private string mobile;
        private string address;
        private DateTime date1;
        private DateTime date2;
        private string doc_id;
        public Receptionist(DateTime date1, DateTime date2,string name, string mobile, string address,string id)
        {
            this.name = name;
            this.mobile = mobile;
            this.address = address;
            this.date1 = date1;
            this.date2 = date2;
            this.doc_id = id;
        }
        public Receptionist()
        {

        }
        public string insert()
        {
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                Patient_Appoinment appo = new Patient_Appoinment();
                appo.Address = address;
                appo.Appoinment_date = date2;
                if (doc_id == "")
                    return "Doctor id must be Required";
                int id = Convert.ToInt32(doc_id);
                User s = context.Users.Find(id);
                if(s==null)
                    return "Doctor Id Invalide";
                appo.Doctor_id = Convert.ToInt32(doc_id);
                appo.Start_date = date1;
                appo.Mobile_no = mobile;
                appo.Patient_name = name;
                context.Patient_Appoinment.Add(appo);
                context.SaveChanges();
                return "Appointment Recorded";
            }
            catch (Exception e)
            {
                return "Doctor Id Must Be Integer";
            }
        }
        public IEnumerable<Patient_Appoinment> getAll()
        {
            HospitalManagementEntity context = new HospitalManagementEntity();
            return context.Patient_Appoinment.ToList();
        }
        public object show()
        {
            return this;
        }
        public string delete(string appoinmentid)
        {
            try { 
            int id = Convert.ToInt32(appoinmentid);
            HospitalManagementEntity context = new HospitalManagementEntity();
            context.Patient_Appoinment.Remove(context.Patient_Appoinment.Where(x => x.Appoinment_Id == id).FirstOrDefault());
            context.SaveChanges();
               
                return "Deletion Successfull";
            }
            catch (Exception e)
            {
                return "Can't Remove With This Id";
            }
            
        }
        public string update(string Apppoinment_id, string patient_name, string a, string b, string c, string doc_id)
        {
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                Patient_Appoinment u = context.Patient_Appoinment.Find(Convert.ToInt32(Apppoinment_id));
                u.Patient_name = patient_name;
                u.Appoinment_date = Convert.ToDateTime(a);
                int id = Convert.ToInt32(doc_id);
                User s = context.Users.Find(id);
                if (s == null)
                    return "Invalide Doctor Id ";
                u.Doctor_id = Convert.ToInt32(doc_id);
                u.Address = b;
                u.Mobile_no = c;
                context.Entry(u).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                
                return "Updation Successfull";
            }
            catch (Exception e)
            {
                return "Can't Update Id's";
            }

        }
        public string update(string Apppoinment_id, string startdate, string patient_name, string a, string b, string c, string doc_id)
        {
            try { 
            HospitalManagementEntity context = new HospitalManagementEntity();
            Patient_Appoinment u = context.Patient_Appoinment.Find(Convert.ToInt32(Apppoinment_id));
            u.Start_date = Convert.ToDateTime(startdate);
            u.Patient_name = patient_name;
            u.Appoinment_date = Convert.ToDateTime(a);
            int id = Convert.ToInt32(doc_id);
            User s = context.Users.Find(id);
            if (s == null)
                return "Invalide Doctor Id ";
                u.Doctor_id = Convert.ToInt32(doc_id);
            u.Address = b;
            u.Mobile_no = c;
            context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
                
                return "Updation Successfull";
            }
            catch (Exception e)
            {
                return "Can't Update Id's";
            }
            
        }
    }
}
