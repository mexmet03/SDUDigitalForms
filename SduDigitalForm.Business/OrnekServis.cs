﻿using SduDigitalForm.Business.Dto;
using SduDigitalForm.Data;
using SduDigitalForm.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SduDigitalForm.Business
{
    public class OrnekServis
    {
        private readonly ApplicationDbContext dbContext;
        private readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-SduDigitalForm-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";

        public OrnekServis()
        {
            dbContext = new ApplicationDbContext(ConnectionString);
        }

        public List<OrnekModel> Test()
        {
            var list = new List<OrnekModel>()
            {
                new OrnekModel(){Ad="test1",Yas=10},
                new OrnekModel(){Ad="test2",Yas=10},
                new OrnekModel(){Ad="test3",Yas=10},
            };
            return list;
        }

        public List<TypeDeviceDto> GetTypeDeviceDto()
        {
            List<TypeDeviceDto> list =dbContext.Tbl_TypeDevices.Select(x=> new TypeDeviceDto(){
                Id=x.Id,
                Name=x.Name
            }).ToList();
            return list;
        }

        public List<OrganizationUnitDto> GetOrganizationUnitDto()
        {
            var backList = dbContext.Tbl_OrganizationUnits.Select(s => new OrganizationUnitDto()
            {
                Id=s.Id,
                DisplayName= s.DisplayName,
                Parent=s.Parent

            }).ToList();

            return backList;

        }


        public List<TypeIssueDto> GetTypeIssueDto()
        {
            var x = dbContext.Tbl_IssueTypes.Select(s => new TypeIssueDto()
            {
                Idissue=s.Idissue,
                IssueType=s.IssueType


            }).ToList();

            return x;
        }


        public List<IssueDto> GetIssues()
        {

            List<IssueDto> IssueList = dbContext.Tbl_Issues.Select(s => new IssueDto()
            {
                Id = s.Id,
                UserId = s.UserId,
                TypeIssue = s.TypeIssue,
                Address = s.Address,
                Delivered = s.Delivered,
                DeliveryDate = s.DeliveryDate,
                Giver = s.Giver,
                Mail = s.Mail,
                Note = s.Note,
                Phone = s.Phone,
                RepairCustomer = s.RepairCustomer,
                RepairDate = s.RepairDate,
                TypeDevice = s.TypeDevice


            }).ToList();

            return IssueList;
        }
        public void PostIssue(IssueDto model) {
            var entity = new Tbl_Issue()
            {
                Id = model.Id,
                RepairDate = model.RepairDate,
                Address = model.Address,
                Delivered = model.Delivered,
                DeliveryDate = model.DeliveryDate,
                Giver = model.Giver,
                Mail = model.Mail,
                Note = model.Note,
                Phone = model.Phone,
                RepairCustomer = model.RepairCustomer,
                TypeDevice = model.TypeDevice,
                TypeIssue = model.TypeIssue,
                UserId = model.UserId

            };

            dbContext.Tbl_Issues.Add(entity);
            dbContext.SaveChanges();

        }

        //public void PostTypeDevice(TypeDeviceDto model)
        //{

        //    var entity = new Tbl_TypeDevice() { Name = model.Name };
        //    dbContext.Tbl_TypeDevices.Add(entity);
        //    dbContext.SaveChanges();


        //}
    }
}
