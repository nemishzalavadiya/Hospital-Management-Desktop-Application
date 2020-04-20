using HospitalManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HospitalManagement.Class
{
    public class UserAuthentication
    {
        private string username;
        private string designation;
        private string password;
        public static int Id;
        public UserAuthentication(string username, string password, string designation = null)
        {
            this.username = username;
            this.password = password;
            if (designation != null)
            {
                this.designation = designation;
            }
        }
        public UserAuthentication() { 
        
        }
        public string delete(string username, string password) {
           
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                context.Users.Remove(context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault());

                context.SaveChanges();
                
                return "Deletion Successfull";
            }
            catch (Exception eq) {
                return "User Still Have Clients Frist Remove Clients";
            }
        }

        public string update(string id,string username,string password) {
       
            try
            {
                HospitalManagementEntity context = new HospitalManagementEntity();
                User u = context.Users.Find(Convert.ToInt32(id));
                u.Username = username;
                u.Password = password;
                context.Entry(u).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
               
                return "Updation Successfull";
            }
            catch (Exception e)
            {
                return "Can't Update Id's";
            }
        }
        public IEnumerable<User> getAll(string desig) {
            HospitalManagementEntity context = new HospitalManagementEntity();
            return context.Users.Where(x=>x.Designation==desig).ToList();

        }

        
        
        public string LoginAuth() {
            HospitalManagementEntity context = new HospitalManagementEntity();
            
            User s = context.Users.FirstOrDefault(x=>x.Username==this.username && x.Password==this.password);
            
            if (s != null) {
                Id = s.Id;
                return s.Designation;
            }

            return "non";
        }
        public string Register() {
            try
            {
                
                HospitalManagementEntity context = new HospitalManagementEntity();
                User s = context.Users.FirstOrDefault(x => x.Username == this.username && x.Password == this.password);
                if (s != null) {
                    return "Username and Password Already Exist";
                }
                User user = new User();
                user.Password = this.password;
                user.Username = this.username;
                user.Designation = this.designation;
                context.Users.Add(user);
                context.SaveChanges();
                return "Registration Successfull for Username : "+username;
            }
            catch (Exception e) {
                return "Invalide Input";
            }
        }
        

    }
}
