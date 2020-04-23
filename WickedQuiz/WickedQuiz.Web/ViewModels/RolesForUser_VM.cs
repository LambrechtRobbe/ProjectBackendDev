using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WickedQuiz.Models.Models;

namespace WickedQuiz.Web.ViewModels
{
    public class RolesForUser_VM
    {
        public ApplicationUser User { get; set; }  //De ApplicationUser    
        public string UserId { get; set; }

        public string RoleId { get; set; }
        public IList<string> AssignedRoles { get; set; }
        public IList<string> UnAssignedRoles { get; set; }
    }
}
