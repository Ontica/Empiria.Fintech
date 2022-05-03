/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Data Access Layer                     *
*  Assembly : Empiria.Insurth.dll                          Pattern   : Data Service                          *
*  Type     : ContractData                                 License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Data acccess layer for insurer contracts.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Data;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Data {
  /// <summary>Provides database read and write methods for contract.</summary>

  #region Internal methods

  static internal class ContractData {
  
    internal static void Delete(int id) {
      var sql = $"UPDATE FTHContracts SET ContractStatus = 'X' WHERE ContractId = {id}";

      var dataOperation = DataOperation.Parse(sql);

      DataWriter.Execute(dataOperation);
    }


    internal static Contract GetContract(string uid) {
      var sql = "SELECT * FROM FTHContracts WHERE ContractTrackUID  ='" +  uid + "'";

      var dataOperation = DataOperation.Parse(sql);

      return DataReader.GetPlainObject<Contract>(dataOperation);
    }

   
    internal static Contract GetContract(int id) {
      var sql = $"SELECT * FROM FTHContracts WHERE ContractId  = {id}";

      var dataOperation = DataOperation.Parse(sql);

      return DataReader.GetPlainObject<Contract>(dataOperation);
    }


    internal static FixedList<Contract> GetContracts() {
      var sql = "SELECT * FROM FTHContracts WHERE ContractStatus <> 'X'";

      var dataOperation = DataOperation.Parse(sql);

      return DataReader.GetPlainObjectFixedList<Contract>(dataOperation);
    }


    internal static FixedList<Contract> GetContracts(string keywords) {
      var sql = $"SELECT * FROM FTHContracts WHERE ContractKeywords like '%{keywords}%' and ContractStatus <> 'X'";

      var dataOperation = DataOperation.Parse(sql);

      return DataReader.GetPlainObjectFixedList<Contract>(dataOperation);
    }


    static internal int GetContractId() {
      return GetNextId("ContractId");
    }


    static internal int GetContractTrackId() {
      return GetNextId("ContractTrackId");
    }


    static private int GetNextId(string fieldId) {
      var sql = "SELECT max(" + fieldId + ") from  FTHContracts" ;

      var op = DataOperation.Parse(sql);

      var id = Empiria.Data.DataReader.GetScalar<int>(op) + 1;
      return id;
    }


    internal static void Write(Contract o) {
      var op = DataOperation.Parse("writeFTHContracts", o.ContractTrackId, o.ContractTrackUID,
                                  o.ContractId, o.ContractType.Id, o.ContractNo, o.ExtData.ToString(),
                                  o.ContractKeywords, o.ModifiedById, o.ContractStatus, o.StartDate,
                                 o.EndDate, o.ContractTrackDIF, o.Agency.Id, o.Agent.Id);

      DataWriter.Execute(op);
    }
       

    #endregion Internal methods

  } // class ContractData

} // namespace Empiria.Insurtech.Policies.Data