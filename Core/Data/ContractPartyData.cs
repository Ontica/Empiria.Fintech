/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Data Access Layer                     *
*  Assembly : Empiria.Insurth.dll                          Pattern   : Data Service                          *
*  Type     : ContractData                                 License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Data acccess layer for contract participant.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Data;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Data {

  /// <summary>Data acccess layer for contract participant. </summary>
  static internal class ContractPartyData {

    #region Internal methods
        
    internal static int GetContractPartyId() {
      return GetNextId("ContractPartyId");
    }

    internal static int GetContractPartyTracKId() {
      return GetNextId("ContractPartyTrackId");
    }

    internal static void Write(ContractParty o) {

      var op = DataOperation.Parse("writeFTHContractParties", o.ContractPartyTrackId, o.ContractPartyTrackUID,
                                  o.ContractPartyId, o.ContractPartyTypeId, o.ContractId, o.PartyId,
                                  o.RoleId, o.ExtData.ToString(), o.ContractPartyStatus, o.StartDate,
                                 o.EndDate, o.ContractPartyTrackDIF);

      DataWriter.Execute(op);    
    }

    #endregion Internal methods

    static private int GetNextId(string fieldId) {
      var sql = "SELECT max(" + fieldId + ") from FTHContractParties";
  
      var op = DataOperation.Parse(sql);

      var id = Empiria.Data.DataReader.GetScalar<int>(op) + 1;
      return id;

    }
  
  } //static internal class ContractPartyData

} // namespace Empiria.Insurtech.Policies.Data