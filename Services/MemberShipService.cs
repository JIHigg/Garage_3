using Garage_3.Data;
using Garage_3.Models.Entites;
using Garage_3.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Garage_3.Services
{
    public class MemberShipService : IMemberShipService
    {
        private readonly Garage_3Context m_DbGarage;

        public MemberShipService(Garage_3Context context)
        {
            m_DbGarage = context;
        }

        /// <summary>
        /// Method return all members in database
        /// </summary>
        /// <returns>List of all members in database</returns>
        public List<Membership> GetMembers()
        {
            return m_DbGarage.Membership.AsNoTracking()?.ToList();
        }
        /// <summary>
        /// Method read all members from database
        /// Creates a drop down
        /// </summary>
        /// <returns>Returns a drop down list fo the members</returns>
        public List<SelectListItem> CreateMemberDropDown()
        {
            List<Membership> lsMembers = GetMembers();

            List<SelectListItem> selectListItems = MemberShipHelper.CreateVehicleTypeDropDown(lsMembers);
            return selectListItems;
        }


        /// <summary>
        /// Method read all members from database
        /// Creates a drop down
        /// </summary>
        /// <param name="strSelectedVehicleType">Value for member that shall be selected. Like 1 or 3</param>
        /// <returns>Returns a drop down list of the members. The list has a selected item</returns>
        public List<SelectListItem> CreateVehicleTypeDropDown(string strSelectedMember)
        {
            List<Membership> lsMembers = GetMembers();

            List<SelectListItem> selectListItems = MemberShipHelper.CreateVehicleTypeDropDown(lsMembers, strSelectedMember);
            return selectListItems;
        }
    }
}
