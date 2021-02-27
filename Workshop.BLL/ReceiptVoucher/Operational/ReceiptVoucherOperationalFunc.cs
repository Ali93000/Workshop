using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Mapping.Request;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.CashReceipt.Request;

namespace Workshop.BLL.CachReceipt.Operational
{
    public class ReceiptVoucherOperationalFunc : IReceiptVoucherOperationalFunc
    {
        private readonly IReceiptVoucherMappingRequest _cachReceiptMappingRequest;
        private readonly IUnitOfWork _unitOfWork;
        public ReceiptVoucherOperationalFunc(IReceiptVoucherMappingRequest cachReceiptMappingRequest, IUnitOfWork unitOfWork)
        {
            this._cachReceiptMappingRequest = cachReceiptMappingRequest;
            this._unitOfWork = unitOfWork;
        }


        //  Create Opreatainal //
        public int CreateCachReceipt(ReceiptVoucherReq cachReceiptReq)
        {
            // map Cachreceipt Request To Db W_T_Cachreceipt
            var cachReceiptDb = _cachReceiptMappingRequest.mapFromCachReceiptReqToDB(cachReceiptReq);
            //Get Max Code
            int maxCode =_unitOfWork.ReceiptVoucherReopsitry.getMaxCode();
            cachReceiptDb.TrCode=(maxCode + 1);
            cachReceiptDb.TrDate = DateTime.Now.Date;
            // insert To DataBase
            _unitOfWork.ReceiptVoucherReopsitry.Add(cachReceiptDb);
            _unitOfWork.SaveChanges();
            return cachReceiptDb.Id;
        }

        public void DeleteCachReceipt(int id)
        {
            // Delete//
            _unitOfWork.ReceiptVoucherReopsitry.RemoveById(id);
            //Delete from DB
            _unitOfWork.SaveChanges();
        }

        //Edit Opreatainal
        public void UpdateCachReceipt(ReceiptVoucherReq cachReceiptReq)
        {
            // map from Req  to db
            var cachReceiptdb = _cachReceiptMappingRequest.mapFromCachReceiptReqToDB(cachReceiptReq);
            //Update To Data BAse
            _unitOfWork.ReceiptVoucherReopsitry.Update(cachReceiptdb);
            cachReceiptdb.TrDate = DateTime.Now.Date;
            _unitOfWork.SaveChanges();
        }
    }
}
