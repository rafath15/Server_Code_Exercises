using Common.Logging;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects.RetalixExtension;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects.SchemaObjects;
using Retalix.StoreServices.Model.Infrastructure.Audit;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Visitor
{
    public class WfmEmployeeManagementTLogWriter : IWfmEmployeeManagementTLogWriter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WfmEmployeeManagementTLogWriter));

        private readonly R10Extension _r10Extension = new R10Extension();

        private DateTimeOffset _retailTransactionStartTime;
        private DateTimeOffset _retailTransactionEndTime;

        public void Write(IRetailTransactionLogDocumentWriter writer, IRetailTransaction retailTransaction)
        {
            Logger.Debug("WfmEmployeeManagementTLogWriter:Write");

            var artsTransaction = (TransactionDomainSpecific)writer.ObjectContent;
            var retailTransactionLog = artsTransaction.GetMainRetailTransaction();
            _retailTransactionStartTime = retailTransaction.StartTime;
            _retailTransactionEndTime = retailTransaction.EndTime;
           
            retailTransactionLog.Any = new List<XmlElement> { GetTimeDifference() };
            writer.UpdateArtsTransaction(artsTransaction);
        }
        private XmlElement GetTimeDifference()
        {
            var timeDifferenceElement = _r10Extension.CreateXmlElement("TransactionTime");
            TimeSpan timeDifference = _retailTransactionEndTime - _retailTransactionStartTime;
            timeDifferenceElement.InnerText = timeDifference.ToString();
            return timeDifferenceElement;
        }
    }
}

