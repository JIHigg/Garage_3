using Garage_3.Models.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Garage_3.Services
{
    public interface IMemberShipService
    {
        List<SelectListItem> CreateMemberDropDown();
        List<SelectListItem> CreateVehicleTypeDropDown(string strSelectedMember);
        List<Membership> GetMembers();
    }
}