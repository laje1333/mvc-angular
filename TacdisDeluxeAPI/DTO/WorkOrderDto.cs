using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class WorkOrderDto
    {
        public WorkOrderDto()
        {
        }

        public WorkOrderDto(WorkOrderEntity woEnt)
        {
            WoNr = woEnt.WoNr;
            Status = woEnt.Status;

            RegNr = woEnt.RegNr;
            VehDesc = woEnt.VehDesc;
            VehRegDate = woEnt.VehRegDate;
            VehOwner = woEnt.VehOwner;
            VehDriver = woEnt.VehDriver;
            VehPhoneNr = woEnt.VehPhoneNr;
            VehLastVisDate = woEnt.VehLastVisDate;
            VehLastVisMil = woEnt.VehLastVisMil;

            CurrentMilage = woEnt.CurrentMilage;
            PlannedMechID = woEnt.PlannedMechID;
            PlannedMechName = woEnt.PlannedMechName;

            CreatedDate = woEnt.CreatedDate;
            PlannedDate = woEnt.PlannedDate;
            CheckedInDate = woEnt.CheckedInDate;

            MainPayer = woEnt.MainPayer;
            RespBy = woEnt.RespBy;
            TotCost = woEnt.TotCost;
        }

        public int WoNr { get; set; }
        public string Status { get; set; }

        public string RegNr { get; set; }
        public string VehDesc { get; set; }
        public DateTime VehRegDate { get; set; }
        public string VehOwner { get; set; }
        public string VehDriver { get; set; }
        public string VehPhoneNr { get; set; }
        public DateTime VehLastVisDate { get; set; }
        public string VehLastVisMil { get; set; }

        public double CurrentMilage { get; set; }
        public int PlannedMechID { get; set; }
        public string PlannedMechName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CheckedInDate { get; set; }

        public string MainPayer { get; set; }
        public string RespBy { get; set; }
        public double TotCost { get; set; }

        public int[] WOJ_Ids { get; set; }
    }
}