using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HospitalManagement.Class
{
    class Patient : iHospital
    {

        private string disease;
        private string description;
        private DateTime date1;
        public Patient(string disease, string description, DateTime date1)
        {
            this.disease = disease;
            this.description = description;
            this.date1 = date1;
        }
        public Patient()
        {

        }
        public string insert()
        {
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                Patient_record p = new Patient_record();
                p.Description = description;
                if(disease=="")
                    return "Disease Name Must Be Required";
                p.disease = disease;
                p.Discharge_date = date1;
                int id = Convert.ToInt32(UserAuthentication.Id);
                User sUser = context.Users.Find(id);
                if (sUser == null)
                    return "Invalide Doctor Id ";
                p.Doctor_id = UserAuthentication.Id;
                p.Appoinment_id = 1007;
                context.Patient_record.Add(p);
                context.SaveChanges();
                return "Patient Recored Inserted Successfully";
            }
            catch (Exception e)
            {
                return "Disease Name Must Be Required";
            }
        }
        public IEnumerable<Patient_record> getAll()
        {
            HospitalManagementEntity context = new HospitalManagementEntity();
            return context.Patient_record.ToList();
        }
        public string delete(string patientid)
        {
            string s = "";
            try
            {
                int id = Convert.ToInt32(patientid);
                HospitalManagementEntity context = new HospitalManagementEntity();
                context.Patient_record.Remove(context.Patient_record.Where(x => x.Patient_Id == id).FirstOrDefault());
                context.SaveChanges();
                s ="Deletion Success";
            }
            catch (Exception e) {
                return "Can't Remove Record, Id's Invalide";
            }
            
            return s;
        }
        public object show()
        {
            return this;
        }
        public string update(string Patient_id, string disease, string doctor_id, string a, string b, string c)
        {
            string s = "";
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                Patient_record u = context.Patient_record.Find(Convert.ToInt32(Patient_id));
                u.disease = disease;
                int id = Convert.ToInt32(doctor_id);
                User sUser = context.Users.Find(id);
                if (sUser == null)
                    return "Invalide Doctor Id ";
                u.Doctor_id = Convert.ToInt32(doctor_id);
                u.Description = a;
                u.Appoinment_id = Convert.ToInt32(b);
                //u.Discharge_date = c;
                context.Entry(u).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                s ="Update Successfull";
                return s;
            }
            catch (Exception e) {
                return "Id's Can't be Updated";
            }
            
            
            
        }
    }
}
